using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography_Asymmetrical_H2
{
    class RSAWithCspKey
    {
        const string containerName = "MyContainer";
        public void AssignNewKey()
        {
            CspParameters cspParams = new CspParameters(1);
            cspParams.KeyContainerName = containerName;
            cspParams.Flags = CspProviderFlags.UseMachineKeyStore;
            cspParams.ProviderName = "Microsoft Strong Cryptographic Provider";

            var rsa = new RSACryptoServiceProvider(cspParams) { PersistKeyInCsp = true }; //Puts it in a key container, lies in RAM
        }

        public RSAParameters GetKey()
        {
            var cspParams = new CspParameters { KeyContainerName = containerName };
            var rsa = new RSACryptoServiceProvider(2048, cspParams);
            return rsa.ExportParameters(true);
        }

        /// <summary>
        /// Deletes the key from RAM
        /// </summary>
        public void DeleteKeyInCsp()
        {
            var cspParams = new CspParameters { KeyContainerName = containerName };
            var rsa = new RSACryptoServiceProvider(cspParams) { PersistKeyInCsp = false };

            rsa.Clear();
        }

        public byte[] DecryptData(byte[] dataToDecrypt)
        {
            byte[] plain;

            var cspParams = new CspParameters { KeyContainerName = containerName };

            using (var rsa = new RSACryptoServiceProvider(2048, cspParams))
            {
                plain = rsa.Decrypt(dataToDecrypt, false);
            }

            return plain;
        }
    }
}
