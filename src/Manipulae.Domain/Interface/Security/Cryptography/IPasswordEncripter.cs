namespace Manipulae.Domain.Interface.Security.Cryptography
{
    public interface IPasswordEncripter
    {
        string Encrypt(string password);
        bool Verify(string password, string passwordHash);
    }
}
