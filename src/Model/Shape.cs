using System;
using System.Collections.Generic;
using System.Drawing;

namespace Draw
{
	/// <summary>
	/// Базовия клас на примитивите, който съдържа общите характеристики на примитивите.
	/// </summary>
  
    [Serializable]

	public abstract class Shape
	{
		#region Constructors
		
		public Shape()
		{
		}
		
		public Shape(RectangleF rect)
		{
			rectangle = rect;
		}
		
		public Shape(Shape shape)
		{
			this.Height = shape.Height;
			this.Width = shape.Width;
			this.Location = shape.Location;
			this.rectangle = shape.rectangle;
			
			this.FillColor =  shape.FillColor;
            this.BorderWidth = shape.BorderWidth;
		}
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Обхващащ правоъгълник на елемента.
		/// </summary>
		private RectangleF rectangle;		
		public virtual RectangleF Rectangle
        {
			get { return rectangle; }
			set { rectangle = value; }
		}
		
		/// <summary>
		/// Широчина на елемента.
		/// </summary>
		public virtual float Width
        {
			get { return Rectangle.Width; }
			set { rectangle.Width = value; }
		}
		
		/// <summary>
		/// Височина на елемента.
		/// </summary>
		public virtual float Height
        {
			get { return Rectangle.Height; }
			set { rectangle.Height = value; }
		}
		
		/// <summary>
		/// Горен ляв ъгъл на елемента.
		/// </summary>
		public virtual PointF Location
        {
			get { return Rectangle.Location; }
			set { rectangle.Location = value; }
		}
		
		/// <summary>
		/// Цвят на елемента.
		/// </summary>
		private Color fillColor;		
		public virtual Color FillColor
        {
			get { return fillColor; }
			set { fillColor = value; }
		}

        private string name;
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
		/// Цвят на рамката.
		/// </summary>
        private Color borderColor;
        public virtual Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; }
        }

        /// <summary>
        /// Прозрачност.
        /// </summary>
        private int opacity;
        public virtual int Opacity
        {
            get { return opacity; }
            set { opacity = value; }
        }

        /// <summary>
        /// Дебелина на рамката.
        /// </summary>
        private float borderWidth;
        public virtual float BorderWidth
        {
            get { return borderWidth; }
            set { borderWidth = value; }
        }

        /// <summary>
        /// Завъртане.
        /// </summary>
        private float angle;
        public virtual float Angle
        {
            get { return angle; }
            set { angle = value; }
        }

        #endregion


        /// <summary>
        /// Проверка дали точка point принадлежи на елемента.
        /// </summary>
        /// <param name="point">Точка</param>
        /// <returns>Връща true, ако точката принадлежи на елемента и
        /// false, ако не пренадлежи</returns>
        public virtual bool Contains(PointF point)
		{
			return Rectangle.Contains(point.X, point.Y);
		}
		
		/// <summary>
		/// Визуализира елемента.
		/// </summary>
		/// <param name="grfx">Къде да бъде визуализиран елемента.</param>
		public virtual void DrawSelf(Graphics grfx)
		{
            
		}
       

        public virtual void Move(float dx,float dy)
        {
            Location = new PointF(Location.X + dx, Location.Y + dy);

        }
    
        public virtual void RotateShape(Graphics grfx)
        {
            
            grfx.TranslateTransform(Rectangle.X + Rectangle.Width / 2, Rectangle.Y + Rectangle.Height / 2);
            grfx.RotateTransform(Angle);
           
            grfx.TranslateTransform(-(Rectangle.X + Rectangle.Width / 2), -(Rectangle.Y + Rectangle.Height / 2));
           
        }



    }
}
