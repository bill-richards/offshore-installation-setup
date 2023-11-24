using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace offshore.data.parsing.Json;

public class JsonSchemaValidator : IJsonSchemaValidator
{

    public bool ValidateDataAgainstSchema(in string dataFilePath, in string schemaName, out IList<string> errors)
    {
        var schema = JSchema.Parse(File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}\\JSON\\schemata\\{schemaName}"));
        JObject dataFile = JObject.Parse(File.ReadAllText(dataFilePath));
        return dataFile.IsValid(schema, out errors);
    }
}
