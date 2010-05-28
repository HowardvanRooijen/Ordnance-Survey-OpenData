namespace ExportFromSQLToMongo
{
    #region Using Directives

    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ExportFromSQLToMongo.Domain;

    using Raven.Client.Document;

    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;

            using (var documentStore = new DocumentStore { Url = "http://localhost:8082" })
            {
                documentStore.Initialise();

                using (var dc = new CodePointOpenDataContext())
                {
                    var postcodes = from pc in dc.PostCodeGeoDatas
                                    select
                                        new PostCodes
                                            {
                                                PostCode = pc.PostCode,
                                                Location =
                                                    new Location { Latitude = pc.Latitude, Longitude = pc.Longitude }
                                            };

                    foreach (var postCodeEntry in postcodes)
                    {
                        using (var session = documentStore.OpenSession())
                        {
                            session.Store(postCodeEntry);
                            session.SaveChanges();
                        }
                    }
                }
            }

            DateTime end = DateTime.Now;

            TimeSpan result = end - start;
            Console.WriteLine(result.TotalMilliseconds);
            Console.WriteLine(result.TotalSeconds);
            Console.ReadKey();
         }
    }
}
