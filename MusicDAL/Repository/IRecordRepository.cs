using MusicDAL.Models;
using MusicDAL.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDAL.Repository
{
    public interface IRecordRepository
    {
        Task<Record> SelectAsync(int recordId);
        Task<string> CountDiscsAsync(string show);
        Task<string> GetArtistNumberOfRecordsAsync(int artistId);
        Task<List<Record>> SelectAsync();
        List<ArtistRecordDto> Select(string show);
        Task<ArtistRecordDto> GetArtistRecordAsync(int recordId);
        Task<List<Record>> SelectArtistRecordsAsync(int artistId);
        Task<List<Record>> SelectRecordReviewsAsync();
        List<Record> SelectRecordReviews();
        Task<string> GetRecordedYearNumberAsync(int year);
        Task<int> InsertAsync(Record record);
        Task<int> InsertAsync(int artistId, string name, string field, int recorded, string label, string pressing,
            string rating, int discs, string media, DateTime bought, decimal cost, string coverName, string review);
        Task<int> UpdateAsync(int recordId, int artistId, string name, string field, int recorded, string label,
            string pressing, string rating, int discs, string media, DateTime bought, decimal cost, string coverName,
            string review);
        Task<int> UpdateAsync(Record record);
    }
}
