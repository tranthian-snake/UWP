using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNews.Models
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

            musics.Add(new Music("Lạnh Lẽo (凉凉)", "Trương Bích Thần; Dương Tông Vỹ", "Tam Sinh Tam Thế Thập Lý Đào Hoa(Bản Truyền Hình) OST(三生三世十里桃花 电视剧原声带)", "LanhLeo", MusicCategory.NhacHoa));
            musics.Add(new Music("Một Triệu Khả Năng (一百万个可能)", "Christine Welch", "Một Triệu Khả Năng (一百万个可能)", "MotTrieuKhaNang", MusicCategory.NhacHoa));

            musics.Add(new Music("Yume Wo Kanaete Doraemon", "MAO", "Yume Wo Kanaete Doraemon", "YumeWoKanaeteDoraemon", MusicCategory.NhacNhat));

            musics.Add(new Music("Điều Anh Biết", "Chi Dân", "Điều Anh Biết (Single)", "DieuAnhBiet", MusicCategory.VietNam));
            musics.Add(new Music("Cánh Hoa Tổn Thương", "Hoàng Yến Chibi", "Cánh Hoa Tổn Thương (Single)", "CanhHoaTonThuong", MusicCategory.VietNam));
            musics.Add(new Music("Giang Hải Không Độ Nàng", "Thái Quỳnh", "Giang Hải Không Độ Nàng (Single)", "GiangHaiKhongDoNang", MusicCategory.VietNam));

            musics.Add(new Music("That Girl", "Olly Murs", "24 HRS (Deluxe)", "ThatGirl", MusicCategory.US_UK));
            musics.Add(new Music("Lily", "Alan Walker; K-391; Emelie Hollow", "Different World", "Lily", MusicCategory.US_UK));

            return musics;
        }
    }
}
