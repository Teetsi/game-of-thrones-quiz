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
    public partial class FailedPage : PhoneApplicationPage
    {
        public FailedPage()
        {
            InitializeComponent();
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