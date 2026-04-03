using MusicDAL.Models;
using MusicDAL.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDAL.Repository
{
    public interface IDiscRepository
    {
        Task<IEnumerable<Disc>> GetAllDiscsAsync();
        Task<IEnumerable<ArtistRecordDiscDto>> GetAllDiscLengthsAsync();
        Task<Disc> GetDiscByIdAsync(int discId);
        Task<IEnumerable<ArtistRecordDiscDto>> GetLongDiscsAsync();
        Task<IEnumerable<ArtistRecordDiscDto>> GetSingleTrackDiscsAsync();
    }
}
