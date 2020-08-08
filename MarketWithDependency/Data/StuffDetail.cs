using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketWithDependency.Data
{
    public class StuffDetail
    {
        [Key]
        public int Id { get; set; }
        public string Size { get; set; }
        public string Weight { get; set; }
        public string Type { get; set; }
        [ForeignKey("StuffId")]
        public Stuff Stuff { get; set; }
        public int StuffId { get; set; }
    }
}
