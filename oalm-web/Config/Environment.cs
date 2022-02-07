using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace oalm_web.Config;

public class Environment
{
    private static Environment _instance;

    private EnvironmentConfig _environmentConfig;

    private Environment()
    {
        String fileContent = File.ReadAllText("config.json");
        String environmentName = GetEnvironmentName();
        List<EnvironmentConfig> environmentConfigs = JsonSerializer.Deserialize<List<EnvironmentConfig>>(fileContent);
        foreach (EnvironmentConfig config in environmentConfigs)
        {
            if (config.TestEnvironment == environmentName)
            {
                _environmentConfig = config;
                break;
            }
        }
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

    private string GetEnvironmentName()
    {
        String environmentName = System.Environment.GetEnvironmentVariable("TestEnvironment");
        Console.WriteLine("===========Current Value from env: " + environmentName);
        if (String.IsNullOrEmpty(environmentName))
        {
            return "QA";
        }

        return environmentName;
    }
}