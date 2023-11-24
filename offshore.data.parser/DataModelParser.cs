using offshore.services;
using System.Text.Json;

namespace offshore.data.parsing;

public class DataModelParser : IDataModelParser
{
    public bool TryParseDataFile<TDataType>(in string relativeFilePath, out TDataType? parsedEntities) where TDataType : IJsonDataModel<TDataType>
    {
        parsedEntities = default;
        var fullFilePath = $"{AppDomain.CurrentDomain.BaseDirectory}\\{relativeFilePath}";
        if (!File.Exists(fullFilePath)) return false;

        

        parsedEntities = JsonSerializer.Deserialize<TDataType>(File.ReadAllText(fullFilePath));
        return true;
    }
}

