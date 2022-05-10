using BepInEx.Configuration;
using R2API;
using RoR2;
using RoR2.Projectile;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace VanillaRebalance.Items
{
	internal class SingularityBand : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("SingularityBand", "Enable Changes"), true, new ConfigDescription("Enables changes to Singularity Band.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			var SingularityBand = Addressables.LoadAssetAsync<GameObject>("RoR2/DLC1/ElementalRingVoid/ElementalRingVoidBlackHole.prefab").WaitForCompletion();
			SingularityBand.GetComponent<RadialForce>().radius = 16f;
			SingularityBand.GetComponent<ProjectileExplosion>().blastRadius = 16f;
			float range = 16f / 15f;
			SingularityBand.transform.localScale = new Vector3(range, range, range);

			var SingularityBand2 = Addressables.LoadAssetAsync<GameObject>("RoR2/DLC1/ElementalRingVoid/ElementalRingVoidImplodeEffect.prefab").WaitForCompletion();
			SingularityBand2.GetComponent<ShakeEmitter>().radius = 32f;

			string desc = string.Format("Hits that deal <style=cIsDamage>more than 400% damage</style> also fire a black hole that <style=cIsUtility>draws enemies within 16m into its center</style>. Lasts <style=cIsUtility>5</style> seconds before collapsing, dealing <style=cIsDamage>100%</style> <style=cStack>(+100% per stack)</style> TOTAL damage. Recharges every <style=cIsUtility>20</style> seconds. <style=cIsVoid>Corrupts all Runald's and Kjaro's Bands</style>.");
			LanguageAPI.Add("ITEM_ELEMENTALRINGVOID_DESC", desc);
		}
	}
}
