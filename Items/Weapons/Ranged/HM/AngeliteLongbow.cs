using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Illuminum.Items.Weapons.Ranged.HM
{
	public class AngeliteLongbow : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Angelite Longbow"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Wooden Arrows turn into Crystal Bolts.");
		}

		public override void SetDefaults() 
		{
			Item.damage = 55;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 38;
			Item.height = 68;
			Item.useTime = 26;
			Item.useAnimation = 26;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(gold: 1, silver: 50);
			Item.rare = ItemRarityID.Blue;
			Item.shoot = ProjectileID.UnholyArrow;
			Item.noMelee = true;
			Item.shootSpeed = 12f;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = false;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAmmo = AmmoID.Arrow;
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			if (type == ProjectileID.WoodenArrowFriendly)
			{
				type = ProjectileID.CrystalPulse;
			}
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "RefinedAngelite", 15);
			recipe.AddTile(Mod, "AngeliteAltar");
			recipe.Register();
		}
		public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
		{
			Texture2D texture = TextureAssets.Item[Item.type].Value;
			Texture2D textureGlow = ModContent.Request<Texture2D>(Item.ModItem.Texture + "_Glow").Value;
			Rectangle frame;
			if (Main.itemAnimations[Item.type] != null)
				frame = Main.itemAnimations[Item.type].GetFrame(texture, Main.itemFrameCounter[whoAmI]);
			else
				frame = texture.Frame();

			Vector2 origin = frame.Size() / 2f;

			spriteBatch.Draw(texture, Item.Center - Main.screenPosition, frame, lightColor, rotation, origin, scale, SpriteEffects.None, 0f);
			spriteBatch.Draw(textureGlow, Item.Center - Main.screenPosition, frame, Color.White, rotation, origin, scale, SpriteEffects.None, 0f);

			return false;
		}
	}
}