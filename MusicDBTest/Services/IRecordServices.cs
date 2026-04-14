using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDBTest.Services
{
    public interface IRecordServices
    {
        Task RunRecordServices();
        Task GetRecordAsync();
        Task GetRecord2Async();
        Task GetArtistRecordNumberAsync();
        Task GetFormattedRecordAsync();
        Task SelectRecordsAsync();
        Task SelectRecords2Async();
        void SelectRecordsShow(string show);
        Task SelectRecordsByArtistIdAsync();
        Task SelectRecordReviewsAsync();
        void SelectRecordReviews();
        Task GetRecordedYearNumberAsync();
        Task NoRecordReviewsAsync();
        void ToShortDate();
        Task GetRecordByNameAsync(string name);
        Task GetRecordsByNameAsync(string name);
        Task GetTotalAlbumTimeAsync();
        Task GetTotalTimeByArtistIdAsync(int artistId);
        Task GetArtistFromArtistNameAsync(string name);
        Task CountDiscsAsync(string show);
        Task GetArtistNameFromRecordAsync(int recordId);
        Task GetRecordListByYearAsync(int year);
        Task GetRecordDetailsAsync(int recordId);
        Task GetRecordHtmlAsync(int recordId);
        Task GetAlbumLengthAsync(int recordId);
        Task GetAlbumDetailsAndLengthAsync(int recordId);
        Task GetNullRecordField();
        Task GetAllRecordFoldersAsync();
        Task GetTotalDiscNumberAsync();
    }
}
