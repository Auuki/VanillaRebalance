using MonoMod.Cil;
using R2API;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace VanillaRebalance.Items
{
	internal class FocusCrystal
	{
		public static void Changes()
		{
			IL.RoR2.HealthComponent.TakeDamage += (il) =>
			{
				ILCursor ilcursor = new ILCursor(il);
				ilcursor.GotoNext(
					x => x.MatchLdcR4(169f)
					);
				ilcursor.Next.Operand = 144f;
			};

			var FocusCrystal = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/NearbyDamageBonus/NearbyDamageBonusIndicator.prefab").WaitForCompletion();
			float range = 12f / 13f; //get an exact number
			FocusCrystal.transform.localScale = new Vector3(range, range, range);

			string desc = string.Format("Increase damage to enemies within <style=cIsDamage>12m</style> by <style=cIsDamage>20%</style> <style=cStack>(+20% per stack)</style>.");
			LanguageAPI.Add("ITEM_NEARBYDAMAGEBONUS_DESC", desc);
		}
	}
}
