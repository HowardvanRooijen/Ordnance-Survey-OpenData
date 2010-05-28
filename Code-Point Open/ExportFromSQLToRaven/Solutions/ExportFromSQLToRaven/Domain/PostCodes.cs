namespace ExportFromSQLToMongo.Domain
{
    using System;

    public class PostCodes
    {
        public PostCodes()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Location = new Location();
        }

        public string Id { get; set; }
        public string PostCode { get; set; }
        public Location Location { get; set; }
    }
}