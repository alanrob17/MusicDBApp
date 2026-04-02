using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDAL.Models
{
    public class Record
    {
        #region " Properties "

        /// <summary>
        /// Gets or sets Record Unique Identifier
        /// </summary>
        public int RecordId { get; set; } // identity field

        /// <summary>
        /// Gets or sets Artist Id
        /// </summary>
        public int ArtistId { get; set; } // relate to the artist entity

        /// <summary>
        /// Gets or sets Record Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the sub title.
        /// </summary>
        public string SubTitle { get; set; }

        /// <summary>
        /// Gets or sets Record Field
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// Gets or sets Record Recorded
        /// </summary>
        public int Recorded { get; set; }

        /// <summary>
        /// Gets or sets Record Discs
        /// </summary>
        public int Discs { get; set; }

        /// <summary>
        /// Gets or sets Record CoverName
        /// </summary>
        public string CoverName { get; set; }

        /// <summary>
        /// Gets or sets Record Review
        /// </summary>
        public string Review { get; set; }

        /// <summary>
        /// Gets or sets the record folder.
        /// </summary>
        public string Folder { get; set; }

        /// <summary>
        /// Gets or sets the length.
        /// </summary>
        public string Length { get; set; }

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        public long Duration { get; set; }

        #endregion

        #region " Methods "

        [ForeignKey(nameof(ArtistId))]
        [InverseProperty("Records")]
        public virtual Artist Artist { get; set; }

        public override string ToString()
        {
            return $"Record Id: {RecordId}, Name: {Name}, Recorded: {Recorded}, Field: {Field}";
        }

        #endregion
    }
}
