using BepInEx.Configuration;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using R2API;
using System;

/*namespace VanillaRebalance.Items
{
	internal class WeepingFungus : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("WeepingFungus", "Enable Changes"), true, new ConfigDescription("Enables changes to Weeping Fungus.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			IL.RoR2.MushroomVoidBehavior.FixedUpdate += (il) =>
			{
				ILCursor ilcursor = new(il);
				ilcursor.GotoNext(
					x => x.MatchLdcR4(0.01f)
					);
				ilcursor.Next.Operand = 0.005f;
				ilcursor.Index += 5;
				ilcursor.Emit(OpCodes.Ldc_R4, 0.005f);
				ilcursor.Emit(OpCodes.Add);
			};

			string desc = string.Format("<style=cIsHealing>Heals</style> for <style=cIsHealing>2%</style> <style=cStack>(+2% per stack)</style> of your health every second <style=cIsUtility>while sprinting</style>. <style=cIsVoid>Corrupts all Bustling Fungi</style>.");
			LanguageAPI.Add("ITEM_MUSHROOMVOID_DESC", desc);
		}
	}
}*/
