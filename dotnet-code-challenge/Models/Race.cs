using System;
using System.Collections.Generic;

namespace dotnet_code_challenge.Models
{
    public class Race
    {
        public string Name { get; set; }

        public int RaceNumber { get; set; }

        public IEnumerable<Horse> Horses { get; set; }
    }
}
