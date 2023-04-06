using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Illuminum.Items.Accessories.PreHM
{
	public class UnholyHeart : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Unholy Heart");
			Tooltip.SetDefault("Taking damage releases mini corruptors to home in on enemies and gives panic and life regeneration" +
                "\n'You can feel it beating... gross...'");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
			modPlayer.unholyHeart = true;
		}

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 36;
			Item.value = Item.buyPrice(0, 5, 0, 0);
			Item.rare = ItemRarityID.Green;
			Item.accessory = true;
			Item.expert = false;
		}
	}
}