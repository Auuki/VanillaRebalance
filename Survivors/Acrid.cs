using BepInEx.Configuration;
using RoR2;
using System;
using UnityEngine.AddressableAssets;

/*namespace VanillaRebalance.Survivors
{
	internal class Acrid : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("Acrid", "Enable Changes"), true, new ConfigDescription("Enables changes to Acrid.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			var Neurotoxin = Addressables.LoadAssetAsync<EntityStateConfiguration>("RoR2/Base/Croco/EntityStates.Croco.FireSpit.asset").WaitForCompletion();
			for (int i = 0; i < Neurotoxin.serializedFieldsCollection.serializedFields.Length; i++)
			{
				if (Neurotoxin.serializedFieldsCollection.serializedFields[i].fieldName == "damageCoefficient")
					Neurotoxin.serializedFieldsCollection.serializedFields[i].fieldValue.stringValue = "3.2";
			}
		}
	}
}*/
