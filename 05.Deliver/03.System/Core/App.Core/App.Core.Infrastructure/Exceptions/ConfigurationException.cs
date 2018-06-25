namespace App
{
    using System;

    public class ConfigurationException : Exception
    {
        public ConfigurationException(string message) : base(message) { }
        public ConfigurationException(string message, Exception innerException) : base(message, innerException) { }
    }
    public class DevelopmentException : Exception
    {
        public DevelopmentException(string message) : base(message) { }
        public DevelopmentException(string message, Exception innerException) : base(message, innerException) { }

    }
}