using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreTestWPF.DAL.Models
{
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Path { get; set; }

        public Guid CakeId { get; set; }

        [ForeignKey(nameof(CakeId))]
        [Required]
        public Cake Cake { get; set; }
    }
}
