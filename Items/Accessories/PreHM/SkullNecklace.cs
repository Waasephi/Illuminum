using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories.PreHM
{
	public class SkullNecklace : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Skull Necklace");
			Tooltip.SetDefault("Shoots Bones on taking damage." +
                "\n'Enter the Bone Zone!'");
		}
		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 28;
			Item.value = Item.buyPrice(gold: 10);
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