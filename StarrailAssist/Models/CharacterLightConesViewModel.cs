using StarrailAssist.Models.Entities;

namespace StarrailAssist.Models
{
    public class CharacterLightConesViewModel
    {
        public Character? Character { get; set; }
        public IQueryable<LightCone>? LightCones { get; set; }
    }
}