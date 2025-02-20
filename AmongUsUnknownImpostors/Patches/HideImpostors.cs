using System;
using HarmonyLib;
using UnityEngine;
using UnhollowerBaseLib;

namespace AmongUsUnknownImpostors.Patches
{
    internal class HideImpostors
    {
        // Patch to hide impostors' names in chat
        [HarmonyPatch(typeof(ChatController), nameof(ChatController.AddChat))]
        public static class ChatController_AddChat
        {
            public static void Postfix(ChatController __instance, ref PlayerControl KMCAKLLFNIM)
            {
                PlayerControl sourcePlayer = KMCAKLLFNIM;

                if (sourcePlayer == null || PlayerControl.LocalPlayer == null)
                {
                    return;
                }

                GameData.PlayerInfo data = PlayerControl.LocalPlayer.Data;
                GameData.PlayerInfo data2 = sourcePlayer.Data;
                if (data2 == null || data == null || (data2.IsDead && !data.IsDead))
                {
                    return;
                }

                var activeChildren = __instance.chatBubPool.activeChildren;

                // Cast the last chat bubble to the appropriate type
                ChatBubble chatBubble = activeChildren[activeChildren.Count - 1].Cast<ChatBubble>();

                // Hide impostors' names in chat if the player is an impostor
                if (data2.IsImpostor && data2.Object != PlayerControl.LocalPlayer)
                    chatBubble.NameText.Color = Color.white;
            }
        }

        // Patch to make impostors alone in the intro cutscene
        [HarmonyPatch(typeof(IntroCutscene), nameof(IntroCutscene.BeginImpostor))]
        public static class IntroCutscene_BeginImpostor
        {
            public static void Prefix(IntroCutscene __instance, ref Il2CppSystem.Collections.Generic.List<PlayerControl> KADFCNPGKLO)
            {
                if (!CustomGameOptionsData.customGameOptions.unkImpostor.value) return;

                var yourTeam = KADFCNPGKLO;
                yourTeam.Clear();
                yourTeam.Add(PlayerControl.LocalPlayer);  // Only the local player is considered an impostor
            }
        }

        // Patch to hide other impostors in the meeting HUD
        [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.Method_7))]
        public static class MeetingHud_CreateButton
        {
            public static void Postfix(MeetingHud __instance, GameData.PlayerInfo PPIKPNJEAKJ, ref PlayerVoteArea __result)
            {
                if (!CustomGameOptionsData.customGameOptions.unkImpostor.value) return;

                GameData.PlayerInfo playerInfo = PPIKPNJEAKJ;
                if (playerInfo.IsImpostor && playerInfo.Object != PlayerControl.LocalPlayer)
                    __result.NameText.Color = Color.white;  // Hide impostors' names in the meeting HUD
            }
        }

        // Patch to fix the kill button between impostors
        [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.FindClosestTarget))]
        public static class PlayerControl_FindClosestTarget
        {
            private static int ShipAndObjectsMask = LayerMask.GetMask(new string[] { "Ship", "Objects" });

            public static bool Prefix(PlayerControl __instance, ref PlayerControl __result)
            {
                if (!CustomGameOptionsData.customGameOptions.unkImpostor.value) return true;

                PlayerControl result = null;
                float num = GameOptionsData.KillDistances[Mathf.Clamp(PlayerControl.GameOptions.KillDistance, 0, 2)];
                if (!ShipStatus.Instance) return true;

                Vector2 truePosition = __instance.GetTruePosition();
                for (int i = 0; i < GameData.Instance.AllPlayers.Count; i++)
                {
                    GameData.PlayerInfo playerInfo = GameData.Instance.AllPlayers[i];
                    if (!playerInfo.Disconnected && playerInfo.PlayerId != __instance.PlayerId && !playerInfo.IsDead)
                    {
                        PlayerControl @object = playerInfo.Object;
                        if (@object)
                        {
                            Vector2 vector = @object.GetTruePosition() - truePosition;
                            float magnitude = vector.magnitude;
                            if (magnitude <= num && !PhysicsHelpers.AnyNonTriggersBetween(truePosition, vector.normalized, magnitude, ShipAndObjectsMask))
                            {
                                result = @object;
                                num = magnitude;
                            }
                        }
                    }
                }

                __result = result;
                return false;  // Prevent the original method from executing
            }
        }

        // Patch to set player name color when impostors are chosen
        [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.SetInfected))]
        public static class PlayerControl_RpcSetInfected
        {
            public static void Postfix(PlayerControl __instance, Il2CppStructArray<byte> JPGEIBIBJPJ)
            {
                if (!CustomGameOptionsData.customGameOptions.unkImpostor.value) return;

                var infected = JPGEIBIBJPJ;
                for (int j = 0; j < infected.Length; j++)
                {
                    GameData.PlayerInfo playerById2 = GameData.Instance.GetPlayerById(infected[j]);
                    if (playerById2 != null && playerById2.Object != PlayerControl.LocalPlayer)
                    {
                        playerById2.Object.nameText.Color = Color.white;  // Hide impostors' names in the game
                    }
                }
            }
        }
    }
}
