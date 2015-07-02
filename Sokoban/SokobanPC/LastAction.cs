using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SokobanPC
{
    public class LastAction
    {
        public Vector2 MoveVector { get; set; }
        public bool IsBoxMoved { get; set; }
        public bool IsAvailable { get; set; }
        public int BoxID { get; set; }

        public LastAction()
        {
            MoveVector = Vector2.Zero;
            IsBoxMoved = false;
            IsAvailable = false;
            BoxID = 0;
        }

    }
}
