namespace PianoUI.Models.Processors;

public interface IProcessor
{
    public void PlayNote(string note);
    public void StopNote(string note);
}