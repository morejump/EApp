using EApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EApp.CustomControl
{
    public partial class RepeationAudio : ContentView
    {

        // constructor here
        public RepeationAudio()
        {
            InitializeComponent();
        }

        // Properties here
        public static BindableProperty PlayForwardCmdProperty = BindableProperty.Create(
          propertyName: "PlayForwardCmd",
          returnType: typeof(ICommand),
          declaringType: typeof(RepeationAudio),
          defaultValue: null,
          defaultBindingMode: BindingMode.TwoWay
      );

        public ICommand PlayForwardCmd
        {
            get { return (ICommand)GetValue(PlayForwardCmdProperty); }
            set { SetValue(PlayForwardCmdProperty, value); }
        }


        public static BindableProperty PlayBackwardCmdProperty = BindableProperty.Create(
          propertyName: "PlayBackwardCmd",
          returnType: typeof(ICommand),
          declaringType: typeof(RepeationAudio),
          defaultValue: null,
          defaultBindingMode: BindingMode.TwoWay
      );



        public ICommand PlayBackwardCmd
        {
            get { return (ICommand)GetValue(PlayBackwardCmdProperty); }
            set { SetValue(PlayBackwardCmdProperty, value); }
        }


        public static BindableProperty RepeatSentenceCmdProperty = BindableProperty.Create(
          propertyName: "RepeatSentenceCmd",
          returnType: typeof(ICommand),
          declaringType: typeof(RepeationAudio),
          defaultValue: null,
          defaultBindingMode: BindingMode.TwoWay
      );




        public ICommand RepeatSentenceCmd
        {
            get { return (ICommand)GetValue(RepeatSentenceCmdProperty); }
            set { SetValue(RepeatSentenceCmdProperty, value); }
        }


        // when tapping play backward image
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (PlayBackwardCmd.CanExecute(""))
            {
                PlayBackwardCmd.Execute("");
            }
        }
        // when tapping play a sentence image
        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            if (RepeatSentenceCmd.CanExecute(""))
            {
                RepeatSentenceCmd.Execute("");
            }
        }
        // when tapping a playforward image
        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {

            if (PlayForwardCmd.CanExecute(""))
            {
                PlayForwardCmd.Execute("");
            }
        }
    }
}
