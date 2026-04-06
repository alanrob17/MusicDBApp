using Dapper;
using Heinemann.Components;
using MusicDAL.Data;
using MusicDAL.Models;
using MusicDAL.Models.Dtos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDAL.Repository
{
    public class RecordRepository : IRecordRepository
    {
        private readonly IDataAccess _db;

        // Parameterless ctor required by ObjectDataSource
        public RecordRepository() : this(new DataAccess()) { }

        public RecordRepository(IDataAccess db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<Record> SelectAsync(int recordId)
        {
            var sproc = "up_GetRecordById";
            var parameter = new DynamicParameters();
            parameter.Add("@RecordId", recordId);

            Record record = await _db.GetDataFirstOrDefault<Record, dynamic>(sproc, parameter);

            return record ?? null;
        }

        public async Task<string> CountDiscsAsync(string show)
        {
            int discs = 0;

            if (show == null)
            {
                throw new ArgumentNullException("show");
            }
            else
            {

                var sproc = "up_CountDiscs";

                var parameter = new DynamicParameters();
                parameter.Add("@Show", show);

                discs = await _db.GetCountOrId(sproc, parameter);

                return discs.ToString(CultureInfo.InvariantCulture);
            }
        }

        public async Task<string> GetArtistNumberOfRecordsAsync(int artistId)
        {
            var discs = 0;
            var sproc = "up_GetArtistNumberOfRecords";
            var parameter = new DynamicParameters();
            parameter.Add("@ArtistId", artistId);

            discs = await _db.GetCountOrId(sproc, parameter);

            return discs.ToString(CultureInfo.InvariantCulture);
        }

        public async Task<List<Record>> SelectAsync()
        {
            var sproc = "up_RecordSelectAll";
            var records = await _db.GetData<Record, dynamic>(sproc, new { });

            return records.ToList();
        }

        public List<ArtistRecordDto> Select(string show)
        {
            var sproc = "up_RecordSelectShowNew";

            var parameter = new DynamicParameters();
            parameter.Add("@Show", show);

            IEnumerable<ArtistRecordDto> albums = _db.GetBrowseData<ArtistRecordDto, dynamic>(sproc, parameter);

            return albums.ToList();
        }

        public Record Select(int recordId)
        {
            var sproc = "up_RecordSelectById";

            var parameter = new DynamicParameters();
            parameter.Add("@RecordId", recordId);

            Record record = _db.GetFirstOrDefault<Record, dynamic>(sproc, parameter);

            return record;
        }

        public async Task<List<Record>> SelectArtistRecordsAsync(int artistId)
        {
            var sproc = "up_getRecordListAndNone";

            var parameter = new DynamicParameters();
            parameter.Add("@ArtistId", artistId);

            var records = await _db.GetData<Record, dynamic>(sproc, parameter);

            return records.ToList();
        }

        public async Task<List<ArtistRecordDto>> SelectRecordReviewsAsync()
        {
            var sproc = "up_SelectRecordReviews";

            var records = await _db.GetData<ArtistRecordDto, dynamic>(sproc, new { });

            return records.ToList();
        }

        public List<ArtistRecordDto> SelectRecordReviews()
        {
            var sproc = "up_SelectRecordReviews2";

            var records = _db.GetBrowseData<ArtistRecordDto, dynamic>(sproc, new { });

            return records.ToList();
        }

        public async Task<string> GetRecordedYearNumberAsync(int year)
        {
            var discs = 0;
            var sproc = "up_GetRecordedYearNumber";

            var parameter = new DynamicParameters();
            parameter.Add("@Year", year);

            discs = await _db.GetCountOrId(sproc, parameter);

            return discs.ToString(CultureInfo.InvariantCulture);
        }

        public async Task<List<ArtistRecordDto>> NoRecordReviewsAsync()
        {
            var sproc = "up_GetNoRecordReview";

            var records = await _db.GetData<ArtistRecordDto, dynamic>(sproc, new { });

            return records.ToList();
        }

        public static string ToShortDate(object bought)
        {
            var shortDate = "unk";

            if (bought != null)
            {
                DateTime dt = Convert.ToDateTime(bought);

                shortDate = Dates.ShortDateString(dt);
            }

            return shortDate;
        }

        public async Task<int> InsertAsync(Record record)
        {
            var recordId = -1; // 0 is used for record is already in the db.
            var sproc = "adm_RecordInsert";

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RecordId", record.RecordId, dbType: DbType.Int32, direction: ParameterDirection.InputOutput);
                parameters.Add("@ArtistId", record.ArtistId);
                parameters.Add("@Name", record.Name);
                parameters.Add("@Field", record.Field);
                parameters.Add("@Recorded", record.Recorded);
                //parameters.Add("@Label", record.Label);
                //parameters.Add("@Pressing", record.Pressing);
                //parameters.Add("@Rating", record.Rating);
                //parameters.Add("@Discs", record.Discs);
                //parameters.Add("@Media", record.Media);
                //parameters.Add("@Bought", record.Bought);
                //parameters.Add("@Cost", record.Cost);
                parameters.Add("@Review", record.Review);

                await _db.SaveData(sproc, parameters);
                recordId = parameters.Get<int>("@RecordId");

                return recordId;
            }
            catch (Exception ex)
            {
                return recordId;
            }
        }

        public async Task<int> InsertAsync(int artistId, string name, string field, int recorded, string label, string pressing, string rating, int discs, string media, DateTime bought, decimal cost, string coverName, string review)
        {
            var recordId = -1; // 0 is used for record is already in the db.
            var sproc = "adm_RecordInsert";

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RecordId", recordId, dbType: DbType.Int32, direction: ParameterDirection.InputOutput);
                parameters.Add("@ArtistId", artistId);
                parameters.Add("@Name", name);
                parameters.Add("@Field", field);
                parameters.Add("@Recorded", recorded);
                parameters.Add("@Label", label);
                parameters.Add("@Pressing", pressing);
                parameters.Add("@Rating", rating);
                parameters.Add("@Discs", discs);
                parameters.Add("@Media", media);
                parameters.Add("@Bought", bought);
                parameters.Add("@Cost", cost);
                parameters.Add("@Review", review);

                await _db.SaveData(sproc, parameters);
                recordId = parameters.Get<int>("@RecordId");

                return recordId;
            }
            catch (Exception ex)
            {
                return recordId;
            }
        }

        public async Task<int> UpdateAsync(int recordId, int artistId, string name, string field, int recorded, string label, string pressing, string rating, int discs, string media, DateTime bought, decimal cost, string coverName, string review)
        {
            var recId = 0;

            try
            {
                string sproc = "adm_UpdateRecord";
                var parameters = new DynamicParameters();
                parameters.Add("@RecordId", recordId);
                parameters.Add("@ArtistId", artistId);
                parameters.Add("@Name", name);
                parameters.Add("@Field", field);
                parameters.Add("@Recorded", recorded);
                parameters.Add("@Label", label);
                parameters.Add("@Pressing", pressing);
                parameters.Add("@Rating", rating);
                parameters.Add("@Discs", discs);
                parameters.Add("@Media", media);
                parameters.Add("@Bought", bought);
                parameters.Add("@Cost", cost);
                parameters.Add("@Review", review);
                // parameters.Add("@Result", result, dbType: DbType.Int32, direction: ParameterDirection.InputOutput);

                await _db.SaveData(sproc, parameters);
                recId = parameters.Get<int>("@RecordId");

                return recId;
            }
            catch (Exception ex)
            {
                return recId;
            }
        }

        public async Task<int> UpdateAsync(Record record)
        {
            var recordId = 0;

            try
            {
                string sproc = "adm_UpdateRecord";
                var parameters = new DynamicParameters();
                parameters.Add("@RecordId", record.RecordId);
                parameters.Add("@ArtistId", record.ArtistId);
                parameters.Add("@Name", record.Name);
                parameters.Add("@Field", record.Field);
                parameters.Add("@Recorded", record.Recorded);
                //parameters.Add("@Label", record.Label);
                //parameters.Add("@Pressing", record.Pressing);
                //parameters.Add("@Rating", record.Rating);
                //parameters.Add("@Discs", record.Discs);
                //parameters.Add("@Media", record.Media);
                //parameters.Add("@Bought", record.Bought);
                //parameters.Add("@Cost", record.Cost);
                parameters.Add("@Review", record.Review);

                await _db.SaveData(sproc, parameters);

                recordId = parameters.Get<int>("@RecordId");

                return recordId;

            }
            catch (Exception ex)
            {
                return recordId;
            }
        }

        public async Task DeleteAsync(int recordId)
        {
            var sproc = "up_deleteRecord";

            try
            {
                var parameter = new DynamicParameters();
                parameter.Add("@RecordId", recordId);

                await _db.SaveData(sproc, parameter);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public async Task<ArtistRecordDto> GetArtistRecordAsync(int recordId)
        {
            string sproc = "up_GetArtistRecordDetails";
            var parameter = new DynamicParameters();
            parameter.Add("@RecordId", recordId);

            var album = await _db.GetDataFirstOrDefault<ArtistRecordDto, dynamic>(sproc, parameter);

            return album ?? null;
        }

        public async Task<List<ArtistRecordDto>> SelectArtistRecordListAsync()
        {
            var sproc = "up_getArtistRecordList";

            var albums = await _db.GetData<ArtistRecordDto, dynamic>(sproc, new { });

            return albums.ToList();
        }

        public async Task<Record> GetRecordByNameAsync(string name)
        {
            var sproc = "up_GetRecordByPartialName";
            var parameter = new DynamicParameters();
            parameter.Add("@Name", name);

            var record = _db.GetFirstOrDefault<Record, dynamic>(sproc, parameter);

            return record;
        }

        public async Task<IEnumerable<Record>> GetRecordsByNameAsync(string name)
        {
            var sproc = "up_GetRecordByPartialName";
            var parameter = new DynamicParameters();
            parameter.Add("@Name", name);

            var records = await _db.GetData<Record, dynamic>(sproc, parameter);

            return records.ToList();
        }

        public async Task<TotalTimeDto> GetTotalAlbumTimeAsync()
        {
            string sproc = "adm_CalculateTotalAlbumTime";
            TotalTimeDto time = await _db.GetDataFirstOrDefault<TotalTimeDto, dynamic>(sproc, new { });

            return time ?? new TotalTimeDto
            {
                TotalSeconds = "0",
                TotalLengthFormatted = "00:00:00:00"
            };
        }

        public async Task<TotalTimeDto> GetTotalAlbumTimeByArtistIdAsync(int artistId)
        {
            string sproc = "adm_CalculateTotalAlbumTimeByArtistId";
            var parameter = new { ArtistId = artistId };
            TotalTimeDto time = await _db.GetDataFirstOrDefault<TotalTimeDto, dynamic>(sproc, parameter);

            return time ?? new TotalTimeDto
            {
                TotalSeconds = "0",
                TotalLengthFormatted = "00:00:00:00"
            };
        }

        public async Task<Artist> GetArtistFromRecordArtistIdAsync(int artistId)
        {
            string sproc = "up_GetArtistFromRecordArtistId";
            var parameter = new { ArtistId = artistId };
            Artist artist = await _db.GetDataFirstOrDefault<Artist, dynamic>(sproc, parameter);

            return artist ?? new Artist
            {
                ArtistId = artistId,
                Name = "Unknown Artist"
            };
        }

        public async Task<Artist> GetArtistFromNameAsync(string name)
        {
            string sproc = "up_GetArtistByName";
            var parameter = new { Name = name };
            Artist artist = await _db.GetDataFirstOrDefault<Artist, dynamic>(sproc, parameter);

            return artist ?? new Artist
            {
                Name = "Unknown Artist"
            };
        }

        public async Task<string> GetArtistNameFromRecordAsync(int recordId)
        {
            var sproc = "up_GetArtistNameByRecordId";
            var parameter = new { RecordId = recordId };
            var name = await _db.GetText(sproc, parameter);
            return name ?? string.Empty;
        }

        public async Task<IEnumerable<ArtistRecordDto>> GetRecordsByRecordedYearAsync(int year)
        {
            var sproc = "up_GetRecordsByYearRecorded";
            var parameter = new { Year = year };
            return await _db.GetData<ArtistRecordDto, dynamic>(sproc, parameter);
        }

        public async Task<ArtistRecordDto> GetRecordDetailsAsync(int recordId)
        {
            var sproc = "up_getSingleArtistAndRecord";
            var parameter = new { RecordId = recordId };
            return await _db.GetDataFirstOrDefault<ArtistRecordDto, dynamic>(sproc, parameter);
        }

        public async Task<ArtistRecordDto> GetRecordHtmlAsync(int recordId)
        {
            var sproc = "up_getSingleArtistAndRecord";
            var parameter = new { RecordId = recordId };
            return await _db.GetDataFirstOrDefault<ArtistRecordDto, dynamic>(sproc, parameter);
        }

        public async Task<string> GetAlbumLengthAsync(int recordId)
        {
            var sproc = "adm_GetAlbumDiscsLength";
            var parameters = new DynamicParameters();
            parameters.Add("@RecordId", recordId);
            return await _db.GetText(sproc, parameters);
        }

        public async Task<ArtistRecordDto> GetAlbumDetailsAsync(int recordId)
        {
            var sproc = "adm_GetAlbumDetails";
            var parameter = new { RecordId = recordId };
            return await _db.GetDataFirstOrDefault<ArtistRecordDto, dynamic>(sproc, parameter);
        }

        public Task<IEnumerable<ArtistRecordDto>> GetNullRecordFieldAsync()
        {
            var sproc = "adm_GetNullRecordField";
            return _db.GetData<ArtistRecordDto, dynamic>(sproc, new { });
        }

        public async Task<IEnumerable<Record>> GetAllRecordFoldersAsync()
        {
            var sproc = "adm_GetRecordFolders";
            return await _db.GetData<Record, dynamic>(sproc, new { });
        }

    }
}
