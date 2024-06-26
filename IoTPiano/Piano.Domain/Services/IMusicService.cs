namespace Piano.Domain.Services
{
    public interface IMusicService
    {
        void PlayNote(string note);
        void StopNote(string note);
    }
}