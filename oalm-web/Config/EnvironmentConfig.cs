using System;

namespace oalm_web.Config
{
    public class EnvironmentConfig
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public String BaseUrl { get; set; }
        public String Browser { get; set; }
        public int ExplicitWaitTime { get; set; }
    }
}