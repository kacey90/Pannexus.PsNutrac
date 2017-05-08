using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Helper
{
    public static class ClassUtil
    {
        public static string GenerateUniqueKey()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            var byteArray = new byte[4];
            provider.GetBytes(byteArray);

            //convert 4 bytes to an integer
            var randomInteger = BitConverter.ToUInt32(byteArray, 0);

            //var byteArray2 = new byte[8];
            //provider.GetBytes(byteArray2);

            ////convert 8 bytes to a double
            //var randomDouble = BitConverter.ToDouble(byteArray2, 0);

            return randomInteger.ToString();
        }
    }
}
