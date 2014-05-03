using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace GameOfThronesQuiz
{
    public partial class ResultPage : PhoneApplicationPage
    {
        public ResultPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (DataContext == null)
            {
                TimeSpan spentTime = DateTime.Now.Subtract(App.startTime);
                String baseText = "You answered all the question right";

                if (spentTime.Hours > 0)
                {
                    summary.DataContext = baseText + ", it took more than a hour.";
                }
                else
                {
                    var formatString = "";
                    if (spentTime.Minutes > 1)
                    {
                        formatString = "%m' mins '";
                    }
                    else if (spentTime.Minutes == 1)
                    {
                        formatString = "%m' min '";
                    }

                    if (spentTime.Seconds > 1)
                    {
                        formatString += "%s' secs'";
                    }
                    else
                    {
                        formatString += "%s' sec'";
                    }

                    summary.DataContext = baseText + " in " + spentTime.ToString(formatString) + ".";
                }
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            App.ViewModel.selectRandomQuestions();
            App.numWrongAnswers = 0;
            NavigationService.Navigate(
                new Uri("/QuestionsPage.xaml?question=0", UriKind.Relative));
        }

        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

    }
}