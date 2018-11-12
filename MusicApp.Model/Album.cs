using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Model
{
    public class Album
    {
        [Required]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Band { get; set; }
    }
}
