using System;
using System.Globalization;
using Xamarin.Forms;

namespace Imi.Project.Mobile.Converters
{
    /// <summary>
    /// Ensures the Convert method returns an ItemTappedEventArgs.Items instance instead of the EventArgs.
    /// </summary>
    public class ItemTappedEventArgsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var eventArgs = value as SelectionChangedEventArgs;
            if (eventArgs == null)
                throw new ArgumentException("Expected SelectionChangedEventArgs as value", "value");
            //Item contains the tapped item, in our case this will be a Classmate instance
            return eventArgs.CurrentSelection[0];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException(); //not needed or used
        }
    }

}
