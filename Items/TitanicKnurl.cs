using BepInEx.Configuration;
using MonoMod.Cil;
using R2API;
using System;

namespace VanillaRebalance.Items
{
	internal class TitanicKnurl : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("TitanicKnurl", "Enable Changes"), true, new ConfigDescription("Enables changes to Titanic Knurl.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			IL.RoR2.CharacterBody.RecalculateStats += (il) =>
			{
				ILCursor ilcursor = new(il);
				if (ilcursor.TryGotoNext(MoveType.Before,
					x => x.MatchLdcR4(40f)))
				{
					ilcursor.Next.Operand = 50f;
				}

				if (ilcursor.TryGotoNext(MoveType.Before,
					x => x.MatchLdcR4(1.6f)))
				{
					ilcursor.Next.Operand = 2f;
				}
			};


			string desc = string.Format("<style=cIsHealing>Increase maximum health</style> by <style=cIsHealing>50</style> <style=cStack>(+50 per stack)</style> and <style=cIsHealing>base health regeneration</style> by <style=cIsHealing>+2 hp/s</style> <style=cStack>(+2 hp/s per stack)</style>.");
			LanguageAPI.Add("ITEM_KNURL_DESC", desc);
		}
	}
}
