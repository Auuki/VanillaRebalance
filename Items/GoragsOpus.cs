using MonoMod.Cil;
using R2API;
using RoR2;
using UnityEngine.AddressableAssets;

namespace VanillaRebalance.Items
{
	internal class GoragsOpus
	{
		public static void Changes()
		{
			IL.RoR2.EquipmentSlot.FireTeamWarCry += (il) =>
			{
				ILCursor ilcursor = new ILCursor(il);
				ilcursor.GotoNext(
					x => x.MatchLdcR4(7f)
					);
				ilcursor.Next.Operand = 8f;

				ilcursor.GotoNext(
					x => x.MatchLdcR4(7f)
					);
				ilcursor.Next.Operand = 8f;
			};

			var GoragsOpus = Addressables.LoadAssetAsync<EquipmentDef>("RoR2/Base/TeamWarCry/TeamWarCry.asset").WaitForCompletion();
			GoragsOpus.cooldown = 60f;

			string desc = string.Format("All allies enter a <style=cIsDamage>frenzy</style> for <style=cIsUtility>8</style> seconds. Increases <style=cIsUtility>movement speed</style> by <style=cIsUtility>50%</style> and <style=cIsDamage>attack speed</style> by <style=cIsDamage>100%</style>.");
			LanguageAPI.Add("EQUIPMENT_TEAMWARCRY_DESC", desc);
		}
	}
}
