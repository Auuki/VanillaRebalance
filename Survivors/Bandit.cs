using BepInEx.Configuration;
using RoR2;
using System;
using UnityEngine.AddressableAssets;

/*namespace VanillaRebalance.Survivors
{
	internal class Bandit : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("Bandit", "Enable Changes"), true, new ConfigDescription("Enables changes to Bandit.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			var Blast = Addressables.LoadAssetAsync<EntityStateConfiguration>("RoR2/Base/Bandit2/EntityStates.Bandit2.Weapon.Bandit2FireRifle.asset").WaitForCompletion();
			for (int i = 0; i < Blast.serializedFieldsCollection.serializedFields.Length; i++)
			{
				if (Blast.serializedFieldsCollection.serializedFields[i].fieldName == "damageCoefficient")
					Blast.serializedFieldsCollection.serializedFields[i].fieldValue.stringValue = "3.6";
			}
		}
	}
}*/
