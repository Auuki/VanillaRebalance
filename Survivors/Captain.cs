using BepInEx.Configuration;
using RoR2;
using System;
using UnityEngine.AddressableAssets;

/*namespace VanillaRebalance.Survivors
{
	internal class Captain : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("Captain", "Enable Changes"), true, new ConfigDescription("Enables changes to Captain.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			var Captain = Addressables.LoadAssetAsync<UnityEngine.GameObject>("RoR2/Base/Captain/CaptainBody.prefab").WaitForCompletion();
			SkillLocator sl = Captain.GetComponent<SkillLocator>();
			sl.utility.skillFamily.variants[0].skillDef.baseRechargeInterval = 12f;

			var VulcanShotgun = Addressables.LoadAssetAsync<EntityStateConfiguration>("RoR2/Base/Captain/EntityStates.Captain.Weapon.ChargeCaptainShotgun.asset").WaitForCompletion();
			for (int i = 0; i < VulcanShotgun.serializedFieldsCollection.serializedFields.Length; i++)
			{
				if (VulcanShotgun.serializedFieldsCollection.serializedFields[i].fieldName == "baseChargeDuration")
					VulcanShotgun.serializedFieldsCollection.serializedFields[i].fieldValue.stringValue = "1";
			}

			var VulcanShotgun2 = Addressables.LoadAssetAsync<EntityStateConfiguration>("RoR2/Base/Captain/EntityStates.Captain.Weapon.FireCaptainShotgun.asset").WaitForCompletion();
			for (int i = 0; i < VulcanShotgun2.serializedFieldsCollection.serializedFields.Length; i++)
			{
				if (VulcanShotgun2.serializedFieldsCollection.serializedFields[i].fieldName == "damageCoefficient")
					VulcanShotgun2.serializedFieldsCollection.serializedFields[i].fieldValue.stringValue = "1";
				if (VulcanShotgun2.serializedFieldsCollection.serializedFields[i].fieldName == "procCoefficient")
					VulcanShotgun2.serializedFieldsCollection.serializedFields[i].fieldValue.stringValue = "0.5";
			}

			var PowerTazer = Addressables.LoadAssetAsync<EntityStateConfiguration>("RoR2/Base/Captain/EntityStates.Captain.Weapon.FireTazer.asset").WaitForCompletion();
			for (int i = 0; i < PowerTazer.serializedFieldsCollection.serializedFields.Length; i++)
			{
				if (PowerTazer.serializedFieldsCollection.serializedFields[i].fieldName == "damageCoefficient")
					PowerTazer.serializedFieldsCollection.serializedFields[i].fieldValue.stringValue = "2";
			}
		}
	}
}*/
