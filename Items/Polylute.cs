using BepInEx.Configuration;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using R2API;
using System;

namespace VanillaRebalance.Items
{
	internal class Polylute : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("Polylute", "Enable Changes"), true, new ConfigDescription("Enables changes to Polylute.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			IL.RoR2.GlobalEventManager.OnHitEnemy += (il) =>
			{
				ILCursor ilcursor = new(il);
				ilcursor.GotoNext(
					x => x.MatchLdcR4(25f),
					x => x.MatchStloc(56)
					);
				ilcursor.Next.Operand = 20f;

				ilcursor.GotoNext(
					x => x.MatchLdloc(59),
					x => x.MatchLdcI4(3)
					);
				ilcursor.Index++;
				ilcursor.Remove();
				ilcursor.Emit(OpCodes.Ldc_I4, 2);
				ilcursor.Index += 2; //removed instruction doesn't count so we only skip 2
				ilcursor.Emit(OpCodes.Ldc_I4, 1);
				ilcursor.Emit(OpCodes.Add);
			};

			string desc = string.Format("<style=cIsDamage>20%</style> chance to fire <style=cIsDamage>lightning</style> for <style=cIsDamage>60%</style> TOTAL damage up to <style=cIsDamage>3</style> <style=cStack>(+2 per stack)</style> times. <style=cIsVoid>Corrupts all Ukuleles</style>.");
			LanguageAPI.Add("ITEM_CHAINLIGHTNINGVOID_DESC", desc);
		}
	}
}
