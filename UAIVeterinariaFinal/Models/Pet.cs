using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Web;
using UAIVeterinaria.Interfaces;

namespace UAIVeterinaria.Models
{
    public partial class Pet: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public string PhotoUrl { get; set; }
        public Owner Owner { get; set; }
        public HttpPostedFileBase Image { get; set; }
    }

    [MetadataType(typeof(PetMetadata))]
    public partial class Pet
    {
        public class PetMetadata
        {
            [Key]
            public int Id { get; set; }

            [StringLength(50)]
            [Required]
            public string Name { get; set; }

            [Required]
            [ForeignKey("Owner")]
            public int OwnerId { get; set; }

            [NotMapped]
            public Image Image { get; set; }
        }
    }
}