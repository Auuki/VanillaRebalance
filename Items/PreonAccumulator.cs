using BepInEx.Configuration;
using R2API;
using RoR2;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace VanillaRebalance.Items
{
	internal class PreonAccumulator : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("PreonAccumulator", "Enable Changes"), true, new ConfigDescription("Enables changes to Preon Accumulator.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			/*var PreonAccumulator = Addressables.LoadAssetAsync<EquipmentDef>("RoR2/Base/BFG/BFG.asset").WaitForCompletion();
			PreonAccumulator.cooldown = 120f;*/

			var PreonAccumulator2 = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/BFG/BeamSphere.prefab").WaitForCompletion();
			PreonAccumulator2.GetComponent<RoR2.Projectile.ProjectileProximityBeamController>().attackRange = 32f;

			//Log.LogInfo("2:" + PreonAccumulator2.GetComponent<RoR2.Projectile.ProjectileProximityBeamController>().damageCoefficient);//2

			string desc = string.Format("Fires preon tendrils, zapping enemies within 32m for up to <style=cIsDamage>1200% damage/second</style>. On contact, detonate in an enormous 20m explosion for <style=cIsDamage>8000% damage</style>.");
			LanguageAPI.Add("ITEM_BFG_DESC", desc);
		}
	}
}
