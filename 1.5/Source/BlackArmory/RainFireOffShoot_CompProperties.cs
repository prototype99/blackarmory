using System.Collections.Generic;
using Verse;

namespace BlackArmory
{
  public class RainFireOffShoot_CompProperties : CompProperties
  {
    public List<WeatherDef> FireOffWeather = new List<WeatherDef>();
    //public ThingDef Smoke;
    public int ThickCount = 1;

    public RainFireOffShoot_CompProperties() => this.compClass = typeof (CompRainFireOffShoot);
  }
}
