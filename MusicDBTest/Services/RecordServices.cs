using MusicDAL.Data;
using MusicDAL.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicDAL.Models;
using MusicDAL.Models.Dtos;

namespace MusicDBTest.Services
{
    public class RecordServices : IRecordServices
    {
        private readonly RecordRepository _rr;
        private readonly ArtistRepository _ar;

        public RecordServices()
        {
            var db = new DataAccess();
            _rr = new RecordRepository(db);
            _ar = new ArtistRepository(db);
        }

        public async Task RunRecordServices()
        {
            // await GetRecordAsync();
            // await GetRecord2Async();
            // await GetArtistRecordNumberAsync();
            // await GetFormattedRecordAsync();
            // await SelectRecordsAsync();
            // await SelectRecords2Async();
            // SelectRecordsShow("all");
            // SelectRecordsShow("2017");
            // SelectRecordsShow("Rock");
            // SelectRecordsShow("Rockdesc");
            // SelectRecordsShow("r1974");
            // SelectRecordsShow("aid26");
            // await SelectRecordsByArtistIdAsync();
            // await SelectRecordReviewsAsync();
            // SelectRecordReviews();
            // await GetRecordedYearNumberAsync();
            // await NoRecordReviewsAsync();
            // ToShortDate();

            // To be added
            // await GetArtistNumberOfRecordsAsync("Bob Dylan");
            // await GetRecordByNameAsync("Blonde");
            // await GetRecordsByNameAsync("Bringing");
            // await GetTotalAlbumTimeAsync();
            // await GetTotalTimeByArtistIdAsync(26);
            // await GetArtistFromArtistNameAsync("Neil Young");
            // await CountDiscsAsync("Blues");
            // await GetArtistNameFromRecordAsync(1373);
            // await GetRecordListByYearAsync(1974);
            // await GetRecordDetailsAsync(3232);
            // await GetRecordHtmlAsync(3232);
            // await GetAlbumLengthAsync(306);
            // await GetAlbumDetailsAndLengthAsync(306);
            // await GetNullRecordField(); // where Field is null
            // await GetAllRecordFoldersAsync();

            // To be tested
            // await InsertRecordAsync();
            // await InsertRecord2Async();
            // await UpdateRecordAsync();  
            // await UpdateRecord2Async();
            // await DeleteRecordAsync();  
        }

        public async Task GetRecordAsync()
        {
            var recordId = 154;

            var artist = await _ar.GetArtistByRecordIdAsync(recordId);
            // var biography = await _ar.GetBiographyAsync(recordId); // not needed
            var record = await _rr.SelectAsync(recordId);

            Console.WriteLine($"\n{artist.ArtistId}: - Artist {artist.Name}:\n");

            Console.WriteLine($"\nRecordId: {record.RecordId}\nName: {record.Name}\nField: {record.Field}\nRecorded: {record.Recorded}\nLength: {record.Length}\nDiscs: {record.Discs}\nReview:\n{record.Review}\n\nBiography:\n{artist.Biography}");
        }

        public async Task GetRecord2Async()
        {
            var recordId = 154;

            var album = await _rr.GetArtistRecordAsync(recordId);

            Console.WriteLine($"\n{album.ArtistId}: - Artist {album.ArtistName}:");

            Console.WriteLine($"\nRecordId: {album.RecordId}\nName: {album.Name}\nField: {album.Field}\nRecorded: {album.Recorded}\nLength: {album.Length}\nDiscs: {album.Discs}\nReview:\n{album.Review}\n");
        }

        public async Task GetArtistRecordNumberAsync()
        {
            var artistId = 26;
            var count = await _rr.GetArtistNumberOfRecordsAsync(artistId);

            Console.WriteLine($"Count: {count} discs");
        }

        public async Task GetFormattedRecordAsync()
        {
            var recordId = 212;
            var record = await _rr.SelectAsync(recordId);
            var recordDetails = await ToStringAsync(record);

            Console.WriteLine(recordDetails);
        }

