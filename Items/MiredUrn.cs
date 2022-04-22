using R2API;
using RoR2;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace VanillaRebalance.Items
{
	internal class MiredUrn
	{
		public static void Changes()
		{
			var MiredUrn = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/SiphonOnLowHealth/SiphonNearbyBodyAttachment.prefab").WaitForCompletion();
			MiredUrn.GetComponent<SiphonNearbyController>().radius = 12f;

			string desc = string.Format("While in combat, the nearest 1 <style=cStack>(+1 per stack)</style> enemies to you within <style=cIsDamage>12m</style> will be 'tethered' to you, dealing <style=cIsDamage>100%</style> damage per second, applying <style=cIsDamage>tar</style>, and <style=cIsHealing>healing</style> you for <style=cIsHealing>100%</style> of the damage dealt.");
			LanguageAPI.Add("ITEM_SIPHONONLOWHEALTH_DESC", desc);
		}
	}
}

