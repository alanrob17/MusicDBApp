using MusicDAL.Data;
using MusicDAL.Models;
using MusicDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MusicDAL.Models.Dtos;

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
            await GetAllTracksAsync();
            // await GetAllTracksAsync(true);
            // await GetFullListAsync();
            // await GetArtistListAsync(26);
            // await GetArtistRecordAsync(26, 3322);
            // await GetTotalAlbumTimeAsync();
            // await GetAllSingleTracksAsync();
            // await GetArtistGuestTracksAsync("Bob Dylan");
            // await GetTrackListingAsync(234);
            // await GetRecordTrackListingAsync(175);
            // await GetBriefListAsync();
            // await GetBriefListByYearAsync(1974);
            // await GetHighQualityTracksAsync();
            // await GetHighQualityAlbumsAsync();
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
            IEnumerable<Track> tracks = await _tr.GetTrackListingAsync(discId);

            foreach (var track in tracks)
            {
                Console.WriteLine($"Did: {track.DiscId} - {track.DiscNumber} {track.Name} - {track.Recorded}. {track.Duration} - {track.Media} - {track.Artist} - {track.Album}");
            }
        }

        public async Task GetRecordTrackListingAsync(int recordId)
        {
            var tracks = await _tr.GetRecordTrackListingAsync(recordId);

            foreach (var track in tracks)
            {
                Console.WriteLine($"{track.ArtistName} - {track.RecordName} [{track.Recorded}] - {track.Number}. {track.FullTrackName} - {track.Duration.ToString(@"mm\:ss") ?? "N/A"}");
            }
        }

        public async Task GetBriefListAsync()
        {
            var tracks = await _tr.GetBriefListAsync();

            foreach (var track in tracks)
            {
                Console.WriteLine($"{track.Artist} - {track.Recorded} {track.Album} - {track.Field}. {track.Number} - {track.Name} - {track.Length}");
            }
        }

        public async Task GetBriefListByYearAsync(int year)
        {
            var tracks = await _tr.GetBriefListByYearAsync(year);

            foreach (var track in tracks)
            {
                Console.WriteLine($"{track.Artist} - {track.Recorded} {track.Album} - {track.Field}. {track.Number} - {track.Name} - {track.Length}");
            }
        }

        public async Task GetHighQualityTracksAsync()
        {
            var tracks = await _tr.GetHighQualityTracksAsync();

            foreach (var track in tracks)
            {
                Console.WriteLine($"{track.ArtistName} - {track.RecordName} [{track.Recorded}] - {track.Number}. {track.FullTrackName} - {track.Duration.ToString(@"mm\:ss") ?? "N/A"}");
            }
        }

        public async Task GetHighQualityAlbumsAsync()
        {
            var albums = await _tr.GetHighQualityAlbumsAsync();

            foreach (var album in albums)
            {
                Console.WriteLine($"{album.ArtistName} - {album.Name} [{album.Recorded}] - {album.Field} - {album.Length}");
            }
        }
    }
}
