using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StoreTestWPF.DAL.Models
{
    public class Cake: ICloneable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Title { get; set; }
        
        public string Manufacture { get; set; }
        
        public string Description { get; set; }
        
        public decimal Price { get; set; }

        public ICollection<Image> Images { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
