using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace AppRgpEtec.Resources.Converters
{
    public class ByteArrayToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            ImageSource retSouce = null;
            if (value != null)
            {
                byte[] imagemAsBytes = (byte[])value;
                retSouce = ImageSource.FromStream(() => new MemoryStream(imagemAsBytes));
            }
            return retSouce;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
