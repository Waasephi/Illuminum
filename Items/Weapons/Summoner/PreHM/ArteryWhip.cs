using Illuminum.Items.Materials.PreHM;
using Illuminum.Projectiles.Summoner.PreHM;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Illuminum.Buffs;
using static Terraria.ModLoader.ModContent;
using Terraria.DataStructures;

namespace Illuminum.Items.Weapons.Summoner.PreHM
{
	public class ArteryWhip : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Artery Whip");
			Tooltip.SetDefault("Uses your life to damage foes" +
                "\nShoots a blood stream on enemy hit" +
				"\n'An eye for an eye'");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{

			Item.DamageType = DamageClass.SummonMeleeSpeed;
			Item.damage = 22;
			Item.knockBack = 2;
			Item.rare = ItemRarityID.Blue;

			Item.shoot = ProjectileType<ArteryWhipProjectile>();
			Item.shootSpeed = 4;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.UseSound = SoundID.Item152;
			Item.channel = false; // This is used for the charging functionality. Remove it if your whip shouldn't be chargeable.
			Item.noMelee = true;
			Item.noUseGraphic = true;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
			if (modPlayer.hematiteSet == false)
			{
				CombatText.NewText(player.getRect(), Color.Red, "5", true, false);
				player.statLife -= 5;
				if (player.statLife <= 0)
				{
					player.AddBuff(BuffType<BloodFlame>(), 60);
				}
			}
			return true;
		}
		public override bool CanUseItem(Player player)
		{
			// Ensures no more than one spear can be thrown out, use this when using autoReuse
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "BloodShard", 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}