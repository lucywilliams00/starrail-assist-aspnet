using System.ComponentModel.DataAnnotations;

namespace StarrailAssist.Models.Entities
{
    public class AccountCharacter
    {
        public Guid AccountId { get; set; }
        public Guid CharacterId { get; set; }
        public Account Account { get; set; }
        public Character Character { get; set; }
    }
}
