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
    class DPad
    {
        public Texture2D tex;
        public Vector2 pos;
        public Rectangle posRect;

        Rectangle spriteRect;
        Rectangle spriteRectN;
        Rectangle spriteRectU;
        Rectangle spriteRectD;
        Rectangle spriteRectL;
        Rectangle spriteRectR;

        public DPad(Vector2 pos, Texture2D tex)
        {
            this.pos = pos;
            this.tex = tex;
            posRect = new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);
        }

        public void update()
        {
            posRect = new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(texture: tex, position: pos);
        }

    }
}