
namespace Piano.Domain.Models
{
    public class MusicSheet
    {
        public required string Name { get; set; }
        public required List<PlayableNote> Notes { get; set; }
    }
}
