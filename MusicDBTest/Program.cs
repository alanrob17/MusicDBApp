using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicDAL.Data;
using MusicDAL.Models;
using MusicDAL.Repository;

namespace MusicDBTest
{
    public class Program
    {
        private static readonly ArtistRepository _ar;
        // private static readonly RecordRepository _rr;

        static Program()
        {
            var db = new DataAccess();
            _ar = new ArtistRepository(db);
            // _rr = new RecordRepository(db);
        }

        public static async Task Main(string[] args)
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

            // All the below have to be changed
            // await InsertAsync();
            // await Insert2Async();
            // await UpdateArtistAsync();
            // await UpdateArtist2Async();
            // await UpdateAsync();
            // await Update2Async();
            // await DeleteArtistAsync();

            // await GetRecordAsync();
            // await CountDiscsAsync();
            // await GetArtistRecordNumberAsync();
            // await GetFormattedRecordAsync();
            // await SelectRecordsAsync();
            // await SelectRecordsShow();
            // await SelectRecordsByArtistIdAsync();
            // await SelectRecordReviewsAsync();
            // await GetRecordedYearNumberAsync();
            // await NoRecordReviewsAsync();
            // ToShortDate();
            // await GetTotalsAsync();
            // await InsertRecordAsync();
            // await InsertRecord2Async();
            // await UpdateRecordAsync();  
            // await UpdateRecord2Async();
            // await DeleteRecordAsync();  

            // GetTotalCosts();
        }

        //private static void GetTotalCosts()
        //{
        //    var totals = _tr.GetTotalCosts();

        //    foreach (var artist in totals)
        //    {
        //        Console.WriteLine($"{artist.Name}: {artist.TotalDiscs}: {artist.TotalCost:C}\n");
        //    }

        //}

        //private static async Task DeleteRecordAsync()
        //{
        //    var recordId = 5295;
        //    await _rr.DeleteAsync(recordId);

        //    Console.WriteLine("Record deleted");
        //}

        //private static async Task UpdateRecord2Async()
        //{
        //    var date = "21-06-2025";

        //    IFormatProvider culture = System.Threading.Thread.CurrentThread.CurrentCulture;

        //    var record = new Record
        //    {
        //        RecordId = 5296,
        //        ArtistId = 907,
        //        Name = "Laughing In Paradise",
        //        Recorded = 1991,
        //        Label = "Whoppo DoDah",
        //        Pressing = "Eng",
        //        Field = "Soundtrack",
        //        Rating = "****",
        //        Discs = 3,
        //        Media = "CD",
        //        Bought = DateTime.Parse(date, culture, System.Globalization.DateTimeStyles.AssumeLocal),
        //        Cost = 15.99m,
        //        CoverName = string.Empty,
        //        Review = "This is James' third album. His last before he turned to religion."
        //    };

        //    var recId = await _rr.UpdateAsync(record);

        //    Console.WriteLine(recId);
        //}

        //private static async Task UpdateRecordAsync()
        //{
        //    IFormatProvider culture = System.Threading.Thread.CurrentThread.CurrentCulture;

        //    var recordId = 5296;
        //    var artistId = 907;
        //    var name = "Laughter In Paradise";
        //    var recorded = 2026;
        //    var label = "Whoppo";
        //    var pressing = "Eng";
        //    var field = "Jazz";
        //    var rating = "***";
        //    var discs = 2;
        //    var media = "CD";
        //    var date = "28-03-2026";
        //    var bought = DateTime.Parse(date, culture, System.Globalization.DateTimeStyles.AssumeLocal);
        //    var cost = 12.99m;
        //    var coverName = string.Empty;
        //    var review = "This is James' third album. His last before he went mad.";

        //    recordId = await _rr.UpdateAsync(recordId, artistId, name, field, recorded, label, pressing, rating, discs, media, bought, cost, coverName, review);

        //    Console.WriteLine(recordId);
        //}

