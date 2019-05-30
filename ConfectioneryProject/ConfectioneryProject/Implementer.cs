﻿using ConfectioneryProject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryShopModel
{
    public class Implementer
    {
        public int Id { get; set; }
        [Required]
        public string ImplementerFIO { get; set; }
        [ForeignKey("ImplementerId")]
        public virtual List<Order> Orders { get; set; }
    }
}
