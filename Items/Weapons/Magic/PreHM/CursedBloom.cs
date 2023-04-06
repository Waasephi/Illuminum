using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Magic.PreHM
{
	public class CursedBloom : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Bloom");
		}

		public override void SetDefaults()
		{
			Item.damage = 37;
			Item.DamageType = DamageClass.Magic;
			Item.width = 50;
			Item.height = 50;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = Item.sellPrice(silver: 90);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = false;
			Item.shoot = ProjectileID.CursedFlameFriendly;
			Item.shootSpeed = 8f;
			Item.mana = 14;
			Item.noMelee = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod, "DarksteelPlating", 8);
			recipe.AddIngredient(ItemID.FlowerofFire); //Flower of Fire
			recipe.AddTile(Mod, "CursedForge");
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