        //private static async Task InsertRecord2Async()
        //{
        //    var artistId = 907;
        //    var name = "Laughs In Paradise";
        //    var recorded = 2025;
        //    var label = "Whoppo";
        //    var pressing = "Au";
        //    var field = "Rock";
        //    var rating = "****";
        //    var discs = 1;
        //    var media = "CD";
        //    var bought = new DateTime(2025, 11, 06);
        //    var cost = 13.99m;
        //    var coverName = string.Empty;
        //    var review = "This is James' second album.";

        //    var recordId = await _rr.InsertAsync(artistId, name, field, recorded, label, pressing, rating, discs, media, bought, cost, coverName, review);

        //    Console.WriteLine(recordId);
        //}

        //private static async Task InsertRecordAsync()
        //{
        //    var record = new Record
        //    {
        //        ArtistId = 907,
        //        Name = "Fun In Paradise",
        //        Recorded = 2025,
        //        Label = "Whoppo",
        //        Pressing = "Au",
        //        Field = "Rock",
        //        Rating = "****",
        //        Discs = 1,
        //        Media = "CD",
        //        Bought = new DateTime(2025, 05, 06),
        //        Cost = 10.99m,
        //        CoverName = string.Empty,
        //        Review = "This is James' first album."
        //    };

        //    var recordId = await _rr.InsertAsync(record);

        //    Console.WriteLine($"New Id: {recordId}");
        //}

        //private static async Task GetTotalsAsync()
        //{
        //    var artists = await _rr.GetTotalCostsAsync();

        //    foreach (var artist in artists)
        //    {
        //        Console.WriteLine($"{artist.Name}: {artist.TotalDiscs}: {artist.TotalCost:C}\n");
        //    }
        //}

        private static void ToShortDate()
        {
            var dateStr = "28-12-2015";
            var myDate = MusicDAL.Extensions.DateTimeExtensions.ToShortDate(dateStr);

            Console.WriteLine(myDate);
        }

        //private static async Task NoRecordReviewsAsync()
        //{
        //    List<MissingReviewDto> records = await _rr.NoRecordReviewsAsync();

        //    foreach (var record in records)
        //    {
        //        Console.WriteLine($"{record.RecordId}: {record.Name} - {record.Record}\n");
        //    }
        //}

        //private static async Task GetRecordedYearNumberAsync()
        //{
        //    var year = 1974;
        //    var count = await _rr.GetRecordedYearNumberAsync(year);

        //    Console.WriteLine($"Count: {count} discs");
        //}

        //private static async Task SelectRecordReviewsAsync()
        //{
        //    var records = await _rr.SelectRecordReviewsAsync();

        //    foreach (var record in records)
        //    {
        //        Console.WriteLine($"{record.ArtistName} -- {record.Name}\n{record.Review}\n");
        //    }
        //}

        //private static async Task SelectRecordsByArtistIdAsync()
        //{
        //    var artistId = 114;

        //    var records = await _rr.SelectArtistRecordsAsync(artistId);

        //    foreach (var record in records)
        //    {
        //        Console.WriteLine($"{record.RecordId} -- {record.Name}");
        //    }
        //}

        //private static async Task SelectRecordsShow()
        //{
        //    var show = "r1974";

        //    var records = _rr.Select(show);

        //    foreach (var record in records)
        //    {
        //        Console.WriteLine($"{record.ArtistName} -- {record.Name} {record.Recorded} - {record.Media} : {record.Bought:d}\n");
        //    }
        //}

        //private static async Task SelectRecordsAsync()
        //{
        //    var records = await _rr.SelectAsync();

        //    foreach (var record in records)
        //    {
        //        Console.WriteLine($"{record.ArtistName} -- {record.Name} {record.Recorded} - {record.Media}\n");
        //    }
        //}

        //private static async Task GetFormattedRecordAsync()
        //{
        //    var recordId = 212;
        //    var record = await _rr.SelectAsync(recordId);
        //    var recordDetails = await ToStringAsync(record);

        //    Console.WriteLine(recordDetails);
        //}

        //private static async Task GetArtistRecordNumberAsync()
        //{
        //    var artistId = 114;
        //    var count = await _rr.GetArtistNumberOfRecordsAsync(artistId);

        //    Console.WriteLine($"Count: {count} discs");
        //}

        //private static async Task CountDiscsAsync()
        //{
        //    var count = await _rr.CountDiscsAsync("dvds");

