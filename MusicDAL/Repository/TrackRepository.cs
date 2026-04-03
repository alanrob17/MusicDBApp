using Dapper;
using MusicDAL.Data;
using MusicDAL.Models;
using MusicDAL.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDAL.Repository
{
    public class TrackRepository : ITrackRepository
    {
        private readonly IDataAccess _db;

        // Parameterless ctor required by ObjectDataSource
        public TrackRepository() : this(new DataAccess()) { }

        public TrackRepository(IDataAccess db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<IEnumerable<Track>> GetAllTracksAsync()
        {
            var sproc = "up_TrackSelectAll";
            return await _db.GetData<Track, dynamic>(sproc, new { });
        }

        public async Task<IEnumerable<Track>> GetAllTracksAsync(bool includeTechDetails = true)
        {
            var sproc = "up_CompleteTrackSelectAll";
            return await _db.GetData<Track, dynamic>(sproc, new { IncludeTechnicalDetails = includeTechDetails ? 1 : 0 });
        }

        public Task<IEnumerable<ArtistRecordTrackDto>> GetFullListAsync()
        {
            var sproc = "up_CompleteRecordList";
            return _db.GetData<ArtistRecordTrackDto, dynamic>(sproc, new { });
        }

        public Task<IEnumerable<ArtistRecordTrackDto>> GetArtistListAsync(int artistId)
        {
            var sproc = "up_RecordListByArtist";
            var parameter = new { ArtistId = artistId };
            return _db.GetData<ArtistRecordTrackDto, dynamic>(sproc, parameter);
        }

        public Task<IEnumerable<ArtistRecordTrackDto>> GetArtistRecordAsync(int artistId, int recordId)
        {
            var sproc = "up_ArtistRecordTracks";
            var parameters = new DynamicParameters();
            parameters.Add("@ArtistId", artistId);
            parameters.Add("@RecordId", recordId);
            return _db.GetData<ArtistRecordTrackDto, dynamic>(sproc, parameters);
        }

        public async Task<TotalTimeDto> GetTotalAlbumTimeAsync()
        {
            var sproc = "adm_CalculateTotalAlbumTime";
            TotalTimeDto totalTime = await _db.GetDataFirstOrDefault<TotalTimeDto, dynamic>(sproc, new { });

            return totalTime ?? new TotalTimeDto() { };
        }

        public Task<IEnumerable<ArtistRecordTrackDto>> GetAllSingleTracksAsync()
        {
            var sproc = "adm_GetAlbumsWithOneTrack";
            return _db.GetData<ArtistRecordTrackDto, dynamic>(sproc, new { });
        }

        public Task<IEnumerable<ArtistRecordTrackDto>> GetArtistGuestTracksAsync(string name)
        {
            var sproc = "adm_GetArtistGuestTracks";
            var parameter = new DynamicParameters();
            parameter.Add("@ArtistName", name);
            return _db.GetData<ArtistRecordTrackDto, dynamic>(sproc, parameter);
        }

        public Task<IEnumerable<Track>> GetTrackListingAsync(int discId)
        {
            var sproc = "adm_SelectTracksFromDisc";
            var parameter = new { DiscId = discId };
            return _db.GetData<Track, dynamic>(sproc, parameter);
        }

        public Task<IEnumerable<ArtistRecordTrackDto>> GetRecordTrackListingAsync(int recordId)
        {
            var sproc = "adm_SelectTracksFromRecord";
            var parameter = new { RecordId = recordId };
            return _db.GetData<ArtistRecordTrackDto, dynamic>(sproc, parameter);
        }

        public Task<IEnumerable<Track>> GetBriefListAsync()
        {
            var sproc = "adm_TrackSelectBrief";
            return _db.GetData<Track, dynamic>(sproc, new { });
        }

        public Task<IEnumerable<Track>> GetBriefListByYearAsync(int year)
        {
            var sproc = "adm_TrackSelectBriefByYear";
            var parameter = new { Recorded = year };
            return _db.GetData<Track, dynamic>(sproc, parameter);
        }

        public Task<IEnumerable<ArtistRecordTrackDto>> GetHighQualityTracksAsync()
        {
            var sproc = "up_ArtistRecordHighQualityTracks";
            return _db.GetData<ArtistRecordTrackDto, dynamic>(sproc, new { });
        }

        public Task<IEnumerable<ArtistRecordDto>> GetHighQualityAlbumsAsync()
        {
            var sproc = "up_ArtistHighQualityAlbums";
            return _db.GetData<ArtistRecordDto, dynamic>(sproc, new { });
        }
    }
}
