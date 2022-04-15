using MonoMod.Cil;
using R2API;

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

            string desc = string.Format("Gain <style=cIsDamage>500 armor</style> for <style=cIsUtility>8 seconds</style>.");
            LanguageAPI.Add("ITEM_GAINARMOR_DESC", desc);
        }
    }
}
