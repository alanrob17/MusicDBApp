using MusicDAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDAL.Repository
{
    // This class is used for connecting to repositories in ASPX code behind files.
    // It is not intended for use in the business layer or other layers of the application.
    public class RepositoryInitialiser
    {
        public static readonly ArtistRepository ArtistRepo;
        public static readonly RecordRepository RecordRepo;

        static RepositoryInitialiser()
        {
            var db = new DataAccess();
            ArtistRepo = new ArtistRepository(db);
            RecordRepo = new RecordRepository(db);
        }

    }
}
