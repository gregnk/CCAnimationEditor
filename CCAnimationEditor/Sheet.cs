using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAnimationEditor
{
    public class Sheet
    {
        private string name = "newSheet";
        private string src = "media/entity/player/move.png";
        private int xCount = 0;
        private int offX = 0;
        private int offY = 0;
        private int width = 1;
        private int height = 1;

        public string Name { get => name; set => name = value; }
        public string Src { get => src; set => src = value; }
        public int XCount { get => xCount; set => xCount = value; }
        public int OffX { get => offX; set => offX = value; }
        public int OffY { get => offY; set => offY = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
    }
}
