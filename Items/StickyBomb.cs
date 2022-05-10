using BepInEx.Configuration;
using RoR2.Projectile;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace VanillaRebalance.Items
{
	internal class StickyBomb : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("StickyBomb", "Enable Changes"), true, new ConfigDescription("Enables changes to Sticky Bomb.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			var StickyBomb = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/StickyBomb/StickyBomb.prefab").WaitForCompletion();
			StickyBomb.GetComponent<ProjectileImpactExplosion>().blastRadius = 12f;
		}
	}
}
