using MusicDAL.Data;
using MusicDAL.Models;
using MusicDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MusicDBTest.Services
{
    public class ArtistServices : IArtistServices
    {
        private readonly ArtistRepository _ar;

        public ArtistServices()
        {
            var db = new DataAccess();
            _ar = new ArtistRepository(db);
        }

        public async Task RunArtistServices()
        {
            // await GetArtistsAsync();
            // await GetArtists();
            // await GetArtistListAsync();
            // await ShowArtistsAsync();
            // await SelectAsync();
            // await GetArtistNamesAsync();
            // await GetSingleArtistAsync(26);
            // await SelectArtistWithNoBioAsync();
            // await GetArtistIdByNameAsync();
            // await GetArtistIdByRecordIdAsync();
            // await ShowArtistAsync();
            // await GetBiographyAsync();
            // await CountArtistsAsync();
            // await CheckForArtistNameAsync("Alan Robson");
            // await GetArtistByFirstLastNameAsync("Bruce", "Cockburn");
            await GetBiographyFromRecordIdAsync(123);

            // All the below have to be changed
            //await InsertAsync();
            //await Insert2Async();
            //await UpdateArtistAsync();
            //await UpdateArtist2Async();
            //await UpdateAsync();
            //await Update2Async();
            //await DeleteArtistAsync();
        }

        public async Task GetBiographyFromRecordIdAsync(int recordId)
        { 
            string biography = await _ar.GetBiographyFromRecordIdAsync(recordId);
            var parameter = new { RecordId = recordId };

            Console.WriteLine(!string.IsNullOrEmpty(biography)
                ? $"Biography: {biography}"
                : $"No biography found for RecordId: {recordId}");
        }

        public async Task GetArtistByFirstLastNameAsync(string firstName, string lastName)
        {
            var artist = await _ar.GetArtistByFirstLastNameAsync(firstName, lastName);
            if (artist != null)
            {
                var biography = string.IsNullOrEmpty(artist.Biography) ? "No Biography" : (artist.Biography.Length > 30 ? artist.Biography.Substring(0, 60) + "..." : artist.Biography);
                Console.WriteLine($"Id: {artist.ArtistId} - {artist.Name} - {biography}");
            }
            else
            {
                Console.WriteLine($"Artist with name {firstName} {lastName} not found.");
            }
        }

        public async Task CheckForArtistNameAsync(string name)
        {
            var result = await _ar.CheckForArtistNameAsync(name);
            Console.WriteLine(result
                ? $"Artist {name} exists in the database."
                : $"Artist {name} does not exist in the database.");
        }

        public async Task CountArtistsAsync()
        {
            var count = await _ar.GetArtistCount();

            Console.WriteLine($"There are {count} artists in the database.");
        }

        public async Task GetArtistsAsync()
        {

            var artists = await _ar.GetArtistsAsync();
            foreach (var a in artists) Console.WriteLine(a.Name);
        }

        // used for ObjectDataSource
        public async Task GetArtists()
        {
            var artists = await _ar.GetArtistsAsync();
            foreach (var a in artists) Console.WriteLine(a.Name);
        }

        public async Task GetArtistListAsync()
        {
            var artists = await _ar.GetArtistsAsync();
            foreach (var a in artists) Console.WriteLine(a.Name);
        }

        public async Task ShowArtistsAsync()
        {
            var artists = await _ar.GetArtistsAsync();

            foreach (var a in artists) Console.WriteLine(a.Name);
        }

        public async Task SelectAsync()
        {
            var artists = await _ar.GetArtistsAsync();

            foreach (var artist in artists)
            {
                var bio = string.IsNullOrEmpty(artist.Biography) ? "No Biography" : (artist.Biography.Length > 60 ? artist.Biography.Substring(0, 60) + "..." : artist.Biography);
                Console.WriteLine("{0} -- {1}\n{2}\n", artist.ArtistId, artist.Name, bio);
            }
        }

        public async Task GetArtistNamesAsync()
        {
            var artists = await _ar.GetArtistsAsync();

            foreach (var artist in artists) Console.WriteLine(artist.Name);
        }

        public async Task GetSingleArtistAsync(int artistId)
        {
            var artist = await _ar.SelectAsync(artistId);

            Console.WriteLine($"{artist.ArtistId} - {artist.RecordArtistId}: \n{artist.Name} -- {artist.LastName}, {artist.FirstName}\n{artist.Biography}\n");
        }

        public async Task SelectArtistWithNoBioAsync()
        {
            var artists = await _ar.SelectArtistWithNoBioAsync();

            foreach (var artist in artists) Console.WriteLine($"{artist.ArtistId}: {artist.Name}");
        }

        public async Task GetArtistIdByNameAsync()
        {
            var artistId = await _ar.GetArtistIdAsync("Bob", "Dylan");

            Console.WriteLine(artistId);
        }

        public async Task GetArtistIdByRecordIdAsync()
        {
            var recordId = 289;
            var artistId = await _ar.GetArtistIdAsync(recordId);

            Console.WriteLine(artistId);
        }

        public async Task ShowArtistAsync()
        {
            var artistId = 26;
            Artist artist = await _ar.SelectAsync(artistId);

            Console.WriteLine(artist.ToString());
        }

        public async Task GetBiographyAsync()
        {
            var recordId = 197;
            var artistId = await _ar.GetArtistIdAsync(recordId);
            var artist = await _ar.SelectAsync(artistId);

            Console.WriteLine(artist.Biography);
        }
        
        //public async Task DeleteArtistAsync()
        //{
        //    var artistId = 906;
        //    await _ar.DeleteAsync(artistId);

        //    Console.WriteLine("Artist deleted");
        //}

        //public async Task Update2Async()
        //{
        //    var artistId = 906;
        //    var firstName = "Alan";
        //    var lastName = "Robson";
        //    var name = "Alan Robson";
        //    var biography = "<p>Alan plays a fast Polka dance music and has had success in Sweden and other Scandinavian countries.</p>";

        //    artistId = await _ar.UpdateAsync(artistId, firstName, lastName, name, biography);

        //    Console.WriteLine(artistId);
        //}

        //public static async Task UpdateArtist2Async()
        //{
        //    var artistId = 906;
        //    var firstName = "Chuck";
        //    var lastName = "Robson-Smith";
        //    var name = "Chuck Robson-Smith";
        //    var biography = "<p>Chuck is a superstar Pop singer.</p>";

        //    artistId = await _ar.UpdateAsync(artistId, firstName, lastName, name, biography);

        //    Console.WriteLine(artistId);
        //}

        //public async Task UpdateArtistAsync()
        //{
        //    var artist = new Artist
        //    {
        //        ArtistId = 906,
        //        FirstName = "Alan",
        //        LastName = "Robsano",
        //        Name = "Alan Robsano",
        //        Biography = "Alan hates country and western. He hates both kinds of music."
        //    };

        //    var artistId = await _ar.UpdateArtistAsync(artist);

        //    Console.WriteLine(artistId);
        //}

        //public async Task UpdateAsync()
        //{
        //    var artist = new Artist
        //    {
        //        ArtistId = 906,
        //        FirstName = "Jamo",
        //        LastName = "Robsono",
        //        Name = "Jamo Robsano",
        //        Biography = "<p>Jamo hates country and western. He hates both kinds of music.</p>"
        //    };

        //    var artistId = await _ar.UpdateArtistAsync(artist);

        //    Console.WriteLine(artistId);
        //}

        //public static async Task Insert2Async()
        //{
        //    var artistId = 0;
        //    var firstName = "James";
        //    var lastName = "Robson";
        //    var biography = "James likes Pocopunk.";

        //    var newArtistId = await _ar.InsertAsync(artistId, firstName, lastName, biography);

        //    Console.WriteLine(newArtistId);
        //}

        //public static async Task InsertAsync()
        //{
        //    var artist = new Artist
        //    {
        //        ArtistId = 0,
        //        FirstName = "James",
        //        LastName = "Robson",
        //        Biography = "<p>James is an awesome Bass player.</p>"
        //    };

        //    var artistId = await _ar.InsertAsync(artist);

        //    Console.WriteLine(artistId);
        //}
    }
}
