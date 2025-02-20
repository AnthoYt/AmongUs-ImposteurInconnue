using System;
using HarmonyLib;
using UnityEngine;

namespace AmongUsUnknownImpostors.Patches
{
    class LightSabotageFix
    {
        [HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.CalculateLightRadius))]
        public static class ShipStatus_CalculateLightRadius
        {
            public static bool Prefix(ShipStatus __instance, GameData.PlayerInfo playerInfo, ref float __result)
            {
                // Si l'option "Unk impostor" est désactivée, on laisse la méthode originale s'exécuter
                if (!CustomGameOptionsData.customGameOptions.unkImpostor.value) return true;

                // On vérifie que le joueur existe et s'il est mort
                if (playerInfo == null || playerInfo.IsDead)
                {
                    __result = __instance.MaxLightRadius;
                    return false; // On empêche l'exécution de la méthode originale
                }

                // Récupération du système électrique
                if (__instance.Systems[SystemTypes.Electrical] is SwitchSystem switchSystem)
                {
                    // Calcul du facteur d'intensité des lumières basé sur l'état du système électrique
                    float lightFactor = (float)switchSystem.Value / 255f;

                    if (playerInfo.IsImpostor)
                    {
                        // Calcul de la lumière pour les imposteurs
                        __result = Mathf.Lerp(__instance.MinLightRadius, __instance.MaxLightRadius, lightFactor) *
                                   Mathf.Lerp(CustomGameOptionsData.customGameOptions.impoVision.value, PlayerControl.GameOptions.ImpostorLightMod, lightFactor);
                    }
                    else
                    {
                        // Calcul de la lumière pour les membres de l'équipage
                        __result = Mathf.Lerp(__instance.MinLightRadius, __instance.MaxLightRadius, lightFactor) *
                                   PlayerControl.GameOptions.CrewLightMod;
                    }

                    return false; // On empêche l'exécution de la méthode originale
                }

                // Si le système électrique n'est pas valide, on laisse la méthode originale s'exécuter
                return true;
            }
        }
    }
}
