﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCore.Models
{
    public class Block
    {
        [Key]
        public string Hash { get; set; }
        public string PreviousBlockHash { get; set; }




    }
}