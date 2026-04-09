using MusicDAL.Models;
using MusicDAL.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDAL.Repository
{
    public interface IArtistRepository
    {
        Task<IEnumerable<Artist>> GetArtistsAsync();
        List<Artist> GetArtists();
        Task<List<Artist>> GetArtistListAsync();
        Task<List<Artist>> SelectAsync();
        Task<Artist> SelectAsync(int artistId);
        Task<List<Artist>> SelectArtistWithNoBioAsync();
        Task<int> InsertAsync(Artist artist);
        Task<int> UpdateArtistAsync(Artist artist);
        Task<int> UpdateAsync(int artistId, string firstName, string lastName, string name, string biography);
        Task<int> GetArtistIdAsync(string firstName, string lastName);
        Task<int> GetArtistIdAsync(int recordId);
        Task DeleteAsync(int artistId);
        Task<Artist> GetArtistByRecordIdAsync(int recordId);
        Task<string> GetBiographyAsync(int recordId);
        Task<int> GetArtistCount();
        Task<bool> CheckForArtistNameAsync(string name);
        Task<Artist>GetArtistByFirstLastNameAsync(string firstName, string lastName);
        Task<string> GetBiographyFromRecordIdAsync(int recordId);
        Task<List<ArtistTotalTimeDto>> GetArtistTotalTimesAsync();
        Task<List<ArtistTotalStatisticsDto>> GetArtistTotalStatisticsAsync();
    }
}
