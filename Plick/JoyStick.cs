using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Plick
{
    class JoyStick
    {
        public Texture2D botTex;
        public Vector2 botPos;
        public Texture2D topTex;
        public Vector2 topPos;

        public JoyStick(Texture2D botTex, Texture2D topTex)
        {
            this.botTex = botTex;
            this.topTex = topTex;
            botPos = new Vector2(100, 100);
            topPos = new Vector2(100, 100);
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(texture: botTex, position: botPos, origin: new Vector2(botTex.Width / 2, botTex.Height / 2));
            sb.Draw(texture: topTex, position: topPos, origin: new Vector2(topTex.Width / 2, topTex.Height / 2));
        }
    }
}