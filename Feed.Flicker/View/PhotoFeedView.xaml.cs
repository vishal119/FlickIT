using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using FontAwesome.WPF;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Feed.Flicker.View
{
    /// <summary>
    /// Interaction logic for PhotoFeedView.xaml
    /// </summary>
    public partial class PhotoFeedView : UserControl
    {
        public PhotoFeedView()
        {
           var value = FontAwesomeIcon.FontAwesome; // workaround
            InitializeComponent();
        }
    }
}
