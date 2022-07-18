using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheSauce.Assets.Projectiles;

namespace TheSauce.Assets.WeaponsMagic
{
	public class magicweapontemp : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("TutorialSword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("testing how to make a magic staff");
		}

		public override void SetDefaults()
		{
			Item.damage = 200;
			Item.mana = 6;
			Item.DamageType = DamageClass.Magic;
			Item.width = 60;
			Item.height = 60;
			Item.useTime = 0;
			Item.useAnimation = 1;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.noMelee = true;
			Item.knockBack = 3;
			Item.value = 1000;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<SparklingBall>();
			Item.shootSpeed = 16f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
    }
}