        //    Console.WriteLine($"Count: {count} DVD's.");

        //    count = await _rr.CountDiscsAsync("cd");

        //    Console.WriteLine($"Count: {count} CD's");
        //}

        //private static async Task GetRecordAsync()
        //{
        //    var recordId = 1135;

        //    var artist = await _ar.GetArtistByRecordIdAsync(recordId);
        //    // var biography = await _ar.GetBiographyAsync(recordId); // not needed
        //    var record = await _rr.SelectAsync(recordId);

        //    Console.WriteLine($"\n{artist.ArtistId}: - Artist {artist.Name}:\n");

        //    Console.WriteLine($"\nRecordId: {record.RecordId}\nName: {record.Name}\nField: {record.Field}\nRecorded: {record.Recorded}\nLabel: {record.Label}\nPressing: {record.Pressing}\nDiscs: {record.Discs}\nMedia: {record.Media}\nBought: {record.Bought.ToShortDateString()}\nCost: ${record.Cost}\nReview:\n{record.Review}\n\nBiography:\n{artist.Biography}");
        //}

        private static async Task GetBiographyAsync()
        {
            var recordId = 197;
            var artistId = await _ar.GetArtistIdAsync(recordId);
            var artist = await _ar.SelectAsync(artistId);
            
            Console.WriteLine(artist.Biography);
        }

        private static async Task ShowArtistAsync()
        {
            var artistId = 26;
            Artist artist = await _ar.SelectAsync(artistId);

            Console.WriteLine(artist.ToString());
        }


        private static async Task DeleteArtistAsync()
        {
            var artistId = 906;
            await _ar.DeleteAsync(artistId);

            Console.WriteLine("Artist deleted");
        }

        private static async Task Update2Async()
        {
            var artistId = 906;
            var firstName = "Alan";
            var lastName = "Robson";
            var name = "Alan Robson";
            var biography = "<p>Alan plays a fast Polka dance music and has had success in Sweden and other Scandinavian countries.</p>";

            artistId = await _ar.UpdateAsync(artistId, firstName, lastName, name, biography);

            Console.WriteLine(artistId);
        }


        private static async Task GetArtistIdByRecordIdAsync()
        {
            var recordId = 289;
            var artistId = await _ar.GetArtistIdAsync(recordId);

            Console.WriteLine(artistId);
        }

        private static async Task GetArtistIdByNameAsync()
        {
            var artistId = await _ar.GetArtistIdAsync("Bob", "Dylan");

            Console.WriteLine(artistId);
        }

        public static async Task UpdateArtist2Async()
        {
            var artistId = 906;
            var firstName = "Chuck";
            var lastName = "Robson-Smith";
            var name = "Chuck Robson-Smith";
            var biography = "<p>Chuck is a superstar Pop singer.</p>";

            artistId = await _ar.UpdateAsync(artistId, firstName, lastName, name, biography);

            Console.WriteLine(artistId);
        }

        private static async Task UpdateArtistAsync()
        {
            var artist = new Artist
            {
                ArtistId = 906,
                FirstName = "Alan",
                LastName = "Robsano",
                Name = "Alan Robsano",
                Biography = "Alan hates country and western. He hates both kinds of music."
            };

            var artistId = await _ar.UpdateArtistAsync(artist);

            Console.WriteLine(artistId);
        }

        private static async Task UpdateAsync()
        {
            var artist = new Artist
            {
                ArtistId = 906,
                FirstName = "Jamo",
                LastName = "Robsono",
                Name = "Jamo Robsano",
                Biography = "<p>Jamo hates country and western. He hates both kinds of music.</p>"
            };

            var artistId = await _ar.UpdateArtistAsync(artist);

            Console.WriteLine(artistId);
        }

        public static async Task Insert2Async()
        {
            var artistId = 0;
            var firstName = "James";
            var lastName = "Robson";
            var biography = "James likes Pocopunk.";

            var newArtistId = await _ar.InsertAsync(artistId, firstName, lastName, biography);

            Console.WriteLine(newArtistId);
        }

