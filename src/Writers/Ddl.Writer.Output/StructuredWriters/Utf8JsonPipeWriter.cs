using System.Buffers;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;

namespace TheToolsmiths.Ddl.Writer.Output.StructuredWriters
{
    public class Utf8JsonPipeWriter : IStructuredContentWriter
    {
        private readonly Utf8JsonWriter jsonWriter;

        public Utf8JsonPipeWriter(IBufferWriter<byte> bufferWriter)
        {
            var writerOptions = new JsonWriterOptions
            {
                Indented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            this.jsonWriter = new Utf8JsonWriter(bufferWriter, writerOptions);
        }

        public ValueTask DisposeAsync()
        {
            return this.jsonWriter.DisposeAsync();
        }

        public void WriteStartObject()
        {
            this.jsonWriter.WriteStartObject();
        }

        public void WriteStartArray(string propertyName)
        {
            this.jsonWriter.WriteStartArray(propertyName);
        }

        public void WriteEndArray()
        {
            this.jsonWriter.WriteEndArray();
        }

        public void WriteEndObject()
        {
            this.jsonWriter.WriteEndObject();
        }

        public void WriteString(string propertyName, string value)
        {
            this.jsonWriter.WriteString(propertyName, value);
        }

        public void WritePropertyName(string propertyName)
        {
            this.jsonWriter.WritePropertyName(propertyName);
        }

        public void WriteStringValue(string value)
        {
            this.jsonWriter.WriteStringValue(value);
        }

        public void WriteStartArray()
        {
            this.jsonWriter.WriteStartArray();
        }

        public void WriteStartObject(string propertyName)
        {
            this.jsonWriter.WriteStartObject(propertyName);
        }

        public void WriteBoolean(string propertyName, in bool value)
        {
            this.jsonWriter.WriteBoolean(propertyName, value);
        }

        public void WriteNumber(string propertyName, in int value)
        {
            this.jsonWriter.WriteNumber(propertyName, value);
        }

        public async ValueTask FlushAsync()
        {
            await this.jsonWriter.FlushAsync().ConfigureAwait(true);
        }
    }
}
