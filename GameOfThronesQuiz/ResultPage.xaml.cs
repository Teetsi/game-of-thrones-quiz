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
                string scoreText = "";
                int score = 0;
                TimeSpan spentTime = DateTime.Now.Subtract(App.startTime);

                if (NavigationContext.QueryString.TryGetValue("score", out scoreText))
                {
                    score = int.Parse(scoreText);
                    percentageBox.DataContext = (int)((score * 100.0) / App.numOfQuestions) + "%";
                    scoreBox.DataContext = String.Format("{0} of {1} correct", score, App.numOfQuestions);

                    if (score > App.numOfQuestions / 2)
                    {
                        summary.DataContext = "Well done!";
                    }
                    else
                    {
                        summary.DataContext = "Could be better!";
                    }

                    if (spentTime.Hours > 0)
                    {
                        time.DataContext = "Took more than a hour";
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

                        time.DataContext = "Took " + spentTime.ToString(formatString);
                    }

                }
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            App.ViewModel.selectRandomQuestions();
            NavigationService.Navigate(
                new Uri("/QuestionsPage.xaml?question=0", UriKind.Relative));
        }

        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

    }
}