namespace RConDevServer.Protocol.Dice.Battlefield3.Util
{
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    ///     This service is responsible for generating the password hash
    /// </summary>
    public static class PasswordHashService
    {
        public static string GeneratePasswordHash(byte[] saltBytes, string password)
        {
            MD5 md5Hasher = MD5.Create();

            var a_bCombined = new byte[saltBytes.Length + password.Length];
            saltBytes.CopyTo(a_bCombined, 0);
            Encoding.Default.GetBytes(password).CopyTo(a_bCombined, saltBytes.Length);

            byte[] a_bHash = md5Hasher.ComputeHash(a_bCombined);

            var sbStringifyHash = new StringBuilder();
            for (int i = 0; i < a_bHash.Length; i++)
            {
                sbStringifyHash.Append(a_bHash[i].ToString("X2"));
            }

            return sbStringifyHash.ToString();
        }
    }
}