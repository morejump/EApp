using EApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EApp.ViewModels
{
    public class TestLayoutPageViewModel
    {
        IAudio audioService;

        public TestLayoutPageViewModel()
        {
            audioService = DependencyService.Get<IAudio>();
           
        }

        private ICommand _cmdTapPlayButon;
        public ICommand cmdTapPlayButon
        {
            get { return _cmdTapPlayButon = _cmdTapPlayButon ?? new Command(RuncmdTapPlayButon); }

        }
        void RuncmdTapPlayButon(object obj)
        {
            audioService.PlayAudioFile("MySong.mp3");
        }
    }
}
