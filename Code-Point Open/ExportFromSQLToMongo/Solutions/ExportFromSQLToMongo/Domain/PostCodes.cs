namespace ExportFromSQLToMongo.Domain
{
    using Norm;

    public class PostCodes
    {
        public PostCodes()
        {
            this.Id = ObjectId.NewObjectId();
            this.loc = new double[1];
        }

        public ObjectId Id { get; set; }
        public string PostCode { get; set; }
        public double[] loc { get; set; }
        
    }
}