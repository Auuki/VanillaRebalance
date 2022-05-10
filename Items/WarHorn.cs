using BepInEx.Configuration;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using R2API;
using RoR2;
using System;

namespace VanillaRebalance.Items
{
	internal class WarHorn : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("WarHorn", "Enable Changes"), true, new ConfigDescription("Enables changes to War Horn.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			IL.RoR2.CharacterBody.RecalculateStats += (il) =>
			{
				ILCursor ilcursor = new(il);
				ilcursor.GotoNext(
					x => x.MatchLdloc(83),
					x => x.MatchLdcR4(0.7f)
					);
				ilcursor.Index++;
				ilcursor.Remove();
				ilcursor.Emit(OpCodes.Ldarg_0);
				ilcursor.EmitDelegate<Func<CharacterBody, float>>((body) =>
				{
					int itemCount = body.inventory.GetItemCount(RoR2Content.Items.EnergizedOnEquipmentUse);
					return 0.4f + ((itemCount - 1) * 0.2f);
				});
			};

			string desc = string.Format("Activating your Equipment gives you <style=cIsDamage>+40%</style> <style=cStack>(+20% per stack)</style> <style=cIsDamage>attack speed</style> for <style=cIsDamage>8s</style> <style=cStack>(+4s per stack)</style>.");
			LanguageAPI.Add("ITEM_ENERGIZEDONEQUIPMENTUSE_DESC", desc);
		}
	}
}
