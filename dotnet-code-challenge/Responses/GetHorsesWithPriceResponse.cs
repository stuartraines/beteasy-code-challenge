using System;
using System.Collections.Generic;
using dotnet_code_challenge.Models;

namespace dotnet_code_challenge.Responses
{
    public class GetHorsesWithPriceResponse
    {
        public IEnumerable<Horse> Horses { get; set; }
    }
}
