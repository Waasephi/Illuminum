using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories.PreHM
{
	public class VialofToxins : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
            IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
			modPlayer.vialofToxins = true;
            if (player.statLife > 100)
			{
				player.AddBuff(BuffID.Poisoned, 2);
                player.GetDamage(DamageClass.Generic).Flat += 3;
            }
            
        }

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 26;
			Item.value = Item.sellPrice(silver: 50);
			Item.rare = ItemRarityID.Blue;
			Item.accessory = true;
			Item.expert = false;
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddIngredient(ItemID.Stinger, 8);
            recipe.AddTile(TileID.Bottles);
            recipe.Register();
        }
    }
}