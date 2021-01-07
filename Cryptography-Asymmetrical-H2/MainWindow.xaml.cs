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
using System.Security.Cryptography;

namespace Cryptography_Asymmetrical_H2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RSAWithCspKey RSA;

        public MainWindow()
        {
            InitializeComponent();
            RSASender sender = new RSASender();
            sender.Show();

            RSA = new RSAWithCspKey();

            RSA.AssignNewKey();
            SetTextBoxes(RSA.GetKey());
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { 
            txt_Decrypt.Text = Encoding.UTF8.GetString(RSA.DecryptData(Convert.FromBase64String(txt_Cipher.Text)));
        }

        private void SetTextBoxes(RSAParameters pbKey)
        {
            txt_Exponent.Text = Convert.ToBase64String(pbKey.Exponent);
            txt_Modulus.Text = Convert.ToBase64String(pbKey.Modulus);
            txt_D.Text = Convert.ToBase64String(pbKey.D);
            txt_DP.Text = Convert.ToBase64String(pbKey.DP);
            txt_DQ.Text = Convert.ToBase64String(pbKey.DQ);
            txt_InverseQ.Text = Convert.ToBase64String(pbKey.InverseQ);
            txt_P.Text = Convert.ToBase64String(pbKey.P);
            txt_Q.Text = Convert.ToBase64String(pbKey.Q);
        }
    }
}
