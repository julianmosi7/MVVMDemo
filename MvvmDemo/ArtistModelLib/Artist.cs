using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistModelLib
{
    public class Artist
    {
        public string Name { get; set; }
        public List<Song> Songs { get; set; } = new List<Song>();
        public override string ToString() => Name;

    }
}
