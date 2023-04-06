using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Illuminum.Buffs;

namespace Illuminum.Items.Weapons.Ranged.PreHM
{
	public class BloodstoneBlaster : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Bloodstone Blaster");
			Tooltip.SetDefault("Shoots 2 bullets at above half max life" +
                "\nUsing this gun above half max life drain health" +
                "\n'An eye for an eye'");
		}

		public override void SetDefaults() 
		{
			Item.damage = 20;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 36;
			Item.height = 24;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(silver: 50);
			Item.rare = ItemRarityID.Blue;
			Item.shoot = ProjectileID.UnholyArrow;
			Item.noMelee = true;
			Item.shootSpeed = 5f;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = false;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (player.statLife >= player.statLifeMax2 / 2)
				{
				const int NumProjectiles = 1;

				for (int i = 0; i < NumProjectiles; i++)
				{

					Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(5));


					newVelocity *= 1f - Main.rand.NextFloat(0.1f);


					Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
				}

				IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
				if (modPlayer.hematiteSet == false)
				{
					CombatText.NewText(player.getRect(), Color.Red, "6", true, false);
					player.statLife -= 6;
					if (player.statLife <= 0)
					{
						player.AddBuff(ModContent.BuffType<BloodFlame>(), 60);
					}
				}
				
			}
			return true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "BloodShard", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}