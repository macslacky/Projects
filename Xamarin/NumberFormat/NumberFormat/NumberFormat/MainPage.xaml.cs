using System;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace NumberFormat
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnClickFormatta(object send, EventArgs e)
        {
            int carPunto, maxDigit;
            double depoNum;
            String strDepo1;
            Boolean flagErr = true;

            // reads the maximum number of digits that can be displayed
            maxDigit = int.Parse(edtCifre.Text);

            // the number entered is stored in the local variable
            strDepo1 = edtNumero.Text;

            if (!strDepo1.Contains('.'))
            {
                // the number does not contain the period
                if (strDepo1.Length <= maxDigit)
                {
                    // the number of digits are not higher than expected
                    flagErr = false;
                }
            }
            else if (strDepo1.IndexOf('.') <= maxDigit)
            {
                // the number of digits of the integer part is not more than expected
                flagErr = false;
            }

            if (!flagErr) // the number is viewable
            {
                // maximum number of digits allowed in the fraction part
                carPunto = maxDigit - strDepo1.IndexOf('.');
                maxDigit = strDepo1.Length - strDepo1.IndexOf('.');
                if (carPunto > maxDigit) carPunto = maxDigit - 1;
                // returns the numeric value of the string
                depoNum = double.Parse(edtNumero.Text);

                // format the number
                string depoFormato = "F" + carPunto.ToString();
                lblRisultato.Text = depoNum.ToString(depoFormato, CultureInfo.CreateSpecificCulture("it-IT"));
            }
            else
            {
                lblRisultato.Text = "Errore";
            }
        }
    }
}
