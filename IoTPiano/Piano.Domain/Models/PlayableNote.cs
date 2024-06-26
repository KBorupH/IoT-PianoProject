
namespace Piano.Domain.Models
{
    public class PlayableNote
    {
        public required bool NoteOn { get; set; }
        public required byte Note { get; set; }
        public required byte Velocity { get; set; }
        public required float Time { get; set; }
    }
}
