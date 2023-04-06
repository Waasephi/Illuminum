using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Accessories.HM
{
	[AutoloadEquip(EquipType.Shield)]
	public class ViciousMaw : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vicious Maw");
			Tooltip.SetDefault("Grants Immunity to knockback" +
                "\n+7% Damage Reduction" +
                "\nAllows the player to dash into the enemy" +
                "\nDouble tap a direction");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.noKnockback = true;
			player.statDefense += 4;
			player.endurance += 0.07f;
			player.dashType = 2;
		}

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 32;
			Item.value = Item.sellPrice(gold: 5);
			Item.rare = ItemRarityID.Green;
			Item.accessory = true;
			Item.expert = true;
			Item.defense = 4;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod,"UnholyShield");
			recipe.AddIngredient(ItemID.EoCShield); //ShieldofCthulhu
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}