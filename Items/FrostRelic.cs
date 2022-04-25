using R2API;
using RoR2;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace VanillaRebalance.Items
{
	internal class FrostRelic
	{
		public static void Changes()
		{
			var FrostRelic = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/Icicle/IcicleAura.prefab").WaitForCompletion();
			FrostRelic.GetComponent<IcicleAuraController>().icicleBaseRadius = 8f;
			FrostRelic.GetComponent<IcicleAuraController>().icicleRadiusPerIcicle = 1f;
			FrostRelic.GetComponent<IcicleAuraController>().baseIcicleMax = 8;
			FrostRelic.GetComponent<IcicleAuraController>().icicleMaxPerStack = 8;

			string desc = string.Format("Killing an enemy surrounds you with an <style=cIsDamage>ice storm</style> that deals <style=cIsDamage>300% damage every 0.25s</style> and <style=cIsUtility>slows</style> enemies by <style=cIsUtility>80%</style> for <style=cIsUtility>1.5s</style>. The storm <style=cIsDamage>grows with every kill</style>, increasing its radius by <style=cIsDamage>1m</style>. Stacks up to <style=cIsDamage>16m</style> <style=cStack>(+8m per stack)</style>.");
			LanguageAPI.Add("ITEM_ICICLE_DESC", desc);
		}
	}
}
