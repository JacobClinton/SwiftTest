using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SwiftTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /* 
         * MainWindow initializes the window component
         */
        public MainWindow()
        {
            InitializeComponent();
        }

        /*
         * Button_Click is called when the 'Calculate' button is pressed and calculates the length of the given hip
         */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // tests and sets variables taken from text box inputs and coverts to floats
            lengthHE_ErrorLabel.Content = float.TryParse(lengthHE_Text.Text, out float lengthHE) && lengthHE > 0 ? "" : "Please replace with a numerical value above 0";
            angleRS_ErrorLabel.Content = float.TryParse(angleRS_Text.Text, out float angleRS) && angleRS > 0 ? "" : "Please replace with a numerical value above 0";
            angleHE_ErrorLabel.Content = float.TryParse(angleHE_Text.Text, out float angleHE) && angleHE > 0 ? "" : "Please replace with a numerical value above 0";

            // mathmatics to work out the coordinates of the tip of the hip in 3d space relative to the roof's corner
            float x = lengthHE / 2f;
            float z = x * (float) Math.Tan(DegToRad(angleRS));
            float y = z / (float) Math.Tan(DegToRad(angleHE));

            // use 3D Pythagorous Therom to calculate the hip length
            double result = Math.Round(Math.Sqrt(x * x + z * z + y * y), 2);

            // test result against fail cases and outputs the result as text
            result_Text.Content = double.IsNaN(result) || result <= 0 || double.IsInfinity(result) ? "Please fix errors!" : result.ToString() + " m";
        }

        /*
         * DegToRad converts a given angle in degrees into radians
         */
        private float DegToRad(float deg)
        {
            return (deg * (float) Math.PI / 180f);
        }
    }
}
