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
            bool shotFired = false;

            var comp = this.EquipmentSource.GetComp<CompRainFireOffShoot>();
            int thickCount = comp.Props.ThickCount;
            List<WeatherDef> fireOffWeather = comp.Props.FireOffWeather;
            //ThingDef smoke = comp.Props.Smoke;

            RoofDef roofDef = this.CasterPawn.Map.roofGrid.RoofAt(this.CasterPawn.Position);

            foreach (WeatherDef weather in fireOffWeather)
            {
                // Check for misfire condition
                if (this.CasterPawn.Map.weatherManager.CurWeatherLerped == weather && roofDef == null)
                {
                    Random rand = new Random();
                    int randomChance = rand.Next(0, 100); // 0-99

                    //Log.Message($"{randomChance}");
                    if (randomChance < 60)
                    {
                        MoteMaker.ThrowText(this.CasterPawn.Position.ToVector3(), this.CasterPawn.Map, "Misfire!".Translate());
                        return shotFired;
                    }
                }
            }

            // Normal shooting process
            if (this.CasterPawn != null && this.CasterIsPawn && base.TryCastShot())
            {
                for (int i = 0; i < thickCount; i++)
                {
                    //GenSpawn.Spawn(smoke, this.CasterPawn.Position, this.CasterPawn.Map);
                    FleckMaker.ThrowSmoke(this.CasterPawn.Position.ToVector3(), this.CasterPawn.Map, 1f);
                    shotFired = true;
                }
            }

            return shotFired;
        }
    }
}