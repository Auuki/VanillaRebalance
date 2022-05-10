using BepInEx.Configuration;
using MonoMod.Cil;
using R2API;
using RoR2;
using System;
using UnityEngine.AddressableAssets;

namespace VanillaRebalance.Items
{
	internal class JadeElephant : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("JadeElephant", "Enable Changes"), true, new ConfigDescription("Enables changes to Jade Elephant.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			IL.RoR2.EquipmentSlot.FireGainArmor += (il) =>
			{
				ILCursor ilcursor = new(il);
				ilcursor.GotoNext(
					x => x.MatchLdcR4(5f)
					);
				ilcursor.Next.Operand = 8f;
			};

			IL.RoR2.CharacterBody.RecalculateStats += (il) =>
			{
				ILCursor ilcursor = new(il);
				ilcursor.GotoNext(
					x => x.MatchLdcR4(500f)
					);
				ilcursor.Next.Operand = 200f;
			};

			var JadeElephant = Addressables.LoadAssetAsync<EquipmentDef>("RoR2/Base/GainArmor/GainArmor.asset").WaitForCompletion();
			JadeElephant.cooldown = 60f;

			string desc = string.Format("Gain <style=cIsDamage>200 armor</style> for <style=cIsUtility>8 seconds</style>.");
			LanguageAPI.Add("EQUIPMENT_GAINARMOR_DESC", desc);
		}
	}
}
