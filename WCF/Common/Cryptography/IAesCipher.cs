namespace Common.Cryptography
{
    public interface IAesCipher
    {
        string Encrypt(string input);

        string Decrypt(string input);
    }
}