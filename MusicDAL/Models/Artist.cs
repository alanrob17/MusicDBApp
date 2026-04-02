using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDAL.Models
{
    public class Artist
    {
        #region " Properties "

        /// <summary>
        /// Gets or sets the Artist Unique Identifier
        /// </summary>
        public int ArtistId { get; set; } // identity field

        /// <summary>
        /// Gets or sets Artist first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets Artist last name
        /// </summary>
        public string LastName { get; set; } // not null

        /// <summary>
        /// Gets or sets Artist Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Artist Biography
        /// </summary>
        public string Biography { get; set; }

        /// <summary>
        /// Gets or sets the folder.
        /// </summary>
        public string Folder { get; set; }

        /// <summary>
        /// Gets or sets the record artist id (from RecordDb).
        /// </summary>
        public int RecordArtistId { get; set; }

        #endregion

        #region " Methods "

        [InverseProperty(nameof(Record.Artist))]
        public virtual ICollection<Record> Records { get; set; }

        public override string ToString()
        {
            var biography = string.IsNullOrEmpty(Biography) ? "No Biography" : (Biography.Length > 30 ? Biography.Substring(0, 30) + "..." : Biography);

            return $"Artist Id: {ArtistId}, Artist: {Name}, Biography: {biography}";
        }

        #endregion
    }
}
