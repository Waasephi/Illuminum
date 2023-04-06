using Terraria.ID;
using Terraria;
using Illuminum.Projectiles.Ranged.HM;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.GameContent;

namespace Illuminum.Items.Weapons.Ranged.HM
{
    public class Brimlance : ModItem

	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brimlance");
		}

		public override void SetDefaults()
		{
			Item.damage = 68;           //this is the item damage
			Item.DamageType = DamageClass.Ranged;
			Item.noMelee = true;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 25;       //this is how fast you use the item
			Item.useAnimation = 25;   //this is how fast the animation when the item is used
			Item.crit = 8;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5;
			Item.value = Item.sellPrice(gold: 5);
			Item.rare = ItemRarityID.Green;
			Item.reuseDelay = 6;    //this is the item delay
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;       //this make the item auto reuse
			Item.shoot = ModContent.ProjectileType<BrimlanceProjectile>();
			Item.shootSpeed = 14f;     //projectile speed
			Item.useTurn = true;
			Item.maxStack = 1;       //this is the max stack of this item
			Item.consumable = false;  //this make the item consumable when used
			Item.noUseGraphic = true;
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