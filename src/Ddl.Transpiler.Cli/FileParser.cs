using System;
using System.Buffers;
using System.IO;
using System.IO.Pipelines;
using System.Text;
using System.Threading.Tasks;
using Ddl.Transpiler;
using TheToolsmiths.Ddl.Parser;

namespace TheToolsmiths.Ddl.Transpiler.Cli
{
    internal static class FileParser
    {
        public static void ParseFromFilePath(FileInfo input, FileInfo? output, ParseOutputType format)
        {
            Console.WriteLine();
            Console.WriteLine($"Parsing file '{input.FullName}'");

            var pipe = new Pipe();

            var read = Task.Run(async () => await ParseFile(input, pipe.Writer));

            var write = Task.Run(async () => await WriteOutput(output, pipe.Reader));

            Task.WaitAll(read, write);

            Console.WriteLine("File parsed");
            Console.WriteLine();
        }

        private static async Task ParseFile(FileInfo input, PipeWriter pipeWriter)
        {
            var result = await DdlTextParser.ParseFromFile(input.FullName);

            if (result.IsSuccess
                && result.Value != null)
            {
                await DdlTranspiler.TranspileToString(result.Value, pipeWriter);
            }
            else
            {
                Console.WriteLine($"Error parsing '{input.FullName}'");
                Console.WriteLine("Error parsing from file:" +
                                  $"{Environment.NewLine}" +
                                  $"{result.ErrorMessage}");
            }

            await pipeWriter.CompleteAsync();
        }

        private static async Task WriteOutput(FileInfo? output, PipeReader pipeReader)
        {
            try
            {
                if (output == null)
                {
                    await WriteOutputToConsole(pipeReader);
                    return;
                }

                await WriteOutputToFile(output, pipeReader);
                return;
            }
            catch (Exception e)
            {
                Console.Write($"Error: {e}");

                await pipeReader.CompleteAsync();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Reliability",
            "CA2000:Dispose objects before losing scope",
            Justification = "Roslyn analysers don't understand await using yet")]
        private static async Task WriteOutputToFile(FileInfo output, PipeReader pipeReader)
        {
            await using var fileStream = File.OpenWrite(output.FullName);

            await pipeReader.CopyToAsync(fileStream);
        }

        private static async Task WriteOutputToConsole(PipeReader pipeReader)
        {
            static void ProcessLine(ReadOnlySequence<byte> slice)
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
