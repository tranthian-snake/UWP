using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicNewsApp.Models
{
    public class Music
    {
        public string FullName { get; set; }
        public string Name { get; set; }
        public MusicCategory Category { get; set; }
        public string AudioFile { get; set; }
        public string ImageFile { get; set; }

        public Music(string fullName, string name, MusicCategory category)
        {
            FullName = fullName;
            Name = name;
            Category = category;
            AudioFile = string.Format("/Assets/Audio/{0}/{1}.mp3", category, name);
            ImageFile = string.Format("/Assets/Images/{0}/{1}.jpg", category, name);
        }
    }

    public enum MusicCategory
    {
        NhacHoa,
        NhacNhat,
        VietNam,
        Yeuthich
    }
}
