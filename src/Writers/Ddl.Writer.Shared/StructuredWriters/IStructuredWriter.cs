using System;
using System.Threading.Tasks;

namespace TheToolsmiths.Ddl.Writer.StructuredWriters
{
    public interface IStructuredWriter : IAsyncDisposable
    {
        void WriteStartObject();

        void WriteStartArray(string propertyName);

        void WriteEndArray();

        void WriteEndObject();

        void WriteString(string propertyName, string value);

        ValueTask FlushAsync();

        void WritePropertyName(string propertyName);

        void WriteStringValue(string value);

        void WriteStartArray();

        void WriteStartObject(string propertyName);

        void WriteBoolean(string propertyName, in bool value);
    }
}
