using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

using MetroFramework;
using MetroFramework.Controls;

namespace CCAnimationEditor
{
    // Somewhat of a hack to render images in different interpolation modes (among other things..)
    // Credit to Jason D (https://stackoverflow.com/a/1774592)
    public class MetroPanelCustom : MetroPanel
    {
        private SmoothingMode? smoothingMode;
        private CompositingQuality? compositingQuality;
        private InterpolationMode? interpolationMode;

        public SmoothingMode? SmoothingMode { get => smoothingMode; set => smoothingMode = value; }
        public CompositingQuality? CompositingQuality { get => compositingQuality; set => compositingQuality = value; }
        public InterpolationMode? InterpolationMode { get => interpolationMode; set => interpolationMode = value; }

        protected override void OnPaintBackground(PaintEventArgs pe)
        {
            // Apply the parameters to the renderer
            if (SmoothingMode.HasValue)
                pe.Graphics.SmoothingMode = SmoothingMode.Value;
            if (CompositingQuality.HasValue)
                pe.Graphics.CompositingQuality = CompositingQuality.Value;
            if (InterpolationMode.HasValue)
                pe.Graphics.InterpolationMode = InterpolationMode.Value;

            // Params to reduce flickering
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            // Run the paint base method
            base.OnPaintBackground(pe);
        }
    }
}
