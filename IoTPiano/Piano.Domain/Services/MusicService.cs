using PianoUI.Models.Processors;

namespace Piano.Domain.Services
{
    internal class MusicService : IMusicService
    {
        private readonly IProcessor _processor;

        public MusicService(IProcessor processor)
        {
            _processor = processor;
        }

        public void PlayNote(string note)
        {
            _processor.PlayNote(note);
        }
    }
}
