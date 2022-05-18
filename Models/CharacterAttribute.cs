using System.ComponentModel.DataAnnotations;

namespace WoD.Models
{
    public class CharacterAttribute
    {
        public int Id { get; set; }

        [Range(1, 5)]
        public int Strength { get; set; }
        [Range(1, 5)]
        public int Dexterity { get; set; }
        [Range(1, 5)]
        public int Stamina { get; set; }
        [Range(1, 5)]
        public int Charisma { get; set; }
        [Range(1, 5)]
        public int Manipulation { get; set; }
        [Range(1, 5)]
        public int Composure { get; set; }
        [Range(1, 5)]
        public int Intelligence { get; set; }
        [Range(1, 5)]
        public int Wits { get; set; }
        [Range(1, 5)]
        public int Resolve { get; set; }

    }
}
