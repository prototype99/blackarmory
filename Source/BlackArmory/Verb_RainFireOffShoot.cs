using RimWorld;
using System;
using System.Collections.Generic;
using Verse;

namespace BlackArmory
{
  public class Verb_RainFireOffShoot : Verb_Shoot
  {
    protected override bool TryCastShot()
    {
      bool flag = false;
      int thickCount = this.EquipmentSource.GetComp<CompRainFireOffShoot>().Props.ThickCount;
      List<WeatherDef> fireOffWeather = this.EquipmentSource.GetComp<CompRainFireOffShoot>().Props.FireOffWeather;
      //ThingDef smoke = this.EquipmentSource.GetComp<CompRainFireOffShoot>().Props.Smoke;
      RoofDef roofDef = this.CasterPawn.Map.roofGrid.RoofAt(this.CasterPawn.Position);
            foreach (WeatherDef weatherDef in fireOffWeather)
            {               
                    
                    if (this.CasterPawn.Map.weatherManager.CurWeatherLerped == weatherDef && roofDef == null)
                {
                    Random rand = new Random();
                    int RandomChance = rand.Next(0, 100); //returns random number between 0-99                   
                    //Log.Message($"{RandomChance}");                    
                    if (RandomChance < 60)
                    {                        
                    MoteMaker.ThrowText(this.CasterPawn.Position.ToVector3(), this.CasterPawn.Map, (string)"Misfire!".Translate());
                    return flag;
                    }
                }
            }
      if (this.CasterPawn != null && this.CasterIsPawn && base.TryCastShot())
      {
        for (int index = 0; index < thickCount; ++index)
        {
                    //GenSpawn.Spawn(smoke, this.CasterPawn.Position, this.CasterPawn.Map);
                    FleckMaker.ThrowSmoke(this.CasterPawn.Position.ToVector3(), this.CasterPawn.Map, 1f);
                    flag = true;
                }
      }
      return flag;
    }
  }
}
