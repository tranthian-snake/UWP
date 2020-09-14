using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Models
{
    class FriendManager
    {
        public static List<Friend> GetFriends()
        {
            var friends = new List<Friend>();
            friends.Add(new Friend { Id=1 , Name = "Quynh", Image="Assets/1.jpg" });
            friends.Add(new Friend { Id=2 , Name = "Hanh", Image="Assets/2.jpg" });
            friends.Add(new Friend { Id=3 , Name = "Quynh2", Image="Assets/1.jpg" });
            return friends;
        }
    }
}
