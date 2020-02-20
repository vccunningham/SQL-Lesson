﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SQL_Library {
    public class Major {

        public int Id { get; set; }
        public string Description { get; set; }
        public int MinSAT { get; set; }

        public override string ToString() {
            return $" {Id} | {Description} | {MinSAT}";
        }
    }
}
