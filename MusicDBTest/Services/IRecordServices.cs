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
        Task SelectRecordsAsync();
        Task SelectRecords2Async();
    }
}
