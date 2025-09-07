using System.Collections.Generic;
using Verse;

namespace BlackArmory
{
    public class RainFireOffShoot_CompProperties : CompProperties
    {
        // List of weathers that trigger misfire
        public List<WeatherDef> FireOffWeather = new List<WeatherDef>();

        // Optional smoke effect (currently unused)
        // public ThingDef Smoke;

        // Number of smoke/fleck effects spawned
        public int ThickCount = 1;

        public RainFireOffShoot_CompProperties()
        {
            this.compClass = typeof(CompRainFireOffShoot);
        }
    }
}