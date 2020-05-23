using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CountDownTimer
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private TimeSpan totalSeconds = TimeSpan.FromSeconds(10);
        public MainPage()
        {
            InitializeComponent();
            lblResend.IsEnabled = false;
            startTimer();
        }
        public void startTimer()
        {
            bool returnValue = true;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    returnValue = CountDown();
                });
                return returnValue; 
            });
        }

        private bool CountDown()
        {
            if (totalSeconds.TotalSeconds == 0)
            {
                //do something after hitting 0, in this example it just stops/resets the timer
                lblResend.IsEnabled = true;
                lblResend.TextColor = Color.FromRgb(0, 112, 192);
                lblResend.TextDecorations = TextDecorations.Underline;
                return false;
            }
            else
            {
                totalSeconds = totalSeconds.Subtract(TimeSpan.FromSeconds(1));
                lblCounter.Text = "in " + totalSeconds.ToString(@"mm\:ss") + " sec";
                return true;
            }
        }
        private void lblResend_Tapped(object sender, EventArgs e)
        {
            totalSeconds = TimeSpan.FromSeconds(10);
            lblResend.IsEnabled = false;
            lblResend.TextColor = Color.Gray;
            lblResend.TextDecorations = TextDecorations.None;
            startTimer();
        }
    }
}
