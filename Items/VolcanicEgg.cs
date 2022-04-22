using R2API;
using RoR2;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace VanillaRebalance.Items
{
	internal class VolcanicEgg
	{
		public static void Changes()
		{
			var VolcanicEgg = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/FireBallDash/FireballVehicle.prefab").WaitForCompletion();
			VolcanicEgg.GetComponent<FireballVehicle>().blastDamageCoefficient = 10f;

			string desc = string.Format("Turn into a <style=cIsDamage>draconic fireball</style> for <style=cIsDamage>5</style> seconds. Deal <style=cIsDamage>500% damage</style> on impact. Detonates at the end for <style=cIsDamage>1000% damage</style>.");
			LanguageAPI.Add("EQUIPMENT_FIREBALLDASH_DESC", desc);
		}
	}
}
