using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Illuminum.Items.Materials.PreHM;

namespace Illuminum.Items.Weapons.Melee.PreHM
{
	public class QuartzKnife : ModItem
	{
		float shootCD;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Quartz Knife");
			Tooltip.SetDefault("Creates a slash that repels and bleeds enemies.");
		}

		public override void SetDefaults()
		{
			Item.damage = 20;
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.width = 48;
			Item.height = 52;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 5;
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.noUseGraphic = true;
			Item.value = Item.sellPrice(0, 0, 55, 0);
			Item.shoot = Mod.Find<ModProjectile>("QuartzKnife1").Type;
			Item.shootSpeed = 30f;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			position += new Vector2();
			Projectile.NewProjectile(source, position, velocity / 30, type, damage, knockback, player.whoAmI, velocity.X, velocity.Y);
			if (Item.shoot == Mod.Find<ModProjectile>("QuartzKnife1").Type)
			{
				Item.shoot = Mod.Find<ModProjectile>("QuartzKnife2").Type;
			}
			else
			{
				Item.shoot = Mod.Find<ModProjectile>("QuartzKnife1").Type;
			}
			return false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<QuartzIngot>(), 10);
			recipe.AddIngredient(ItemID.Wood, 15);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}