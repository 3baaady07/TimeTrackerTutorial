using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TimeTrackerTutorial.PageModels.Base;
using Xamarin.Forms;

namespace TimeTrackerTutorial.ViewModels
{
    public class LoginOptionViewModel : ExtendedBindableObject
    {
        private Color _backgroundColour;
        public Color BackgroundColour 
        { 
            get => _backgroundColour; 
            set => SetProperty(ref _backgroundColour, value); 
        }

        private string _text;
        public string Text 
        { 
            get => _text; 
            set => SetProperty(ref _text, value); 
        }

        private string _icon;
        public string Icon  
        {
            get => _icon;
            set => SetProperty(ref _icon, value);
        }

        private ICommand _tabCommand;
        public ICommand TabCommand
        {
            get => _tabCommand;
            set => SetProperty(ref _tabCommand, value);
        }

        public LoginOptionViewModel(string text, Action tapAction, Color bgColour, string icon = "")
        {
            Text = text;
            TabCommand = new Command(tapAction);
            BackgroundColour = bgColour;
            Icon = icon;
        }
    }
}
