using Mono.Cecil.Cil;
using MonoMod.Cil;
using R2API;

namespace VanillaRebalance.Items
{
    internal class WaxQuail
    {
        public static void Changes()
        {
            IL.EntityStates.GenericCharacterMain.ProcessJump += (il) =>
            {
                ILCursor ilcursor = new ILCursor(il);
                ILLabel label = null;
                //var label = ilcursor.DefineLabel();
                ilcursor.GotoNext(
                    x => ILPatternMatchingExt.MatchLdsfld(x, "RoR2.RoR2Content/Items", "JumpBoost")
                    );
                ilcursor.MarkLabel(label);
                ilcursor.Index += 2;
                ilcursor.MarkLabel(label);
                //ILLabel label;
                //ilcursor.Emit(OpCodes.Ldc_I4, value);
                //ilcursor.Emit(OpCodes.Stloc_2);
                //Log.LogInfo(OpCodes.Brfalse.ToString());
                //ilcursor.MarkLabel(label);
                //ilcursor.Emit(OpCodes.Brfalse, ilcursor.GotoLabel(label));
                /*ilcursor.Emit(OpCodes.Brfalse, 
                    ilcursor.GotoNext(
                        x => ILPatternMatchingExt.MatchLdsfld(x, "RoR2.RoR2Content/Items", "JumpBoost")
                    )
                );*/

                //ilcursor.Emit(OpCodes.Ldarg_2);
                ilcursor.Emit(OpCodes.Ldc_I4, 7);
                ilcursor.Emit(OpCodes.Mul);
                //Log.LogInfo(ilcursor.Next.Operand);
                ilcursor.Emit(OpCodes.Brfalse, label);
                //Log.LogInfo(6);
                //ilcursor.Emit(OpCodes.Brfalse, label);
                ilcursor.Emit(OpCodes.Ldc_I4, 7);
                //Log.LogInfo(7);
                ilcursor.Emit(OpCodes.Add);
                //Log.LogInfo(8);
                ilcursor.MarkLabel(label);


                //ilcursor.MarkLabel(label);

                //int quail = 14 + 7 * (int)ilcursor.Next.Operand;
                //object obj = quail;
                //ilcursor.Next.Operand = obj;
                //ilcursor.Next.Operand + 
                //Log.LogInfo(ilcursor.Next.Operand.ToString());

                ilcursor.GotoNext(
                    x => x.MatchLdcR4(10f)
                );
                ilcursor.Next.Operand = 1f;

                //ilcursor.Index++;
                //object obj = ilcursor.Next.Operand;
                /*ilcursor.Remove();
                ilcursor.Emit(OpCodes.Ldloc);
                ilcursor.EmitDelegate<Func<CharacterBody, float>>((cb) =>
                {
                    if (cb.master.inventory)
                    {
                        int quails = cb.master.inventory.GetItemCount(RoR2Content.Items.JumpBoost);
                        if (quails > 0)
                        {
                            return 50 + 100 * quails;
                        }
                    }
                    return 0f;
                });*/
                /*CharacterBody body = new CharacterBody();
                int quails = 0;
                if (body.master.inventory)
                {
                    quails = body.master.inventory.GetItemCount(RoR2Content.Items.JumpBoost);
                    if (quails > 0)
                    {
                       quails = 50 + 100 * quails;
                    }
                }*/
                //float test = 14f + 7f * (float)ilcursor.Next.Operand;
                //object obj = test;
                //ilcursor.Next.Operand = obj;
                //Log.LogInfo(obj);
            };

            string desc = string.Format("Getting hit causes you to explode in a burst of razors, dealing <style=cIsDamage>160%</style> damage. Hits up to <style=cIsDamage>3</style> <style=cStack>(+2 per stack)</style> targets in a <style=cIsDamage>20m</style> <style=cStack>(+2m per stack)</style> radius.");
            LanguageAPI.Add("ITEM_JUMPBOOST_DESC", desc);
        }
    }
}
