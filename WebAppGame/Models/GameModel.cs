namespace WebAppGame.Models
{

    public class RoomModel
    {
        public User User1 { get; set; }
        public User User2 { get; set; }

    }
    public class UserDef
    {
        public string MyName { get; set; }
        public string EnemyName { get; set; }
    }
    public class User
    {
        public string Name { get; set; }
        public bool NeedToInvite { get; set; }
        public User Caller { get; set; }
    }

    public class WaitingRoomModel
    {
        public List<User> Users { get; set; }
    }
}
