using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicDAL.Data;
using MusicDAL.Models;
using MusicDAL.Repository;
using MusicDBTest.Services;

namespace MusicDBTest
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //var artistServices = new ArtistServices();
            //await artistServices.RunArtistServices();

            // var recordServices = new RecordServices();
            // await recordServices.RunRecordServices();

            var discServices = new DiscServices();
            await discServices.RunDiscServices();

        }
    }
}