        public async Task SelectRecordsAsync()
        {
            var records = await _rr.SelectAsync();

            var artists = await _ar.SelectAsync();
            var artistDict = artists.ToDictionary(a => a.ArtistId, a => a.Name);
    
            foreach (var record in records)
            {
                string artistName = artistDict.TryGetValue(record.ArtistId, out var n) ? n : "Unknown";
                Console.WriteLine($"{record.ArtistId} -- {artistName} -- {record.Name} [{record.Recorded}] - {record.Field} - {record.Length}\n");
            }
        }

        public async Task SelectRecords2Async()
        {
            List<ArtistRecordDto> albums = await _rr.SelectArtistRecordListAsync();

            foreach (var record in albums)
            {
                Console.WriteLine($"{record.ArtistId} -- {record.ArtistName} -- {record.Name} [{record.Recorded}] - {record.Field} - {record.Length}\n");
            }
        }

        public void SelectRecordsShow(string show)
        {
            var records = _rr.Select(show);

            foreach (var record in records)
            {
                Console.WriteLine($"{record.ArtistName} -- {record.Name} {record.Recorded} - Length: {record.Length}\n");
            }
        }

        public async Task SelectRecordsByArtistIdAsync()
        {
            var artistId = 26;

            var records = await _rr.SelectArtistRecordsAsync(artistId);

            foreach (var record in records)
            {
                Console.WriteLine($"{record.RecordId} -- {record.Name}");
            }
        }

        public async Task SelectRecordReviewsAsync()
        {
            var albums = await _rr.SelectRecordReviewsAsync();

            foreach (var record in albums)
            {
                Console.WriteLine($"{record.ArtistName} -- {record.Name}\n{record.Review}\n");
            }
        }

        public void SelectRecordReviews()
        {
            var albums = _rr.SelectRecordReviews();

            foreach (var record in albums)
            {
                Console.WriteLine($"{record.ArtistName} -- {record.Name}\n{record.Review}\n");
            }
        }

        public async Task GetRecordedYearNumberAsync()
        {
            var year = 1975;
            var count = await _rr.GetRecordedYearNumberAsync(year);

            Console.WriteLine($"Year {year}: has {count} discs");
        }

        public async Task NoRecordReviewsAsync()
        {
            List<ArtistRecordDto> records = await _rr.NoRecordReviewsAsync();

            foreach (var record in records)
            {
                Console.WriteLine($"{record.ArtistId}: {record.ArtistName} -- {record.RecordId}: {record.Name} - {record.Recorded}\n");
            }
        }

        public void ToShortDate()
        {
            var dateStr = "05-04-2026";
            var myDate = MusicDAL.Extensions.DateTimeExtensions.ToShortDate(dateStr);

            Console.WriteLine(myDate);
        }

        //public async Task DeleteRecordAsync()
        //{
        //    var recordId = 5295;
        //    await _rr.DeleteAsync(recordId);

        //    Console.WriteLine("Record deleted");
        //}

        //public async Task UpdateRecord2Async()
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

        //public async Task UpdateRecordAsync()
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

        //public async Task InsertRecord2Async()
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

        //public async Task InsertRecordAsync()
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

        public async Task<string> ToStringAsync(Record record)
        {
            var artist = await _ar.SelectAsync(record.ArtistId);
            var str = new StringBuilder();

            str.Append("<strong>RecordId: </strong>" + record.RecordId + "<br/>");
            str.Append("<strong>ArtistId: </strong>" + record.ArtistId + "<br/>");
            str.Append("<strong>ArtistName: </strong>" + artist.Name + "<br/>");
            str.Append("<strong>Name: </strong>" + record.Name + "<br/>");
            str.Append("<strong>Field: </strong>" + record.Field + "<br/>");
            str.Append("<strong>Recorded: </strong>" + record.Recorded + "<br/>");
            str.Append("<strong>Discs: </strong>" + record.Discs + "<br/>");
            str.Append("<strong>Length: </strong>" + record.Length + "<br/>");
            str.Append("<strong>Folder: </strong>" + record.Folder + "<br/>");

            if (!string.IsNullOrEmpty(record.CoverName))
            {
                str.Append("<strong>CoverName: </strong>" + record.CoverName + "<br/>");
            }
            
            if (!string.IsNullOrEmpty(record.Review))
            {
                str.Append("<strong>Review: </strong>" + record.Review + "<br/>");
            }

            return str.ToString();
        }
    }
}