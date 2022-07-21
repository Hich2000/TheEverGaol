using TheSauce.Assets.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace TheSauce.Assets.Projectiles
{
	internal class BlackHoleStar : ModProjectile
	{

		public override void SetDefaults()
		{
			Projectile.width = 22;
			Projectile.height = 24;
			Projectile.friendly = true;
			Projectile.penetrate = 5;
			Projectile.timeLeft = 600;
		}

	}
}
