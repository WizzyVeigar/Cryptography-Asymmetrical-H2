using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography_Asymmetrical_H2
{
    //Class for the RSASender window
    public class RSASenderEncrypt
    {
        private byte[] publicKey;

        public byte[] PublicKey
        {
            get { return publicKey; }
            set { publicKey = value; }
        }

        private byte[] exponent;


        public byte[] Exponent
        {
            get { return exponent; }
            set { exponent = value; }
        }

        public byte[] EncryptData(byte[] dataToEncrypt)
        {
            byte[] cipherbytes;

            RSAParameters parameters = new RSAParameters() { Modulus = PublicKey, Exponent = this.Exponent }; //Take the text in the window and use them as parameters

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.ImportParameters(parameters); //Import the parameters instance into the rsa instance
                cipherbytes = rsa.Encrypt(dataToEncrypt, false);
            }

            return cipherbytes;
        }
    }
}
