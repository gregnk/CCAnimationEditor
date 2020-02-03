using System;

namespace CCAnimationEditor
{
    // NOTE: There are some properties that are not in this editor, however some of them don't appear to do anything
    public class Animation
    {
        private string name = "newAnim";
        private int dirs = -1;
        private string sheet;
        private string shapeType;
        private int[] flipX;
        private int[] tileOffsets;
        private int[] anchorOffsetX;
        private int[] anchorOffsetY;
        private int[] anchorOffsetZ;
        private float time = -1;
        private bool repeat;
        private int[] frames;
        private int[] framesAlpha;
        private int[][] dirFrames;

        public string Name { get => name; set => name = value; }
        public string Sheet { get => sheet; set => sheet = value; }
        public string ShapeType { get => shapeType; set => shapeType = value; }
        public int Dirs { get => dirs; set { dirs = value; } }
        public int[] FlipX { get => flipX; set => flipX = value; }
        public int[] TileOffsets { get => tileOffsets; set => tileOffsets = value; }
        public int[] AnchorOffsetX { get => anchorOffsetX; set => anchorOffsetX = value; }
        public int[] AnchorOffsetY { get => anchorOffsetY; set => anchorOffsetY = value; }
        public int[] AnchorOffsetZ { get => anchorOffsetZ; set => anchorOffsetZ = value; }
        public float Time { get => time; set => time = value; }
        public bool Repeat { get => repeat; set => repeat = value; }
        public int[] Frames { get => frames; set => frames = value; }
        public int[] FramesAlpha { get => framesAlpha; set => framesAlpha = value; }
        public int[][] DirFrames { get => dirFrames; set => dirFrames = value; }
    }
}
