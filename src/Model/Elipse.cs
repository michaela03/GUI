using System;
using System.Drawing;

namespace Draw
{
    /// <summary>
    /// Класът елипса е основен примитив, който е наследник на базовия Shape.
    /// </summary>
    public class EllipseShape : Shape
    {
        #region Constructor

        public EllipseShape(RectangleF rect) : base(rect)
        {
        }

        public EllipseShape(EllipseShape ellipse) : base(ellipse)
        {
        }

        #endregion

        /// <summary>
        /// Проверка за принадлежност на точка point към елипсата.
        /// Поради специфичната форма на елипсата, тази проверка изисква различна реализация от тази на правоъгълника.
        /// </summary>
        public override bool Contains(PointF point)
        {
            // Проверяваме дали точката се намира вътре в елипсата, като използваме уравнението на елипса
            float dx = point.X - (Rectangle.Left + Rectangle.Width / 2);
            float dy = point.Y - (Rectangle.Top + Rectangle.Height / 2);
            float rx = Rectangle.Width / 2;
            float ry = Rectangle.Height / 2;

            if (rx <= 0.0f || ry <= 0.0f)
            {
                return false; // предотвратяваме деление на нула
            }

            // Уравнението на елипса: (x^2 / rx^2) + (y^2 / ry^2) <= 1
            return ((dx * dx) / (rx * rx) + (dy * dy) / (ry * ry)) <= 1.0f;
        }

        /// <summary>
        /// Частта, визуализираща конкретния примитив.
        /// </summary>
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);

            Color color = Color.FromArgb(FillColorOpacity, FillColor);

            grfx.FillEllipse(
                new SolidBrush(color),
                Rectangle.X,
                Rectangle.Y,
                Rectangle.Width,
                Rectangle.Height);

            grfx.DrawEllipse(
                new Pen(BorderColor),
                Rectangle.X,
                Rectangle.Y,
                Rectangle.Width,
                Rectangle.Height);
        }
    }
}
