using R2API;

namespace VanillaRebalance.Items
{
    internal class MiredUrn
    {
        public static void Changes()
        {
            string desc = string.Format("While in combat, the nearest 1 <style=cStack>(+1 per stack) enemies to you within <style=cIsDamage>12m</style> will be 'tethered' to you, dealing <style=cIsDamage>100%</style> damage per second, applying <style=cIsDamage>tar</style>, and <style=cIsDamage>healing you for <style=cIsHealing>100%</style> of the damage dealt.");
            LanguageAPI.Add("ITEM_SIPHONONLOWHEALTH_DESC", desc);
        }
    }
}

