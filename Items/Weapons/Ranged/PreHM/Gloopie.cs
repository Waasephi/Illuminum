using Terraria.ID;
using Terraria;
using Illuminum.Projectiles;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Ranged.PreHM
{
    public class Gloopie : ModItem

	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Gloopie");
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 24;           //this is the item damage
			Item.DamageType = DamageClass.Ranged;
			Item.noMelee = true;
			Item.width = 24;
			Item.height = 22;
			Item.useTime = 16;       //this is how fast you use the item
			Item.useAnimation = 16;   //this is how fast the animation when the item is used
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 5;
			Item.value = Item.sellPrice(gold: 1);
			Item.rare = ItemRarityID.Green;
			Item.reuseDelay = 6;    //this is the item delay
			Item.UseSound = SoundID.Item111;
			Item.autoReuse = true;       //this make the item auto reuse
			Item.shoot = ProjectileID.ToxicBubble;
			Item.shootSpeed = 6f;     //projectile speed
			Item.useTurn = true;
			Item.maxStack = 1;       //this is the max stack of this item
			Item.consumable = false;  //this make the item consumable when used
		}
	}
}