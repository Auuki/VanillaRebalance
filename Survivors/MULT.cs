using BepInEx.Configuration;
using RoR2;
using System;
using UnityEngine.AddressableAssets;

/*namespace VanillaRebalance.Survivors
{
	internal class MULT : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("MULT", "Enable Changes"), true, new ConfigDescription("Enables changes to MUL-T.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			var BlastCanister = Addressables.LoadAssetAsync<EntityStateConfiguration>("RoR2/Base/Toolbot/EntityStates.Toolbot.AimStunDrone.asset").WaitForCompletion();
			for (int i = 0; i < BlastCanister.serializedFieldsCollection.serializedFields.Length; i++)
			{
				if (BlastCanister.serializedFieldsCollection.serializedFields[i].fieldName == "damageCoefficient")
					BlastCanister.serializedFieldsCollection.serializedFields[i].fieldValue.stringValue = "2.5";
			}
		}
	}
}*/
