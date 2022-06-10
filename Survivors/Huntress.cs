using BepInEx.Configuration;
using RoR2;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

/*namespace VanillaRebalance.Survivors
{
	internal class Huntress : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("Huntress", "Enable Changes"), true, new ConfigDescription("Enables changes to Huntress.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			var Flurry = Addressables.LoadAssetAsync<EntityStateConfiguration>("RoR2/Base/Huntress/EntityStates.Huntress.HuntressWeapon.FireFlurrySeekingArrow.asset").WaitForCompletion();
			for (int i = 0; i < Flurry.serializedFieldsCollection.serializedFields.Length; i++)
			{
				if (Flurry.serializedFieldsCollection.serializedFields[i].fieldName == "orbProcCoefficient")
					Flurry.serializedFieldsCollection.serializedFields[i].fieldValue.stringValue = "0.5";
				if (Flurry.serializedFieldsCollection.serializedFields[i].fieldName == "baseDuration")
					Flurry.serializedFieldsCollection.serializedFields[i].fieldValue.stringValue = "1.2";
			}

			var ArrowRain = Addressables.LoadAssetAsync<EntityStateConfiguration>("RoR2/Base/Huntress/EntityStates.Huntress.ArrowRain.asset").WaitForCompletion();
			for (int i = 0; i < ArrowRain.serializedFieldsCollection.serializedFields.Length; i++)
			{
				if (ArrowRain.serializedFieldsCollection.serializedFields[i].fieldName == "arrowRainRadius")
					ArrowRain.serializedFieldsCollection.serializedFields[i].fieldValue.stringValue = "8";
			}

			var ArrowRain2 = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/Huntress/HuntressArrowRain.prefab").WaitForCompletion();
			ArrowRain2.transform.localScale = new Vector3(16f, 16f, 16f);

			var Ballista = Addressables.LoadAssetAsync<EntityStateConfiguration>("RoR2/Base/Huntress/EntityStates.Huntress.AimArrowSnipe.asset").WaitForCompletion();
			for (int i = 0; i < Ballista.serializedFieldsCollection.serializedFields.Length; i++)
			{
				if (Ballista.serializedFieldsCollection.serializedFields[i].fieldName == "damageCoefficient")
					Ballista.serializedFieldsCollection.serializedFields[i].fieldValue.stringValue = "10";
			}

			/*On.EntityStates.Huntress.HuntressWeapon.FireFlurrySeekingArrow.OnEnter += (orig, self) =>
			{
				EntityStates.Huntress.HuntressWeapon.FireFlurrySeekingArrow.orbProcCoefficient
				orig(self);
			};*//*
		}
	}
}*/
