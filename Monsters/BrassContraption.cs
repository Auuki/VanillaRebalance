using BepInEx.Configuration;
using RoR2;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace VanillaRebalance.Monsters
{
	internal class BrassContraption : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("BrassContraption", "Enable Changes"), true, new ConfigDescription("Enables changes to Brass Contraption.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			var BrassContraption = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/Bell/BellBody.prefab").WaitForCompletion();
			BrassContraption.GetComponent<CharacterBody>().baseDamage = 12f;
			BrassContraption.GetComponent<CharacterBody>().levelDamage = 2.4f;

			On.EntityStates.Bell.BellWeapon.ChargeTrioBomb.OnEnter += (orig, self) =>
			{
				EntityStates.Bell.BellWeapon.ChargeTrioBomb.damageCoefficient = 4f;
				orig(self);
			};
		}
	}
}
