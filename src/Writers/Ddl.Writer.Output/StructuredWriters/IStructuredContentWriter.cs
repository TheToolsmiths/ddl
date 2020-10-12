using System;
using System.Threading.Tasks;

namespace TheToolsmiths.Ddl.Writer.Output.StructuredWriters
{
    public interface IStructuredContentWriter : IAsyncDisposable
    {
        void WriteStartObject();

        void WriteStartArray(string propertyName);

        void WriteEndArray();

        void WriteEndObject();

        void WriteString(string propertyName, string value);

        void WritePropertyName(string propertyName);

        void WriteStringValue(string value);

        void WriteStartArray();

        void WriteStartObject(string propertyName);

        void WriteBoolean(string propertyName, in bool value);

        void WriteNumber(string propertyName, in int value);

        ValueTask FlushAsync();
    }
}
