using RESTdotnetAPI.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTdotnetAPI.Model
{
    [Table("Books")]
    public class Book : BaseEntity
    {
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
