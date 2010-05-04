namespace ExportFromSQLToMongo.Contracts
{
    using Norm;

    public interface IUniqueIdentifier
    {
        ObjectId Id { get; set; }
    }
}