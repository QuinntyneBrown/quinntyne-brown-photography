namespace QuinntyneBrownPhotography.Security
{
    public interface IEncryptionService
    {
        string TransformPassword(string password);
        string EncryptString(string plainText);
        string DecryptString(string cipherText);
        string EncryptUri(string plainText);
    }
}
