using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using Terraria.DataStructures;
using Illuminum.Projectiles.Misc.HM;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Illuminum.Items.Weapons.Melee.HM
{
	public class BrimstoneBuster : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Brimstone Buster"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Shoots swift brimstone slashes and inflicts hellfire" +
                "\nCritical hits cause explosions with the blade");
		}

		public override void SetDefaults() 
		{
			Item.damage = 66;
			Item.DamageType = DamageClass.Melee;
			Item.width = 48;
			Item.height = 54;
			Item.useTime = 24;
			Item.useAnimation = 24;
			Item.crit = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = Item.sellPrice(gold: 2);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<BrimstoneWave>();
			Item.shootSpeed = 25f;
			Item.scale *= 1.2f;
		}

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
			target.AddBuff(BuffID.OnFire3, 180);
			if (crit)
			{
				SoundEngine.PlaySound(SoundID.Item69, player.Center);
				IlluminumPlayer.ScreenShakeAmount = 5;
				for (int i = 0; i < Main.rand.Next(1, 1); i++)
					Projectile.NewProjectile(player.GetSource_ItemUse(Item), target.Center, new Vector2(Main.rand.NextFloat(0, 0), Main.rand.NextFloat(0, 0)), ProjectileID.DD2ExplosiveTrapT2Explosion, 35, knockBack / 2, player.whoAmI);
			}
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "BrimstoneCrystal", 12);
			recipe.AddTile(TileID.MythrilAnvil);
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