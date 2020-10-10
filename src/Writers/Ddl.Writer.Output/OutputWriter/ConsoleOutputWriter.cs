using System;
using System.Buffers;
using System.IO.Pipelines;
using System.Text;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Writer.Output.OutputWriter
{
    public class ConsoleOutputWriter : IOutputWriter
    {
        private readonly PipeReader pipeReader;

        public ConsoleOutputWriter(PipeReader pipeReader)
        {
            this.pipeReader = pipeReader;
        }

        public async Task<Result> WriteAsync()
        {
            try
            {
                await this.HandleWriteOutputToConsole().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                return Result.FromErrorMessage($"Error writing output. Message: '{e.Message}'");
            }

            return Result.Success;
        }

        private async Task HandleWriteOutputToConsole()
        {
            void ProcessLine(ReadOnlySequence<byte> slice)
            {
                foreach (var utf8Bytes in slice)
                {
                    string s = Encoding.UTF8.GetString(utf8Bytes.Span);

                    Console.Write(s);
                }

                Console.WriteLine();
            }

            while (true)
            {
                var result = await this.pipeReader.ReadAsync().ConfigureAwait(false);

                var buffer = result.Buffer;

                SequencePosition? position;
                do
                {
                    // Look for a EOL in the buffer
                    position = buffer.PositionOf((byte)'\n');

                    if (position != null)
                    {
                        // Process the line
                        ProcessLine(buffer.Slice(0, position.Value));

                        // Skip the line + the \n character (basically position)
                        buffer = buffer.Slice(buffer.GetPosition(1, position.Value));
                    }
                }
                while (position != null);

                // Tell the PipeReader how much of the buffer we have consumed
                this.pipeReader.AdvanceTo(buffer.Start, buffer.End);

                // Stop reading if there's no more data coming
                if (result.IsCompleted)
                {
                    // Write any possible remains in the buffer
                    if (buffer.IsEmpty == false)
                    {
                        ProcessLine(buffer);
                    }

                    break;
                }
            }
        }
    }
}
