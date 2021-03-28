using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models {
    public record Waifu {
        [Key]
        public int Id { get; init; }
        public string Name { get; init; }
        public string Source { get; init; }
    }
}
