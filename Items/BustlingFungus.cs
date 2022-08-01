using BepInEx.Configuration;
using MonoMod.Cil;
using R2API;
using System;

namespace VanillaRebalance.Items
{
	public class BustlingFungus : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("BustlingFungus", "Enable Changes"), true, new ConfigDescription("Enables changes to Bustling Fungus.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			IL.RoR2.Items.MushroomBodyBehavior.FixedUpdate += (il) =>
			{
				ILCursor ilcursor = new(il);
				if (ilcursor.TryGotoNext(MoveType.After,
					x => x.MatchLdcR4(1.5f),
					x => x.MatchAdd()))
				{
					ilcursor.Next.Operand = 2f;
				}

				if (ilcursor.TryGotoNext(MoveType.Before,
					x => x.MatchLdcR4(0.045f)))
				{
					ilcursor.Next.Operand = 0.04f;
				}

				if (ilcursor.TryGotoNext(MoveType.Before,
					x => x.MatchLdcR4(0.0225f)))
				{
					ilcursor.Next.Operand = 0.02f;
				}
			};

			string desc = string.Format("After standing still for <style=cIsHealing>1</style> second, create a zone that <style=cIsHealing>heals</style> for <style=cIsHealing>4%</style> <style=cStack>(+2% per stack)</style> of your <style=cIsHealing>health</style> every second to all allies within <style=cIsHealing>4m</style> <style=cStack>(+2m per stack)</style>.");
			LanguageAPI.Add("ITEM_MUSHROOM_DESC", desc);
		}
	}
}
