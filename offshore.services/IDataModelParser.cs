namespace offshore.services
{
    public interface IDataModelParser
    {
        bool TryParseDataFile<TDataType>(in string relativeFilePath, out TDataType? parsedEntities) 
            where TDataType : IJsonDataModel<TDataType>;
    }
}