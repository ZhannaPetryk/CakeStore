using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreTestWPF.DAL.Models
{
    public class Cake
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Manufacture { get; set; }
        public string Description { get; set; }
        public int PriceInCents { get; set; }
        public string ImagePath { get; set; }
    }
}
