using System;

namespace oalm_web.Config;

public class EnvironmentConfig
{
    public String TestEnvironment { get; set; }
    public String Username { get; set; }
    public String Password { get; set; }
    public String BaseUrl { get; set; }
    public String Browser { get; set; }
    public int ExplicitWaitTime { get; set; }

    public String DownloadsFolder { get; set; }

    public String GetProjectFolder()
    {
        return System.Environment.CurrentDirectory.Substring(0, 
            System.Environment.CurrentDirectory.IndexOf("bin"));
    }
}