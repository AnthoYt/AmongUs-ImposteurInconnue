using System;
using System.IO;
using System.Linq;
using Hazel;
using LobbyOptionsAPI;
using System.Text;

namespace AmongUsUnknownImpostors.Patches
{
    public class CustomGameOptionsData : LobbyOptions
    {
        private byte settingsVersion = 1;
        public static CustomGameOptionsData customGameOptions;

        public CustomGameOptionsData() : base(UnknownImpostorsPlugin.Id, UnknownImpostorsPlugin.rpcSettingsId)
        {
            unkImpostor = AddOption(false, "Unk impostor");
            impoVision = AddOption(2.0f, "Impostor light off vision", 0.25f, 5.0f, 0.25f, "x");
        }

        public CustomToggleOption unkImpostor;
        public CustomNumberOption impoVision;

        public override void SetRecommendations()
        {
            unkImpostor.value = false;
            impoVision.value = 2.0f;
        }

        public override void Serialize(BinaryWriter writer)
        {
            writer.Write(this.settingsVersion);
            writer.Write(unkImpostor.value);
            writer.Write(impoVision.value);
        }

        public override void Deserialize(BinaryReader reader)
        {
            try
            {
                SetRecommendations();
                byte _ = reader.ReadByte(); // Unused byte (kept for deserialization structure)
                unkImpostor.value = reader.ReadBoolean();
                impoVision.value = reader.ReadSingle();
            }
            catch (Exception ex)
            {
                // Optionally log the error for better debugging
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }
        }

        public override void Deserialize(MessageReader reader)
        {
            try
            {
                SetRecommendations();
                byte _ = reader.ReadByte(); // Unused byte (kept for deserialization structure)
                unkImpostor.value = reader.ReadBoolean();
                impoVision.value = reader.ReadSingle();
            }
            catch (Exception ex)
            {
                // Optionally log the error for better debugging
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }
        }

        public override string ToHudString()
        {
            var settings = new StringBuilder();
            try
            {
                settings.AppendLine();
                settings.AppendLine($"Unk impostor: {unkImpostor.value}");

                if (unkImpostor.value)
                {
                    settings.AppendLine($"Impostor light off vision: {impoVision.value}x");
                }
            }
            catch (Exception ex)
            {
                // Optionally log the error for better debugging
                Console.WriteLine($"Error generating HUD string: {ex.Message}");
            }

            return settings.ToString();
        }
    }
}
