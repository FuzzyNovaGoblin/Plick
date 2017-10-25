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
using Android.Util;

namespace Plick
{
    enum DPadState{ Normal, Up, Down, Left , Right}
    class DPad
    {
        public Texture2D tex;
        public Vector2 pos;
        public Rectangle posRect;

        public Rectangle leftBut;
        public Rectangle rightBut;
        public Rectangle upBut;
        public Rectangle downBut;


        Texture2D tex2;

        /// <summary>
        /// Height and width of the destination rectangel of the D-Pad
        /// </summary>
        public int height;

        Rectangle spriteRect;

        /// <summary>
        /// used to set the color of the D-Pad
        /// </summary>
        DPadState state;

        /// <summary>
        /// instantiates the D-Padd
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="tex"></param>
        /// <param name="height">Height and width of the destination rectangel of the D-Pad</param>
        public DPad(Vector2 pos, Texture2D tex, int height, Texture2D tex2)
        {
            state = DPadState.Normal;

            this.height = height;
            this.tex = tex;

            pos.X += (float)(height * 0.3);
            pos.Y -= (float)(height * 1.3);
            this.pos = pos;
            leftBut = new Rectangle((int)pos.X, (int)pos.Y+(tex.Height/height * 36), tex.Height / height * 36, tex.Height / height * 51);
            //rightBut = new Rectangle((int)pos.X, (int)(height * 0.3 + pos.Y), (int)(height * 0.4), (int)(height * 0.35));

            posRect = new Rectangle((int)pos.X, (int)pos.Y, height, height);
            spriteRect = new Rectangle(0, 0, tex.Height, tex.Height);
            this.tex2 = tex2;
        }

        public void update()
        {
            posRect = new Rectangle((int)pos.X, (int)pos.Y, height, height);
            switch (state)
            {
                case DPadState.Normal:
                    spriteRect.X = 0;
                    break;

                case DPadState.Left:
                    spriteRect.X = tex.Height * 4;
                    break;

                case DPadState.Down:
                    spriteRect.X = tex.Height;
                    break;

                case DPadState.Right:
                    spriteRect.X = tex.Height * 2;
                    break;

                case DPadState.Up:
                    spriteRect.X = tex.Height * 3;
                    break;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(texture: tex, sourceRectangle: spriteRect, destinationRectangle: posRect);
            sb.Draw(texture: tex2, destinationRectangle: leftBut);
            Log.Debug("leftBut", leftBut.X + " " + leftBut.Y);
        }

    }
}