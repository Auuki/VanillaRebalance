using BepInEx.Configuration;
using RoR2;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace VanillaRebalance.Monsters
{
	internal class BlindVermin : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("BlindVermin", "Enable Changes"), true, new ConfigDescription("Enables changes to Blind Vermin.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			var BlindVermin = Addressables.LoadAssetAsync<GameObject>("RoR2/DLC1/Vermin/VerminBody.prefab").WaitForCompletion();
			BlindVermin.GetComponent<CharacterBody>().baseMoveSpeed = 12f;
		}
	}
}