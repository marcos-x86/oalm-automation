using System;
using System.IO;
using System.Text.Json;

namespace oalm_web.Config
{
    public class Environment
    {
        private static Environment _instance;

        private EnvironmentConfig _environmentConfig;

        private Environment()
        {
            String fileContent = File.ReadAllText("config.json");
            _environmentConfig = JsonSerializer.Deserialize<EnvironmentConfig>(fileContent);
        }

        public static EnvironmentConfig Config
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Environment();
                }

                return _instance._environmentConfig;
            }
        }
    }
}