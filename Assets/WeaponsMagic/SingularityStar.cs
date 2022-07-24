using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheSauce.Assets.Projectiles;

namespace TheSauce.Assets.WeaponsMagic
{
	public class SingularityStar : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("TutorialSword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("testing how to make a magic staff");
		}

		public override void SetDefaults()
		{
			Item.damage = 200;
			Item.mana = 70;
			Item.DamageType = DamageClass.Magic;
			Item.width = 41;
			Item.height = 41;
			Item.useTime = 20;
			Item.useAnimation = 10;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.noMelee = true;
			Item.knockBack = 1;
			Item.value = 45000;
			Item.rare = ItemRarityID.Purple;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Singularity>();
			Item.shootSpeed = 17f;
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