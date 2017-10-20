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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Plick
{
    class Tile
    {
        Vector2 pos;
        Texture2D tex;
        Rectangle sourceRect;
        public Tile(Vector2 pos, Texture2D tex, Rectangle sourceRect)
        {
            this.pos = pos;
            this.tex = tex;
            this.sourceRect = sourceRect;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(texture: tex,position: pos, sourceRectangle:sourceRect);
        }
    }
}