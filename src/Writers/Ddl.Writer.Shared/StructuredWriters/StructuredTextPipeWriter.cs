using System;
using System.Buffers;
using System.Text;
using System.Threading.Tasks;

namespace TheToolsmiths.Ddl.Writer.StructuredWriters
{
    public class StructuredTextPipeWriter : IStructuredWriter
    {
        private readonly IBufferWriter<byte> bufferWriter;
        private readonly Encoder encoder;

        public StructuredTextPipeWriter(IBufferWriter<byte> bufferWriter)
        {
            this.bufferWriter = bufferWriter;

            this.encoder = Encoding.UTF8.GetEncoder();
        }

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }

        public void WriteStartObject()
        {
            this.WriteNewLine();
        }

        public void WriteStartArray(string propertyName)
        {
            throw new NotImplementedException();
        }

        public void WriteEndArray()
        {
            throw new NotImplementedException();
        }

        public void WriteEndObject()
        {
            this.WriteNewLine();
        }

        public void WriteString(string propertyName, string value)
        {
            throw new NotImplementedException();
        }

        public void WritePropertyName(string propertyName)
        {
            this.WriteText(propertyName);
        }

        public void WriteStringValue(string value)
        {
            throw new NotImplementedException();
        }

        public void WriteStartArray()
        {
            throw new NotImplementedException();
        }

        public void WriteStartObject(string propertyName)
        {
            throw new NotImplementedException();
        }

        public void WriteBoolean(string propertyName, in bool value)
        {
            throw new NotImplementedException();
        }

        public ValueTask FlushAsync()
        {
            return default;
        }

        private void WriteNewLine()
        {
            this.WriteText(Environment.NewLine);
        }

        private void WriteText(string text)
        {
            int byteCount = this.encoder.GetByteCount(text, true);

            var writeSpan = this.bufferWriter.GetSpan(byteCount);

            this.encoder.Convert(text, writeSpan, true, out int charsUsed, out int bytesUsed, out bool completed);

            if (completed == false)
            {
                throw new NotImplementedException();
            }

            this.bufferWriter.Advance(bytesUsed);
        }
    }
}
