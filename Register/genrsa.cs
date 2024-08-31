using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace iHuya
{
    public class genrsa
    {
        private static genrsa rsautil_0;

        private byte[] e;

        private byte[] n;

        private RSACryptoServiceProvider rsacryptoServiceProvider_0;

        Chilkat.Rsa rsaEncryptor = new Chilkat.Rsa();

        private genrsa()
        {

           

            //  Encrypted output is always binary.  In this case, we want
            //  to encode the encrypted bytes in a printable string.
            //  Our choices are "hex", "base64", "url", "quoted-printable".
            rsaEncryptor.EncodingMode = "hex";

            //  We'll encrypt with the public key and decrypt with the private
            //  key.  It's also possible to do the reverse.
            bool success = rsaEncryptor.ImportPublicKey("<RSAKeyValue><Modulus>64Q4J5q/2fzqyCXcmpdF52PbWRQ6ivkrZKyGWGr6cN89swLsqJIIFfW6n/iZnSkbTY8rCeI5OIefp9modT/7uQ==</Modulus><Exponent>Aw==</Exponent><P>+vmHOaTRLsyyXT8vzNp6OlXBo058mQyr/M4Bhm0CObE=</P><Q>8Dt0JxkncXIzpRHaBe9r70ngLezua4P+FN6+g0Dr3Ik=</Q><DP>p1EE0RiLdIh26NTKiJGm0Y6BF4moZghyqIlWWZ4Be8s=</DP><DQ>oCeixLtvoPbNGLaRWUpH9NvqyUie8lf+uJR/AitH6Fs=</DQ><InverseQ>pPQleRIolSUART+P999w1hfqcxbbicx1AxDSmVr9ipE=</InverseQ><D>nQLQGmcqkVNHMBk9vGTZRO085g18XKYc7chZkEdRoJOMVAUH8buaj1/QNJ8vN4H2c/ORNE94b+kJUhEUhOFDqw==</D></RSAKeyValue>");

            //rsacryptoServiceProvider_0 = new RSACryptoServiceProvider();
            //rsacryptoServiceProvider_0.FromXmlString();
            /*

            < RSAKeyValue >< Modulus > 64Q4J5q / 2fzqyCXcmpdF52PbWRQ6ivkrZKyGWGr6cN89swLsqJIIFfW6n / iZnSkbTY8rCeI5OIefp9modT / 7uQ ==</ Modulus >< Exponent > Aw ==</ Exponent >< P > +vmHOaTRLsyyXT8vzNp6OlXBo058mQyr / M4Bhm0CObE =</ P >< Q > 8Dt0JxkncXIzpRHaBe9r70ngLezua4P + FN6 + g0Dr3Ik =</ Q >< DP > p1EE0RiLdIh26NTKiJGm0Y6BF4moZghyqIlWWZ4Be8s =</ DP >< DQ > oCeixLtvoPbNGLaRWUpH9NvqyUie8lf + uJR / AitH6Fs =</ DQ >< InverseQ > pPQleRIolSUART + P999w1hfqcxbbicx1AxDSmVr9ipE =</ InverseQ >< D > nQLQGmcqkVNHMBk9vGTZRO085g18XKYc7chZkEdRoJOMVAUH8buaj1 / QNJ8vN4H2c / ORNE94b + kJUhEUhOFDqw ==</ D ></ RSAKeyValue >

            */
            Console.WriteLine("isOK:"+(success?"ok":"false"));
                
           // e = rsacryptoServiceProvider_0.ExportParameters(true).Exponent;
           // n = rsacryptoServiceProvider_0.ExportParameters(true).Modulus;
        }

        public static genrsa getInstance()
        {
            if (rsautil_0 == null)
            {
                rsautil_0 = new genrsa();
            }
            return rsautil_0;
        }

        public byte[] getPublicKey()
        {
            return e;
        }

        public byte[] getModules()
        {
            return n;
        }
        public byte[] encrypt(byte[] rgb)
        {
            try
            {
                return rsacryptoServiceProvider_0.Encrypt(rgb, false);
            }
            catch
            {
                return null;
            }
        }
        public byte[] decrypt(byte[] _arg1)
        {
            try
            {
                return rsaEncryptor.DecryptBytes(_arg1, true);
            }
            catch
            {
                return null;
            }
        }
    }
}
