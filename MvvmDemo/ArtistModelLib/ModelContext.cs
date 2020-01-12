using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistModelLib
{
    public class ModelContext
    {
        public List<Artist> Artists => new List<Artist>
        {
           GetAristWithSongs("Yello", "Bostich", "Domingo", "I Love You"),
           GetAristWithSongs("OMD", "Enola Gay", "Electricity", "Genetic Engineering"),
           GetAristWithSongs("Ultravox", "Vienna", "The Wall", "Reap The Wild Wind", "Astradyne"),
           GetAristWithSongs("Yazoo", "Don't Go", "Nobody's Diary", "Goodbye Seventies", "Only You")
        };

        private Artist GetAristWithSongs(string artistName, params string[] songNames)
        {
            var artist = new Artist { Name = artistName };
            songNames.ToList()
                     .ForEach(item => artist.Songs.Add(new Song
                     {
                         Name = item,
                         Artist = artist
                     }));
            return artist;
        }
    }
} 