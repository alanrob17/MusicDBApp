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
    public class DiscRepository : IDiscRepository
    {
        private readonly IDataAccess _db;

        // Parameterless ctor required by ObjectDataSource
        public DiscRepository() : this(new DataAccess()) { }

        public DiscRepository(IDataAccess db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<IEnumerable<Disc>> GetAllDiscsAsync()
        {
            var sproc = "up_DiscSelectAll";
            return await _db.GetData<Disc, dynamic>(sproc, new { });
        }

        public async Task<IEnumerable<ArtistRecordDiscDto>> GetAllDiscLengthsAsync()
        {
            var sproc = "up_GetAllDiscLengths";
            return await _db.GetData<ArtistRecordDiscDto, dynamic>(sproc, new { });
        }

        public async Task<Disc> GetDiscByIdAsync(int discId)
        {
            var sproc = "adm_getDisc";
            var disc = await _db.GetDataFirstOrDefault<Disc, dynamic>(sproc, new { DiscId = discId });
            return disc ?? throw new KeyNotFoundException($"Disc with ID {discId} not found.");
        }

        public Task<IEnumerable<ArtistRecordDiscDto>> GetLongDiscsAsync()
        {
            var sproc = "adm_GetLongDiscs";
            return _db.GetData<ArtistRecordDiscDto, dynamic>(sproc, new { });
        }

        public Task<IEnumerable<ArtistRecordDiscDto>> GetSingleTrackDiscsAsync()
        {
            var sproc = "adm_GetDiscsWithOneTrack";
            return _db.GetData<ArtistRecordDiscDto, dynamic>(sproc, new { });
        }
    }
}
