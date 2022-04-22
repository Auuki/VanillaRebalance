using MonoMod.Cil;
using R2API;
using RoR2;
using UnityEngine.AddressableAssets;

namespace VanillaRebalance.Items
{
	internal class JadeElephant
	{
		public static void Changes()
		{
			IL.RoR2.EquipmentSlot.FireGainArmor += (il) =>
			{
				ILCursor ilcursor = new ILCursor(il);
				ilcursor.GotoNext(
					x => x.MatchLdcR4(5f)
					);
				ilcursor.Next.Operand = 8f;
			};

			IL.RoR2.CharacterBody.RecalculateStats += (il) =>
			{
				ILCursor ilcursor = new ILCursor(il);
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
