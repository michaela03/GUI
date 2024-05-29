using Draw.src.Model;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Draw
{

    [Serializable]

    public class GroupShapeImpl : GroupShape
    {
        #region Constructor

        public GroupShapeImpl(RectangleF rect) : base(rect)
        {
        }

        public GroupShapeImpl(RectangleShape rectangle) : base(rectangle)
        {
        }

        #endregion
        protected List<Shape> subItem = new List<Shape>();
        public List<Shape> SubItem
        {
            get { return subItem; }
            set { subItem = value; }
        }

        /// <summary>
        /// Проверка за принадлежност на точка point към правоъгълника.
        /// В случая на правоъгълник този метод може да не бъде пренаписван, защото
        /// Реализацията съвпада с тази на абстрактния клас Shape, който проверява
        /// дали точката е в обхващащия правоъгълник на елемента (а той съвпада с
        /// елемента в този случай).
        /// </summary>
        public override bool Contains(PointF point)
        {
            if (base.Contains(point))
            {
                // Проверка дали е в обекта само, ако точката е в обхващащия правоъгълник.
                // В случая на правоъгълник - директно връщаме true
                foreach (var item in SubItem)
                {
                    if (item.Contains(point)) return true;
                }
                return true;
            }
            else
                // Ако не е в обхващащия правоъгълник, то неможе да е в обекта и => false
                return false;
        }

        /// <summary>
        /// Частта, визуализираща конкретния примитив.
        /// </summary>
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);

            foreach (var item in SubItem)
            {
                item.DrawSelf(grfx);
            }
        }
        public override void Move(float dx,float dy)
        {
            base.Move(dx, dy);
            foreach (var item in SubItem)
            {
                item.Move(dx*2, dy*2);
            }
        }
        public override void GroupFillColor(Color color)
        {
            base.GroupFillColor(color);
            foreach(var item in SubItem)
            {
                item.FillColor = color;
            }
        }
        public override void GroupBorderColor(Color color)
        {
            base.GroupBorderColor(color);
            foreach (var item in SubItem)
            {
                item.BorderColor = color;
            }
        }

        public override void GroupOpacity(int opacity)
        {
            base.GroupOpacity(opacity);
            foreach (var item in SubItem)
            {
                item.Opacity = opacity;
            }
        }
        public override void GroupTranslate(PointF point)
        {
            base.GroupTranslate(point);
            foreach (var item in SubItem)
            {
                item.Location = new PointF(this.Location.X + (item.Location.X - point.X), this.Location.Y-(point.Y- item.Location.Y));
            }
        }
        public override void GroupBorderWidth(float borderWidth)
        {
            base.GroupBorderWidth(borderWidth);
            foreach (var item in SubItem)
            {
                item.BorderWidth = borderWidth;
            }
        }
        public override void GroupReSizeWidth(float width)
        {
            base.GroupReSizeWidth(width);
            float maxX = float.NegativeInfinity;
            float minX = float.PositiveInfinity;
            foreach (var item in SubItem)
            {
                item.Width = width;
                if (minX > item.Location.X)
                {
                    minX = item.Location.X;
                }
                if (maxX < item.Location.X + item.Width)
                {
                    maxX = item.Location.X + item.Width;
                }

            }
            this.Rectangle = new RectangleF(minX,this.Rectangle.Y,maxX-minX,this.Rectangle.Height);
        }
        public override void GroupReSizeHeight(float height)
        {
            base.GroupReSizeHeight(height);
            float maxY = float.NegativeInfinity;
            float minY = float.PositiveInfinity;
            foreach (var item in SubItem)
            {
                item.Height = height;
                if (minY > item.Location.Y)
                {
                    minY = item.Location.Y;
                }
                if (maxY < item.Location.Y + item.Height)
                {
                    maxY = item.Location.Y + item.Height;
                }

            }
           this.Rectangle = new RectangleF(this.Rectangle.X,minY,this.Rectangle.Width,maxY-minY);

        }
        public override void GroupRotate(float angel)
        {
            base.GroupRotate(angel);
            foreach (var item in SubItem)
            {
                item.Angle = angel;
            }
        }


    }
}
