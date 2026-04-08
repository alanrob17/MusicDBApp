using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDAL.Models.Dtos
{
    public class ArtistTotalTimeDto
    {
        public int ArtistId { get; set; }
        public string Name { get; set; } = string.Empty;
        public long TotalSeconds { get; set; }
        public string TotalLengthFormatted { get; set; } = string.Empty;
    }
}
