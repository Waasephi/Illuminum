using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories
{
	[AutoloadEquip(EquipType.Back)]
	public class FrozenQuiver : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frozen Quiver");
			Tooltip.SetDefault("Cold to the touch. " +
                "\nGives Frostburn To Ranged Weapons," +
                "\n+20% Arrow Damage, +10% Ranged Damage," +
                "\n20% Chance to not consume ammo.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
			modPlayer.frozenQuiver = true;
			player.arrowDamage *= 1.2f;
			player.GetDamage(DamageClass.Ranged) *= 1.1f;
			player.ammoCost80 = true;
		}

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 30;
			Item.value = Item.sellPrice(gold: 5);
			Item.rare = ItemRarityID.Green;
			Item.accessory = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MagicQuiver);
			recipe.AddIngredient(ItemID.RangerEmblem);
			recipe.AddIngredient(Mod, "FrostStone");
			recipe.AddIngredient(Mod, "MysticArrow");
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}