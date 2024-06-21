
namespace Piano.Domain.Models
{
    public class PlayableNote
    {
        public required string Note { get; set; }
        public required int Velocity { get; set; }
        public required int Duration { get; set; }
    }
}
