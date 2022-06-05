using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Illuminum.Items.Accessories
{
	public class UnholyHeart : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Unholy Heart");
			Tooltip.SetDefault("Although it looks like a crystal, it beats like a heart... gross..." +
                "\n+5% Damage.");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(10, 8));
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.GetDamage(DamageClass.Generic) *= 1.05f;
		}

		public override void SetDefaults()
		{
			Item.width = 14;
			Item.height = 22;
			Item.value = Item.buyPrice(gold: 10);
			Item.value = Item.sellPrice(gold: 5);
			Item.rare = ItemRarityID.Green;
			Item.accessory = true;
			Item.expert = false;
		}
	}
}