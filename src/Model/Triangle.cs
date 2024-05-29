using System;
using System.Drawing;

namespace Draw
{
    
    public class TriangleShape : Shape
    {
        #region Constructor
        private float rotationAngle;
        public float RotationAngle
        {
            get { return rotationAngle; }
            set { rotationAngle = value; }
        }

        public TriangleShape(RectangleF rect) : base(rect)
        {
        }

        public TriangleShape(TriangleShape triangle) : base(triangle)
        {
        }

        #endregion

        /// <summary>
        /// Check if the point belongs to the triangle.
        /// </summary>
        public override bool Contains(PointF point)
        {
            if (base.Contains(point))
            {
                // Check if the point is inside the triangle
                // Implement the logic for triangle containment here
                return IsPointInsideTriangle(point, Rectangle.Location, new PointF(Rectangle.Right, Rectangle.Bottom), new PointF(Rectangle.Left, Rectangle.Bottom));
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Visualization part for the specific primitive.
        /// </summary>
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);

            Color color = Color.FromArgb(FillColorOpacity, FillColor);

            PointF center = new PointF(Rectangle.X + Rectangle.Width / 2, Rectangle.Y + Rectangle.Height / 2);

            PointF[] rotatedPoints = RotatePoints(new PointF[] { new PointF(Rectangle.X, Rectangle.Y), new PointF(Rectangle.Right, Rectangle.Bottom), new PointF(Rectangle.Left, Rectangle.Bottom) }, center, rotationAngle);

            grfx.FillPolygon(
                new SolidBrush(color),
                rotatedPoints);

            grfx.DrawPolygon(
                new Pen(BorderColor),
                rotatedPoints);
        }
        private PointF[] RotatePoints(PointF[] points, PointF center, float angleInDegrees)
        {
            PointF[] rotatedPoints = new PointF[points.Length];
            double angleInRadians = angleInDegrees * Math.PI / 180.0;

            for (int i = 0; i < points.Length; i++)
            {
                float x = (float)(Math.Cos(angleInRadians) * (points[i].X - center.X) - Math.Sin(angleInRadians) * (points[i].Y - center.Y) + center.X);
                float y = (float)(Math.Sin(angleInRadians) * (points[i].X - center.X) + Math.Cos(angleInRadians) * (points[i].Y - center.Y) + center.Y);
                rotatedPoints[i] = new PointF(x, y);
            }

            return rotatedPoints;
        }

        /// <summary>
        /// Check if a point is inside a triangle.
        /// </summary>
        private bool IsPointInsideTriangle(PointF p, PointF v1, PointF v2, PointF v3)
        {
            float d1 = Sign(p, v1, v2);
            float d2 = Sign(p, v2, v3);
            float d3 = Sign(p, v3, v1);

            bool hasNeg = (d1 < 0) || (d2 < 0) || (d3 < 0);
            bool hasPos = (d1 > 0) || (d2 > 0) || (d3 > 0);

            return !(hasNeg && hasPos);
        }

        private float Sign(PointF p1, PointF p2, PointF p3)
        {
            return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
        }
    }
}
