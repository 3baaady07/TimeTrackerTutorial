using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimeTrackerTutorial.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HoursProgressView : ContentView
    {
        public static readonly BindableProperty MaxProperty = BindableProperty.Create(
            nameof(Max), typeof(double), typeof(HoursProgressView), 80.0d);

        public static readonly BindableProperty MinProperty = BindableProperty.Create(
            nameof(Min), typeof(double), typeof(HoursProgressView));

        public static readonly BindableProperty CurrentProperty = BindableProperty.Create(
            nameof(Current), typeof(double), typeof(HoursProgressView));

        public double Max 
        { 
            get => (double)GetValue(MaxProperty); 
            set => SetValue(MaxProperty, value); 
        }

        public double Min
        {
            get => (double)GetValue(MinProperty);
            set => SetValue(MinProperty, value);
        }

        public double Current
        {
            get => (double)GetValue(CurrentProperty);
            set => SetValue(CurrentProperty, value);
        }

        public HoursProgressView()
        {
            InitializeComponent();
        }
    }
}