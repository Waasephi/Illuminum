using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories
{
	public class SkullNecklace : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Skull Necklace");
			Tooltip.SetDefault("Shoots Bones on taking damage." +
                "\nEnter the Bone Zone!");
		}
		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 28;
			Item.value = Item.buyPrice(gold: 20);
			Item.value = Item.sellPrice(gold: 5);
			Item.rare = ItemRarityID.Orange;
			Item.accessory = true;
			Item.expert = false;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<IlluminumPlayer>().boneZone = true;
		}
	}
}