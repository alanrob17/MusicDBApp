using Dapper;
using Microsoft.Data.SqlClient;
using MusicDAL.Components;
using MusicDAL.Data;
using MusicDAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDAL.Repository
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly IDataAccess _db;

        // Parameterless ctor required by ObjectDataSource
        public ArtistRepository() : this(new DataAccess()) { }

        public ArtistRepository(IDataAccess db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<IEnumerable<Artist>> GetArtistsAsync()
        {
            string sproc = "up_ArtistSelectAll";
            return await _db.GetData<Artist, dynamic>(sproc, new { });
        }

        // used for ObjectDataSource
        public List<Artist> GetArtists()
        {
            string sproc = "up_ArtistSelectAll";
            IEnumerable<Artist> artists = _db.GetBrowseData<Artist, dynamic>(sproc, new { });

            return artists.ToList();
        }

        public async Task<List<Artist>> GetArtistListAsync()
        {
            string sproc = "up_getArtistListandNone";
            IEnumerable<Artist> artists = await _db.GetData<Artist, dynamic>(sproc, new { });

            return artists.ToList();
        }

        public async Task<List<Artist>> SelectAsync()
        {
            string sproc = "up_ArtistSelectAll";
            IEnumerable<Artist> artists = await _db.GetData<Artist, dynamic>(sproc, new { });

            return artists.ToList();
        }

        public async Task<Artist> SelectAsync(int artistId)
        {
            using (var connection = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                string sproc = "up_ArtistSelectById";
                var parameter = new DynamicParameters();
                parameter.Add("@ArtistId", artistId);

                Artist artist = await _db.GetDataFirstOrDefault<Artist, dynamic>(sproc, parameter);

                return artist ?? null;
            }
        }

        public async Task<List<Artist>> SelectArtistWithNoBioAsync()
        {
            var sproc = "up_selectArtistsWithNoBio";
            var artists = await _db.GetData<Artist, dynamic>(sproc, new { });

            return artists.ToList();
        }

        public async Task<int> InsertAsync(Artist artist)
        {
            var artistId = -1; // 0 is used for record is already in the db.
            string sproc = "adm_ArtistInsert";

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@FirstName", artist.FirstName);
                parameters.Add("@LastName", artist.LastName);
                parameters.Add("@Name", artist.Name);
                parameters.Add("@Biography", artist.Biography);
                parameters.Add("@Result", dbType: DbType.Int32, direction: ParameterDirection.InputOutput);

                artistId = await _db.SaveDataReturnId(sproc, parameters);
                return artistId;
            }
            catch (Exception ex)
            {
                return artistId;
            }
        }

        public async Task<int> InsertAsync(int artistId, string firstName, string lastName, string biography)
        {
            try
            {
                string sproc = "adm_ArtistInsert";
                var parameters = new DynamicParameters();
                parameters.Add("@FirstName", firstName);
                parameters.Add("@LastName", lastName);
                parameters.Add("@Name", null);
                parameters.Add("@Biography", biography);
                parameters.Add("@Result", dbType: DbType.Int32, direction: ParameterDirection.InputOutput);

                artistId = await _db.SaveDataReturnId(sproc, parameters);
                return artistId;
            }
            catch (Exception ex)
            {
                return artistId;
            }
        }

        public async Task<int> UpdateArtistAsync(Artist artist)
        {
            var artistId = -1; // 0 is used for record is already in the db.
            try
            {
                string sproc = "up_UpdateArtist";
                var parameters = new DynamicParameters();
                parameters.Add("@ArtistId", artist.ArtistId);
                parameters.Add("@FirstName", artist.FirstName);
                parameters.Add("@LastName", artist.LastName);
                parameters.Add("@Name", artist.Name);
                parameters.Add("@Biography", artist.Biography);
                parameters.Add("@Result", dbType: DbType.Int32, direction: ParameterDirection.InputOutput);

                artistId = await _db.SaveDataReturnId(sproc, parameters);
                return artistId;
            }
            catch (Exception ex)
            {
                return artistId;
            }
        }

        public async Task<int> UpdateAsync(int artistId, string firstName, string lastName, string name, string biography)
        {
            try
            {
                string sproc = "up_UpdateArtist";
                var parameters = new DynamicParameters();
                parameters.Add("@ArtistId", artistId);
                parameters.Add("@FirstName", firstName);
                parameters.Add("@LastName", lastName);
                parameters.Add("@Name", name);
                parameters.Add("@Biography", biography);
                parameters.Add("@Result", dbType: DbType.Int32, direction: ParameterDirection.InputOutput);

                artistId = await _db.SaveDataReturnId(sproc, parameters);
                return artistId;
            }
            catch (Exception ex)
            {
                return artistId;
            }
        }

        public async Task<int> GetArtistIdAsync(string firstName, string lastName)
        {
            var sproc = "up_getArtistIdByName";
            var parameters = new DynamicParameters();
            parameters.Add("@FirstName", firstName);
            parameters.Add("@LastName", lastName);

            var artistId = await _db.GetCountOrId(sproc, parameters);
            return artistId;
        }

        public async Task<int> GetArtistIdAsync(int recordId)
        {
            string sproc = "up_getArtistIdFromRecordId";
            var parameters = new DynamicParameters();
            parameters.Add("@RecordId", recordId);
            parameters.Add("@ArtistId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _db.GetCountOrId<dynamic>(sproc, parameters);
            int artistId = parameters.Get<int>("@ArtistId");

            return artistId;
        }

        public async Task DeleteAsync(int artistId)
        {
            try
            {
                string sproc = "up_deleteArtist";
                var parameter = new DynamicParameters();
                parameter.Add("@ArtistId", artistId);

                await _db.SaveData(sproc, parameter);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public async Task<Artist> GetArtistByRecordIdAsync(int recordId)
        {
            var sproc = "up_ArtistSelectByRecordId";
            var parameter = new DynamicParameters();
            parameter.Add("@RecordId", recordId);

            Artist artist = await _db.GetDataFirstOrDefault<Artist, dynamic>(sproc, parameter);

            return artist ?? null;
        }

        public async Task<string> GetBiographyAsync(int recordId)
        {
            var sproc = "up_getBiography";

            var parameter = new DynamicParameters();
            parameter.Add("@RecordId", recordId);

            string biography = await _db.GetText<dynamic>(sproc, parameter);

            return biography;
        }

        public string GetBiography(int recordId)
        {
            var sproc = "up_getBiography";

            var parameter = new DynamicParameters();
            parameter.Add("@RecordId", recordId);

            string biography = _db.GetTextField<dynamic>(sproc, parameter);

            return biography;
        }
    }
}
