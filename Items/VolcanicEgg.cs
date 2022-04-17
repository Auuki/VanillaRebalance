using R2API;

namespace VanillaRebalance.Items
{
	internal class VolcanicEgg
	{
		public static void Changes()
		{
			string desc = string.Format("Turn into a <style=cIsDamage>draconic fireball</style> for <style=cIsDamage>5</style> seconds. Deal <style=cIsDamage>500% damage</style> on impact. Detonates at the end for <style=cIsDamage>1000% damage</style>.");
			LanguageAPI.Add("ITEM_FIREBALLDASH_DESC", desc);
		}
	}
}
