using NAudio.Midi;
using Newtonsoft.Json;
using PianoProcessor.Models;
using PianoUI.Models.Processors;
using System.Device.Gpio;

namespace PianoProcessor
{
    public class RaspPi : IProcessor
    {
        private readonly GpioController _controller;
        private Dictionary<byte, byte> _notePinoutPairs;
        public RaspPi()
        {
            _controller = new GpioController();
            LoadPins();
           

        }

        /// <summary>
        /// Loads pins for each notes from json, and opens the pin
        /// </summary>
        private void LoadPins()
        {
            //Read Json
            var pinString = File.ReadAllText("NotePinoutPairs.json");
            //Assign to dictionary
            NotePinoutModel notePinoutModel = JsonConvert.DeserializeObject<NotePinoutModel>(pinString);
            _notePinoutPairs = notePinoutModel.NotePinoutPairs;
            //Open each pin
            foreach (var note in _notePinoutPairs)
            {
                _controller.OpenPin(note.Value, PinMode.Output);
            }
            
        }
        public void PlayTest()
        {
            var midiFile = new MidiFile("test.mid");

            foreach (var track in midiFile.Events)
            {
                foreach (var midiEvent in track)
                {
                    if (midiEvent.CommandCode == MidiCommandCode.NoteOn)
                    {
                        var noteEvent = midiEvent as NoteEvent;
                        _controller.Write(_notePinoutPairs[(byte)noteEvent.NoteNumber], PinValue.High);
                        Console.WriteLine(noteEvent.NoteNumber);
                        
                    }
                }
            }
        }
    }
}