        public static async Task InsertAsync()
        {
            var artist = new Artist
            {
                ArtistId = 0,
                FirstName = "James",
                LastName = "Robson",
                Biography = "<p>James is an awesome Bass player.</p>"
            };

            var artistId = await _ar.InsertAsync(artist);

            Console.WriteLine(artistId);
        }

        private static async Task SelectArtistWithNoBioAsync()
        {
            var artists = await _ar.SelectArtistWithNoBioAsync();

            foreach (var artist in artists) Console.WriteLine($"{artist.ArtistId}: {artist.Name}");
        }

        private static async Task GetSingleArtistAsync(int artistId)
        {
            var artist = await _ar.SelectAsync(artistId);

            Console.WriteLine($"{artist.ArtistId} - {artist.RecordArtistId}: \n{artist.Name} -- {artist.LastName}, {artist.FirstName}\n{artist.Biography}\n");
        }

        private static async Task GetArtistNamesAsync()
        {
            var artists = await _ar.GetArtistsAsync();

            foreach (var artist in artists) Console.WriteLine(artist.Name);
        }

        private static async Task SelectAsync()
        {
            var artists = await _ar.GetArtistsAsync();

            foreach (var artist in artists)
            {
                var bio = string.IsNullOrEmpty(artist.Biography) ? "No Biography" : (artist.Biography.Length > 60 ? artist.Biography.Substring(0, 60) + "..." : artist.Biography);
                Console.WriteLine("{0} -- {1}\n{2}\n", artist.ArtistId, artist.Name, bio);
            }
        }

        private static async Task GetArtistsAsync()
        {

            var artists = await _ar.GetArtistsAsync();
            foreach (var a in artists) Console.WriteLine(a.Name);
        }

        private static async Task ShowArtistsAsync()
        {
            var artists = await _ar.GetArtistsAsync();

            foreach (var a in artists) Console.WriteLine(a.Name);
        }

        // used for ObjectDataSource
        private static async Task GetArtists()
        {
            var artists = await _ar.GetArtistsAsync();
            foreach (var a in artists) Console.WriteLine(a.Name);
        }

        private static async Task GetArtistListAsync()
        {
            var artists = await _ar.GetArtistsAsync();
            foreach (var a in artists) Console.WriteLine(a.Name);
        }

        //private static async Task<string> ToStringAsync(Record record)
        //{
        //    var artist = await _ar.SelectAsync(record.ArtistId);
        //    var str = new StringBuilder();

        //    str.Append("<strong>RecordId: </strong>" + record.RecordId + "<br/>");
        //    str.Append("<strong>ArtistId: </strong>" + record.ArtistId + "<br/>");
        //    str.Append("<strong>ArtistName: </strong>" + artist.Name + "<br/>");
        //    str.Append("<strong>Name: </strong>" + record.Name + "<br/>");
        //    str.Append("<strong>Field: </strong>" + record.Field + "<br/>");
        //    str.Append("<strong>Recorded: </strong>" + record.Recorded + "<br/>");
        //    str.Append("<strong>Label: </strong>" + record.Label + "<br/>");
        //    str.Append("<strong>Pressing: </strong>" + record.Pressing + "<br/>");
        //    str.Append("<strong>Rating: </strong>" + record.Rating + "<br/>");
        //    str.Append("<strong>Discs: </strong>" + record.Discs + "<br/>");
        //    str.Append("<strong>Media: </strong>" + record.Media + "<br/>");

        //    if (record.Bought > DateTime.MinValue)
        //    {
        //        str.Append("<strong>Bought: </strong>" + record.Bought.ToShortDateString() + "<br/>");
        //    }

        //    if (!string.IsNullOrEmpty(record.Cost.ToString(CultureInfo.InvariantCulture)))
        //    {
        //        str.Append("<strong>Cost: </strong>" + record.Cost + "<br/>");
        //    }

        //    if (!string.IsNullOrEmpty(record.CoverName))
        //    {
        //        str.Append("<strong>CoverName: </strong>" + record.CoverName + "<br/>");
        //    }

        //    if (!string.IsNullOrEmpty(record.Review))
        //    {
        //        str.Append("<strong>Review: </strong>" + record.Review + "<br/>");
        //    }

        //    return str.ToString();
        //}
    }
}

