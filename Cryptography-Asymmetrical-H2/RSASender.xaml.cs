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
using System.Windows.Shapes;

namespace Cryptography_Asymmetrical_H2
{
    /// <summary>
    /// Interaction logic for RSASender.xaml
    /// </summary>
    public partial class RSASender : Window
    {
        RSASenderEncrypt rsaSender;
        public RSASender()
        {
            InitializeComponent();
            rsaSender = new RSASenderEncrypt();
        }

        private void btn_Encrypt_Click(object sender, RoutedEventArgs e)
        {
            //Encrypt txt_PlainText with txt_Modulus and txt_Exponent
            rsaSender.PublicKey = Convert.FromBase64String(txt_Modulus.Text);
            rsaSender.Exponent = Convert.FromBase64String(txt_Exponent.Text);
            var encryptedBytes = rsaSender.EncryptData(Encoding.UTF8.GetBytes(txt_PlainText.Text));
            txt_CipherBytes.Text = Convert.ToBase64String(encryptedBytes);
        }
    }

}
