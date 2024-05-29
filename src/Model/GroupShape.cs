using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
    [Serializable]
    public class GroupShape : Shape
    {

        #region Constructor

        public GroupShape(RectangleF rect) : base(rect)
        {
        }

        public GroupShape(RectangleShape rectangle) : base(rectangle)
        {
        }

        #endregion

        public virtual void GroupFillColor(Color color)
        {
           FillColor = color;
         
        }
        public virtual void GroupBorderColor(Color color)
        {
            BorderColor = color;
        }

        public virtual void GroupOpacity(int opacity)
        {
            Opacity = opacity;
        }
        public virtual void GroupTranslate(PointF point)
        {

        }
        public virtual void GroupBorderWidth(float borderWidth)
        {
            BorderWidth = borderWidth;
        }
        public virtual void GroupReSizeWidth(float width)
        {
            Width = width;

        }
        public virtual void GroupReSizeHeight(float height)
        {
            Height = height;

        }
        public virtual void GroupRotate(float angel)
        {
            Angle = angel;

        }

    }
}
