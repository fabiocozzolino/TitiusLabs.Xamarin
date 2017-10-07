using System;
using Android.Graphics;
using Android.Util;
using Android.Views;
using TitiusLabs.Forms.Controls;
using TitiusLabs.Forms.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(RoundedBox), typeof(RoundedBoxRenderer))]

namespace TitiusLabs.Forms.Droid.Controls
{
	public class RoundedBoxRenderer : ViewRenderer<RoundedBox, Android.Views.View>
	{
		private float _cornerRadius;
		private RectF _bounds;
		private Path _path;

		protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<RoundedBox> e)
		{
			base.OnElementChanged(e);

			if (Element == null)
			{
				return;
			}

			_cornerRadius = TypedValue.ApplyDimension(ComplexUnitType.Dip, (float)Element.CornerRadius, Context.Resources.DisplayMetrics);

		}

		protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
		{
			base.OnSizeChanged(w, h, oldw, oldh);
			if (w != oldw && h != oldh)
			{
				_bounds = new RectF(0, 0, w, h);
			}

			_path = new Path();
			_path.Reset();
			_path.AddRoundRect(_bounds, _cornerRadius, _cornerRadius, Path.Direction.Cw);
			_path.Close();
		}

		public override void Draw(Canvas canvas)
		{
			canvas.Save();
			canvas.ClipPath(_path);
			base.Draw(canvas);
			canvas.Restore();
		}
	}
}
