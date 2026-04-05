using MusicDAL.Models;
using MusicDAL.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDBTest.Services
{
    public interface IDiscServices
    {
        Task GetAllDiscsAsync();
        Task GetAllDiscLengthsAsync();
        Task GetDiscByIdAsync(int discId);
        Task GetLongDiscsAsync();
        Task GetSingleTrackDiscsAsync();
    }
}
