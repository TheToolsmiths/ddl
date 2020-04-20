using System;
using System.Buffers;
using System.IO.Pipelines;
using System.Text;
using System.Threading.Tasks;

namespace TheToolsmiths.Ddl.Cli.Writers
{
    public static class ConsolePipeWriter
    {
        public static async Task WriteOutputToConsole(PipeReader pipeReader)
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
                var result = await pipeReader.ReadAsync();

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
                pipeReader.AdvanceTo(buffer.Start, buffer.End);

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

            // Mark the PipeReader as complete
            pipeReader.Complete();
        }
    }
}
