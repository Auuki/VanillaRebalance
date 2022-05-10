using BepInEx.Configuration;
using MonoMod.Cil;
using R2API;
using System;

namespace VanillaRebalance.Items
{
	internal class PredatoryInstincts : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("PredatoryInstincts", "Enable Changes"), true, new ConfigDescription("Enables changes to Predatory Instincts.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			IL.RoR2.CharacterBody.RecalculateStats += (il) =>
			{
				ILCursor ilcursor = new(il);
				ilcursor.GotoNext(
					x => x.MatchLdcR4(0.12f)
					);
				ilcursor.Next.Operand = 0.1f;
			};

			string desc = string.Format("Gain <style=cIsDamage>5% critical chance</style>. <style=cIsDamage>Critical strikes</style> increase <style=cIsDamage>attack speed</style> by <style=cIsDamage>10%</style>. Maximum cap of <style=cIsDamage>30%</style> <style=cStack>(+20% per stack)</style>.");
			LanguageAPI.Add("ITEM_ATTACKSPEEDONCRIT_DESC", desc);
		}
	}
}
