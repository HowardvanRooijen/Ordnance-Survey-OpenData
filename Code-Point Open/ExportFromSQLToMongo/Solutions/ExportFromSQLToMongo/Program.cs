namespace ExportFromSQLToMongo
{
    #region Using Directives

    using System;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;

    using ExportFromSQLToMongo.Configuration;
    using ExportFromSQLToMongo.Domain;
    using ExportFromSQLToMongo.Infrastructure;

    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;  

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

                    //Parallel.ForEach(postcodes, postcode => session.Add(postcode));
                }
            }

            DateTime end = DateTime.Now;

            TimeSpan result = end - start;
            Console.WriteLine(result.TotalMilliseconds);
            Console.ReadKey();
         }
    }
}
