using System;
using System.Collections.Generic;

namespace API.NetGroupProject_Music_.Models
{
    public partial class Favorites
    {
        public int Id { get; set; }
        public string Album { get; set; }
        public string Artist { get; set; }
        public string Track { get; set; }
    }
}
