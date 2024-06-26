using NAudio.Midi;
using Newtonsoft.Json;
using PianoProcessor.Models;
using PianoUI.Models.Processors;
using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piano.Processor.Processors
{
    internal class RaspPiCSharp : IProcessor
    {
        private readonly GpioController _controller;
        private Dictionary<string, byte> _notePinoutPairs;
        //Hz for sg90 servo
        private int frequency = 50;
        //Period is one cycle
        private int period;
        double dutyCycleHigh = 10;
        double dutyCycleLow = 5;
        public RaspPiCSharp()
        {
            
            period = 1000/frequency;
            _controller = new GpioController();
            LoadPins();
        }

        /// <summary>
        /// Loads pins for each notes from json, and opens the pin
        /// </summary>
        private void LoadPins()
        {
            //Read Json
            var pinString = File.ReadAllText("RaspNotePinoutPairs.json");
            //Assign to dictionary
            NotePinoutModel notePinoutModel = JsonConvert.DeserializeObject<NotePinoutModel>(pinString);
            _notePinoutPairs = notePinoutModel.NotePinoutPairs;
            //Open each pin
            foreach (var note in _notePinoutPairs)
            {
                _controller.OpenPin(note.Value, PinMode.Output);
            }

        }

        public void PlayNote(string noteMessage)
        {
            SetServoAngle(_controller, _notePinoutPairs[noteMessage], dutyCycleHigh, period);
        }

        public void StopNote(string noteMessage)
        {
            SetServoAngle(_controller, _notePinoutPairs[noteMessage], dutyCycleLow, period);
        }

        public void PlayTest()
        {
            var midiFile = new MidiFile("test.mid");

            foreach (var track in midiFile.Events)
            {
                foreach (var midiEvent in track)
                {
                    var noteEvent = midiEvent as NoteEvent;
                    switch (midiEvent.CommandCode)
                    {
                        case MidiCommandCode.NoteOn:
                            SetServoAngle(_controller, _notePinoutPairs[noteEvent.NoteNumber.ToString()], dutyCycleHigh, period);
                            break;
                        case MidiCommandCode.NoteOff:
                            SetServoAngle(_controller, _notePinoutPairs[noteEvent.NoteNumber.ToString()], dutyCycleLow, period);
                            break;
                    }
                    Thread.Sleep((int)(noteEvent.AbsoluteTime/1000));
                }
            }
        }

        private void SetServoAngle(GpioController gpioController, int pin, double dutyCycle, int period)
        {
            int highTime = (int)(period * (dutyCycle / 100.0));
            int lowTime = period - highTime;

            gpioController.Write(pin, PinValue.High);
            Thread.Sleep(highTime);
            gpioController.Write(pin, PinValue.Low);
            Thread.Sleep(lowTime);
        }
    }
}
