using MonoMod.Cil;
using R2API;

namespace VanillaRebalance.Items
{
    public class GestureOfTheDrowned
    {
        public static void Changes()
        {
            IL.RoR2.Inventory.CalculateEquipmentCooldownScale += (il) =>
            {
                ILCursor ilcursor = new ILCursor(il);
                ilcursor.GotoNext(
                    x => x.MatchLdcR4(0.5f),
                    x => x.MatchLdcR4(0.85f)
                    );
                ilcursor.Next.Operand = 0.7f;
            };

            string desc = string.Format("<style=cIsUtility>Reduces Equipment cooldown</style> by <style=cIsUtility>30%</style> <style=cStack>(+15% per stack)</style>. Forces your Equipment to <style=cIsUtility>activate</style> whenever it is off <style=cIsUtility>cooldown</style>.");
            LanguageAPI.Add("ITEM_AUTOCASTEQUIPMENT_DESC", desc);
        }
    }
}
