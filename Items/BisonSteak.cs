using BepInEx.Configuration;
using MonoMod.Cil;
using R2API;
using System;

namespace VanillaRebalance.Items
{
	public class BisonSteak : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("BisonSteak", "Enable Changes"), true, new ConfigDescription("Enables changes to Bison Steak.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			IL.RoR2.CharacterBody.RecalculateStats += (il) =>
			{
				ILCursor ilcursor = new(il);
				ilcursor.GotoNext(
					x => x.MatchLdcR4(25f)
					);
				ilcursor.Next.Operand = 30f;
			};

			string pickup = string.Format("Gain <style=cIsHealing>30</style> max health.");
			string desc = string.Format("Increases <style=cIsHealing>maximum health</style> by <style=cIsHealing>30</style> <style=cStack>(+30 per stack)</style>.");
			LanguageAPI.Add("ITEM_FLATHEALTH_PICKUP", pickup);
			LanguageAPI.Add("ITEM_FLATHEALTH_DESC", desc);
		}
	}
}
