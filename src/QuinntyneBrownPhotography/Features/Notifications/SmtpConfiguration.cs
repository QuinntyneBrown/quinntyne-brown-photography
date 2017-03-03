using System.Configuration;

namespace QuinntyneBrownPhotography.Features.Notifications
{
    public class SmtpConfiguration : ConfigurationSection, ISmtpConfiguration
    {
        [ConfigurationProperty("host", IsRequired = true)]
        public string Host
        {
            get { return (string)this["host"]; }
            set { this["host"] = value; }
        }

        [ConfigurationProperty("port", IsRequired = true)]
        public int Port
        {
            get { return (int)this["port"]; }
            set { this["port"] = value; }
        }

        [ConfigurationProperty("username", IsRequired = true)]
        public string Username
        {
            get { return (string)this["username"]; }
            set { this["username"] = value; }
        }

        [ConfigurationProperty("password", IsRequired = true)]
        public string Password
        {
            get { return (string)this["password"]; }
            set { this["password"] = value; }
        }

        public static SmtpConfiguration Config
        {
            get { return ConfigurationManager.GetSection("smtpConfiguration") as SmtpConfiguration; }
        }
    }
}
