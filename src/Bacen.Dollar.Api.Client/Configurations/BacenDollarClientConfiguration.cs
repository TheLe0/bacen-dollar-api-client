using Bacen.Dollar.Api.Client.Resources;

namespace Bacen.Dollar.Api.Client.Configurations
{
    public class BacenDollarClientConfiguration
    {
        public string BaseUrl { get; set; }
        public bool ThrowOnAnyError { get; set; }
        public int MaxTimeout { get; set; }

        public BacenDollarClientConfiguration(string baseUrl)
        {
            BaseUrl = baseUrl;

            SetupDefaultConfigs();
        }

        public BacenDollarClientConfiguration()
        {
            BaseUrl = Routes.BaseUrl;

            SetupDefaultConfigs();
        }

        private void SetupDefaultConfigs()
        {
            MaxTimeout = 10000;
            ThrowOnAnyError = true;
        }
    }
}
