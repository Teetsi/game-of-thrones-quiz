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
    public partial class QuestionsPage : PhoneApplicationPage
    {
        public int questionNumber = -1;

        public QuestionsPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (DataContext == null)
            {
                string selectedIndex = "";
                if (NavigationContext.QueryString.TryGetValue("question", out selectedIndex))
                {
                    questionNumber = int.Parse(selectedIndex);
                    DataContext = App.ViewModel.Items[questionNumber];
                    questionIndex.DataContext = String.Format("{0} / {1}", questionNumber + 1, App.numOfQuestions);

                    if (questionNumber == 0)
                    {
                        App.startTime = DateTime.Now;
                    }
                }
            }

            ButtonPanel.Children.Clear();
            var index = 0;
            foreach (string answer in App.ViewModel.Items[questionNumber].Answers)
            {
                var button = new Button();
                var wrap = new TextBlock();
                index++;
                if (index == App.ViewModel.Items[questionNumber].Correct)
                {
                    button.Tag = 1;
                }
                else
                {
                    button.Tag = 0;
                }
                wrap.TextWrapping = TextWrapping.Wrap;
                wrap.TextAlignment = TextAlignment.Left;
                wrap.Text = answer;
                button.Click += new RoutedEventHandler(GoNextQuestion);
                button.Content = wrap;
                button.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Left;
                ButtonPanel.Children.Add(button);
            }

            // fade out the hearts
            updateHearts(App.numWrongAnswers);
        }


        private void GoNextQuestion(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var value = (int)button.Tag;

            // wrong answer
            if (value == 1)
            {
                App.numWrongAnswers += 1;
                if (App.numWrongAnswers >= App.numLives)
                {
                    NavigationService.Navigate(new Uri("/FailedPage.xaml", UriKind.Relative));
                }
                else
                {
                    button.IsEnabled = false;
                    updateHearts(App.numWrongAnswers);
                }
            }
            // good answer
            else
            {
                SetScore(value);
                if ((questionNumber + 1) < App.numOfQuestions)
                {
                    NavigationService.Navigate(new Uri("/QuestionsPage.xaml?question=" + (questionNumber + 1), UriKind.Relative));
                }
                else
                {
                    NavigationService.Navigate(new Uri("/ResultPage.xaml?score=" + CalcScore(), UriKind.Relative));
                }
            }
        }

        private void updateHearts(int num)
        {
            for (int i = 0; i < num; i++)
            {
                lives.Children[i].Opacity = 0.3;
            }
        }

        private int CalcScore()
        {
            return App.score.Sum();
        }

        private void SetScore(int value)
        {
            App.score[questionNumber] = value;
        }

        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

    }
}