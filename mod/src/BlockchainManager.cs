// BlockchainManager.cs
// Handles unique code and NFT generation for villagers in Heel-Kawn WorldBox Multiplayer Mod

using System;
using System.IO;
using System.Text.Json;

namespace HeelKawnMod
{
	public class BlockchainManager
	{
		private readonly string nftPath = Path.Combine(BepInEx.Paths.ConfigPath, "heelkawn_nfts");

		public BlockchainManager()
		{
			if (!Directory.Exists(nftPath))
				Directory.CreateDirectory(nftPath);
		}

		public string MintVillagerNFT(string username, string villagerId, object metadata)
		{
			var nft = new NFTData
			{
				Username = username,
				VillagerId = villagerId,
				Metadata = metadata,
				MintedAt = DateTime.UtcNow
			};
			var json = JsonSerializer.Serialize(nft, new JsonSerializerOptions { WriteIndented = true });
			var file = Path.Combine(nftPath, $"{villagerId}.json");
			File.WriteAllText(file, json);
			return file;
		}
	}

	public class NFTData
	{
		public string Username { get; set; }
		public string VillagerId { get; set; }
		public object Metadata { get; set; }
		public DateTime MintedAt { get; set; }
	}
}
