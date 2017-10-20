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
using System.Xml.Linq;
using Org.Json;
using Newtonsoft.Json;
using System.IO;
using Android.Util;
using System.Threading.Tasks;

namespace Plick
{
    class Ref
    {
        public static List<Tile> tileList = new List<Tile>();
        public static Tile[][] tileArray;
    }
}