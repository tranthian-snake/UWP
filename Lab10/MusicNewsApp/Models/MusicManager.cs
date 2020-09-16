using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicNewsApp.Models
{
    public class MusicManager
    {
        public static void GetAllMusics(ObservableCollection<Music> musics)
        {
            var allMusics = getMusics();
            musics.Clear();
            allMusics.ForEach(p => musics.Add(p));
        }

        public static void GetMusicsByName(ObservableCollection<Music> musics, string name)
        {
            var allMusics = getMusics();
            var filteredMusics = allMusics.Where(p => p.Name == name).ToList();
            musics.Clear();
            filteredMusics.ForEach(p => musics.Add(p));
        }

        public static void GetMusicsByCategory(ObservableCollection<Music> musics, MusicCategory musicCategory)
        {
            var allMusics = getMusics();
            var filteredMusics = allMusics.Where(p => p.Category == musicCategory).ToList();
            musics.Clear();
            filteredMusics.ForEach(p => musics.Add(p));
        }

        private static List<Music> getMusics()
        {
            var musics = new List<Music>();

            musics.Add(new Music("Lạnh Lẽo", "LanhLeo", MusicCategory.NhacHoa));
            musics.Add(new Music("", "Cat", MusicCategory.NhacHoa)) ;

            musics.Add(new Music("", "Gun", MusicCategory.NhacNhat));
            musics.Add(new Music("", "Spring", MusicCategory.NhacNhat));

            musics.Add(new Music("", "Clock", MusicCategory.VietNam));
            musics.Add(new Music("","LOL", MusicCategory.VietNam));

            musics.Add(new Music("", "Ship", MusicCategory.Yeuthich));
            musics.Add(new Music("", "Siren", MusicCategory.Yeuthich));

            return musics;
        }
    }
}
