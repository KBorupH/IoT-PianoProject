using Piano.Domain.Services;
using Piano.UI.Commands;
using Prism.Commands;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Piano.UI.ViewModels
{
    internal class ManualPlayControlModel
    {
        private IMusicService _musicService;

        public ReactiveCommand<string, Unit> DownCmd { get; }
        public ReactiveCommand<string, Unit> UpCmd { get; }

        public ManualPlayControlModel(IMusicService musicService)
        {
            _musicService = musicService;

            DownCmd = ReactiveCommand.Create<string>(Down);
            UpCmd = ReactiveCommand.Create<string>(Up);
        }

        private void Down(string note)
        {
            _musicService.PlayNote(note);
        }

        private void Up(string note)
        {
            _musicService.StopNote(note);
        }

    }
}
