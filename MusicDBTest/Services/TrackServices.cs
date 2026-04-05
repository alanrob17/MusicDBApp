using MusicDAL.Data;
using MusicDAL.Models;
using MusicDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MusicDBTest.Services
{
    public class TrackServices : ITrackServices
    {
        private readonly TrackRepository _tr;

        public TrackServices()
        {
            var db = new DataAccess();
            _tr = new TrackRepository(db);
        }

        public async Task RunTrackServices()
        {
            // await GetAllTracksAsync();
            // await GetAllTracksAsync(true);
            // await GetFullListAsync();
            // await GetArtistListAsync(26);
            // await GetArtistRecordAsync(26, 3322);
            // await GetTotalAlbumTimeAsync();
            // await GetAllSingleTracksAsync();
            await GetArtistGuestTracksAsync("Bob Dylan");
        }

        public async Task GetAllTracksAsync()
        {
            var tracks = await _tr.GetAllTracksAsync();

            foreach (var track in tracks)
            {
                Console.WriteLine($"{track.Artist} - {track.Album} - {track.DiscNumber} - {track.Number}. {track.Name} [{track.Duration}] - {track.Field}");
            }
        }

        public async Task GetAllTracksAsync(bool includeTechDetails)
        {
            var tracks = await _tr.GetAllTracksAsync(includeTechDetails);

            foreach (var track in tracks)
            {
                if (includeTechDetails == true)
                {
                    Console.WriteLine($"{track.Artist} - {track.Album} - {track.DiscNumber} - {track.Number}. {track.Name} [{track.Duration}] - {track.Media}");
                }
                else
                {
                    Console.WriteLine(
                        $"{track.Artist} - {track.Album} - {track.DiscNumber} - {track.Number}. {track.Name} [{track.Duration}]");
                }
            }
        }

        public async Task GetFullListAsync()
        {
            var tracks = await _tr.GetFullListAsync();

            foreach (var track in tracks)
            {
                Console.WriteLine($"{track.ArtistName} - {track.RecordName} [{track.Recorded}] - {track.Number}. {track.Name} - {track.Length}");
            }
        }

        public async Task GetArtistListAsync(int artistId)
        {
            var tracks = await _tr.GetArtistListAsync(artistId);

            foreach (var track in tracks)
            {
                Console.WriteLine($"{track.Recorded} {track.RecordName} - {track.Number}. {track.Name} - {track.Length}");
            }
        }

        public async Task GetArtistRecordAsync(int artistId, int recordId)
        {
            var tracks = await _tr.GetArtistRecordAsync(artistId, recordId);

            foreach (var track in tracks)
            {
                Console.WriteLine($"{track.Recorded} {track.RecordName} - {track.Number}. {track.Name} - {track.Length}");
            }
        }

        public async Task GetTotalAlbumTimeAsync()
        {
            var totalTime = await _tr.GetTotalAlbumTimeAsync();
    
            Console.WriteLine($"Total Seconds: {totalTime.TotalSeconds} - TotalLength: {totalTime.TotalLengthFormatted}");
        }

        public async Task GetAllSingleTracksAsync()
        {
            var tracks = await _tr.GetAllSingleTracksAsync();

            foreach (var track in tracks)
            {
                Console.WriteLine($"{track.ArtistName} - Id: {track.TrackId} - {track.Recorded} {track.RecordName} - {track.DiscName}. {track.Name} - {track.Length}");
            }
        }

        public async Task GetArtistGuestTracksAsync(string name)
        {
            var tracks = await _tr.GetArtistGuestTracksAsync(name);

            foreach (var track in tracks)
            {
                Console.WriteLine($"{track.Recorded} {track.RecordName} - {track.Number}. {track.FullTrackName} - {track.Length}");
            }
        }

        public async Task GetTrackListingAsync(int discId)
        {
            throw new NotImplementedException();
        }

        public async Task GetRecordTrackListingAsync(int recordId)
        {
            throw new NotImplementedException();
        }

        public async Task GetBriefListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task GetBriefListByYearAsync(int year)
        {
            throw new NotImplementedException();
        }

        public async Task GetHighQualityTracksAsync()
        {
            throw new NotImplementedException();
        }

        public async Task GetHighQualityAlbumsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
