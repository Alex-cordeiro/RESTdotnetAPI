﻿using System.ComponentModel.DataAnnotations.Schema;

namespace RESTdotnetAPI.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }

    }
}
