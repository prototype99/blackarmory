using Verse;

namespace BlackArmory
{
    public class CompRainFireOffShoot : ThingComp
    {
        // Convenience property to access the specific CompProperties
        public RainFireOffShoot_CompProperties Props => (RainFireOffShoot_CompProperties)this.props;
    }
}