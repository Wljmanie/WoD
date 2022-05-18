namespace WoD.Models
{
    public class Vampire
    {
        public int Id { get; set; }
        public string WoDUserId { get; set; }

        public virtual WoDUser? WoDUser { get; set; }
    }
}
