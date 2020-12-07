namespace TEK.Core.Infrastructure
{
    /// <summary>
    /// Class EncryptingSettings. This class cannot be inherited.
    /// </summary>
    public sealed class EncryptingSettings
    {
        /// <summary>
        /// Gets or sets the encrypting.
        /// </summary>
        /// <value>The encrypting.</value>
        public Encrypting Encrypting { get; set; }
    }

    /// <summary>
    /// Class Encrypting.
    /// </summary>
    public class Encrypting
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the private key.
        /// </summary>
        /// <value>The private key.</value>
        public string PrivateKey { get; set; }
    }
}
