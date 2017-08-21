using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoLApp.Models
{
    public class Champion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("champID")]
        public int id { get; set; }
        public string title { get; set; }
        public string key { get; set; }
        public string name { get; set; }
    }

    public class RootChampionDTO
    {
        public string Type { get; set; }
        public string Version { get; set; }
        public Dictionary<string, Champion> Data { get; set; }
    }
}
