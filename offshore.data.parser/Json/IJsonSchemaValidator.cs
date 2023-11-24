
namespace offshore.data.parsing.Json
{
    public interface IJsonSchemaValidator
    {
        bool ValidateDataAgainstSchema(in string dataFilePath, in string schemaName, out IList<string> errors);
    }
}