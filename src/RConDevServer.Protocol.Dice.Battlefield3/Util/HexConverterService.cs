namespace RConDevServer.Protocol.Dice.Battlefield3.Util
{
    using System;

    public static class HexConverterService
    {
        public static byte[] HashToByteArray(string strHexString)
        {
            var a_bReturn = new byte[strHexString.Length/2];
            for (int i = 0; i < a_bReturn.Length; i++)
            {
                a_bReturn[i] = Convert.ToByte(strHexString.Substring(i*2, 2), 16);
            }
            return a_bReturn;
        }
    }
}