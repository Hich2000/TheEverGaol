using TheSauce.Assets.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace TheSauce.Assets.Projectiles
{
    internal class BlackHole : ModProjectile
    {

		public override void SetDefaults()
		{
			Projectile.width = 100;
			Projectile.height = 100;
			Projectile.friendly = true;
			Projectile.penetrate = 1000;
			Projectile.timeLeft = 600;
		}

        public override void OnSpawn(IEntitySource source)
        {
            base.OnSpawn(source);
			//todo check for instance of BlackHole and kill it.
			var instance = "";
        }

    }
}
