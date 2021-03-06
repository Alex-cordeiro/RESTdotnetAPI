using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RESTdotnetAPI.Model
{
    [Table("Books")]
    public class Book
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("author")]
        public string Author { get; set; }
        [Column("launch_date")]
        public DateTime Launch_Date { get; set; }
        [Column("price")]
        public float Price { get; set; }
        [Column("title")]
        public string Title { get; set; }

    }
}
