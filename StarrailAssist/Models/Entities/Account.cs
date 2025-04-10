namespace StarrailAssist.Models.Entities
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Zone { get; set; }
        public List<AccountCharacter> AccountCharacters { get; set; } = new List<AccountCharacter>();
    }
}
