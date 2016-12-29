using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;

namespace HelloCDUT.Core.RSAEncrypt
{
    public class RSAEncryptHelper
    {
        private const string PublicKey = 
            @"MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDbESgubbi3LEUxYBJgzQyGHlmC
            +Y64owSgyW2j2dBnI4MqTMAXGNvxc6vUvRdJtABYJCX+8+kHsqfjpnBlGPpLIHBK
            XPXaGaKewoP+EA0TEQkeXBJU6UhshBWcPkHsBraXKn+ktKEmElU/PcX34D6wZWuY
            /GYPyw4GXrUm4wF5yQIDAQAB";

        private static byte[] _btPemModulus = new byte[128];
        private static byte[] _btPemPublicExponent = new byte[3];

        static RSAEncryptHelper()
        {
            //获取modulus和publicExponent
             byte[] btPem = Convert.FromBase64String(PublicKey);
            int pemModulus = 128, pemPublicExponent = 3; 
            for (int i = 0; i < pemModulus; i++)
            {
                _btPemModulus[i] = btPem[29 + i];
            }
            for (int i = 0; i < pemPublicExponent; i++)
            {
                _btPemPublicExponent[i] = btPem[159 + i];
            }
        }
         

        /// <summary>
        /// Decrypt data by public key
        /// </summary>
        /// <param name="encryptedData"></param>
        /// <returns></returns>
        public static string PublicDecrypt(string encryptedData)
        {
            BigInteger biModulus = new BigInteger(1, _btPemModulus);
            BigInteger biExponent = new BigInteger(1, _btPemPublicExponent);
            RsaKeyParameters publicParameters = new RsaKeyParameters(false, biModulus, biExponent);

            IAsymmetricBlockCipher eng = new Pkcs1Encoding(new RsaEngine());
            eng.Init(false, publicParameters);

            byte[] tmp = Convert.FromBase64String(encryptedData);
            tmp = eng.ProcessBlock(tmp, 0, tmp.Length);
            string result = Encoding.UTF8.GetString(tmp, 0, tmp.Length);
            return result;
        }

        /// <summary>
        /// Encrypt data by public key
        /// </summary>
        /// <param name="rawData"></param>
        /// <returns></returns>
        public static string PublicEncrypt(string rawData)
        {
            BigInteger biModulus = new BigInteger(1, _btPemModulus);
            BigInteger biExponent = new BigInteger(1, _btPemPublicExponent);
            RsaKeyParameters publicParameters = new RsaKeyParameters(false, biModulus, biExponent);
            IAsymmetricBlockCipher eng = new Pkcs1Encoding(new RsaEngine());
            eng.Init(true, publicParameters);

            byte[] tmp = Encoding.UTF8.GetBytes(rawData);
            tmp = eng.ProcessBlock(tmp, 0, tmp.Length);
            string result = Convert.ToBase64String(tmp);
            return result;
        }


        /// <summary>
        /// Encrypt data by public key 
        /// </summary>
        /// <param name="rawData"></param>
        /// <returns></returns>
        //        public static string PublicEncrypt(string rawData)
        //        {
        //            try
        //            {
        //                IBuffer bufferRawData = CryptographicBuffer.ConvertStringToBinary(rawData, BinaryStringEncoding.Utf8);

        //                AsymmetricKeyAlgorithmProvider provider = AsymmetricKeyAlgorithmProvider.OpenAlgorithm(AsymmetricAlgorithmNames.RsaPkcs1);

        //                CryptographicKey publicKey = provider.ImportPublicKey(CryptographicBuffer.DecodeFromBase64String(PublicKey));

        //                IBuffer resultBuffer = CryptographicEngine.Encrypt(publicKey, bufferRawData, null);

        //                byte[] res;
        //                CryptographicBuffer.CopyToByteArray(resultBuffer, out res);

        //                string result = Convert.ToBase64String(res);
        //#if DEBUG
        //                System.Diagnostics.Debug.WriteLine("After PublicEncrypt : " + result);
        //#endif
        //                return result;
        //            }
        //            catch(Exception e)
        //            {
        //#if DEBUG
        //                System.Diagnostics.Debug.WriteLine("RSAEncryptHelper.PublicEncrypt : " + e.Message);
        //#endif
        //                return rawData;
        //            }
        //        }
    }
}
