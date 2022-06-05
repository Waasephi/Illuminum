using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Illuminum.Projectiles;

namespace Illuminum.Items.Weapons.Magic
{
	public class EbonduneStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ebondune Staff");
			Tooltip.SetDefault("Spawns Ebondune Bolts around the player, releasing shoots at the cursor.");
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 25;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 10;
			Item.width = 50;
			Item.height = 50;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.autoReuse = true;
			Item.noMelee = true;
			Item.channel = true;
			Item.knockBack = 3;
			Item.value = Item.sellPrice(0, 0, 60, 0);
			Item.shoot = ModContent.ProjectileType<EbonduneBolt>();
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item43;
			Item.shootSpeed = 4f;
		}

		public override bool CanUseItem(Player player)
		{
			// Ensures no more than one spear can be thrown out, use this when using autoReuse
			return player.ownedProjectileCounts[Item.shoot] < 3;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod,"VialofEvil", 8);
			recipe.AddIngredient(ItemID.Sandstone, 75); //Sandstone Block
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}