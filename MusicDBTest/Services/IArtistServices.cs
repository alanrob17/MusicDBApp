using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDBTest.Services
{
    public interface IArtistServices
    {
        Task RunArtistServices();
        Task GetArtistsAsync();
        Task GetArtists();
        Task GetArtistListAsync();
        Task ShowArtistsAsync();
        Task SelectAsync();
        Task GetArtistNamesAsync();
        Task GetSingleArtistAsync(int artistId);
        Task SelectArtistWithNoBioAsync();
        Task GetArtistIdByNameAsync();
        Task GetArtistIdByRecordIdAsync();
        Task ShowArtistAsync();
        Task GetBiographyAsync();
    }
}
