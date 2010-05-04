namespace ExportFromSQLToMongo.Domain
{
    using Norm;

    public class PostCodes
    {
        public PostCodes()
        {
            this.Id = ObjectId.NewObjectId();
        }

        public ObjectId Id { get; set; }
        public string PostCode { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}