namespace ExportFromSQLToMongo
{
    #region Using Directives

    using System.Linq;

    using ExportFromSQLToMongo.Configuration;
    using ExportFromSQLToMongo.Domain;
    using ExportFromSQLToMongo.Infrastructure;

    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            using (var session = new Session<PostCodes>(Settings.DocumentDatabaseName))
            {
                using(var dc = new CodePointOpenDataContext())
                {
                    var postcodes = from pc in dc.PostCodeGeoDatas
                                    select
                                        new PostCodes
                                            {
                                                PostCode = pc.PostCode,
                                                loc = new[] { (double)pc.Latitude, (double)pc.Longitude }
                                            };

                    foreach (var postCodeEntry in postcodes)
                    {
                        session.Add(postCodeEntry);
                    }
                }
            }
         }
    }
}
