using TheSauce.Assets.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace TheSauce.Assets.Projectiles
{
    internal class BlackHole : ModProjectile
    {

		public static int maxInstances = 1;
		public static BlackHole[] blackHoleInstances = new BlackHole[maxInstances];

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
			if (blackHoleInstances[0] != null)
            {
				blackHoleInstances[0].Projectile.Kill();
				blackHoleInstances[0] = this;
				//Projectile.Kill();
			} else
            {
                blackHoleInstances[0] = this;
            }
        }

    }
}
