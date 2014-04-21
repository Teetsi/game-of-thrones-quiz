using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace GameOfThronesQuiz.ViewModels
{
    public class QuestionViewModel : INotifyPropertyChanged
    {

        private int _id;
        /// <summary>
        /// Sample ViewModel property; this property is used to identify the object.
        /// </summary>
        /// <returns></returns>
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    NotifyPropertyChanged("ID");
                }
            }
        }

        private string _question;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Question
        {
            get
            {
                return _question;
            }
            set
            {
                if (value != _question)
                {
                    _question = value;
                    NotifyPropertyChanged("Question");
                }
            }
        }

        private int _correct;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public int Correct
        {
            get
            {
                return _correct;
            }
            set
            {
                if (value != _correct)
                {
                    _correct = value;
                    NotifyPropertyChanged("Correct");
                }
            }
        }


        private string[] _answers;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string[] Answers
        {
            get
            {
                return _answers;
            }
            set
            {
                if (value != _answers)
                {
                    _answers = value;
                    NotifyPropertyChanged("Answers");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}