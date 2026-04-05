using MusicDAL.Models;
using MusicDAL.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDBTest.Services
{
    public interface ITrackServices
    {
        Task GetAllTracksAsync();
        Task GetAllTracksAsync(bool includeTechDetails = true);
        Task GetFullListAsync();
        Task GetArtistListAsync(int artistId);
        Task GetArtistRecordAsync(int artistId, int recordId);
        Task GetTotalAlbumTimeAsync();
        Task GetAllSingleTracksAsync();
        Task GetArtistGuestTracksAsync(string name);
        Task GetTrackListingAsync(int discId);
        Task GetRecordTrackListingAsync(int recordId);
        Task GetBriefListAsync();
        Task GetBriefListByYearAsync(int year);
        Task GetHighQualityTracksAsync();
        Task GetHighQualityAlbumsAsync();
    }
}
