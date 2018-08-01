using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform;
using Xamarin.Forms.StyleSheets;

[assembly: StyleProperty("-xf-color", typeof(BoxView), nameof(BoxView.ColorProperty))]

namespace Xamarin.Forms
{
	[RenderWith(typeof(_BoxViewRenderer))]
	public class BoxView : View, ICornerElement, IElementConfiguration<BoxView>
	{
		public static readonly BindableProperty ColorProperty =
			BindableProperty.Create("Color", typeof(Color), typeof(BoxView), Color.Default);

		public static readonly BindableProperty CornerRadiusProperty = CornerElement.CornerRadiusProperty;

		readonly Lazy<PlatformConfigurationRegistry<BoxView>> _platformConfigurationRegistry;

		public BoxView()
		{
			_platformConfigurationRegistry = new Lazy<PlatformConfigurationRegistry<BoxView>>(() => new PlatformConfigurationRegistry<BoxView>(this));
		}

		public Color Color
		{
			get { return (Color)GetValue(ColorProperty); }
			set { SetValue(ColorProperty, value); }
		}

		public CornerRadius CornerRadius {
			get => (CornerRadius)GetValue(CornerElement.CornerRadiusProperty);
			set => SetValue(CornerElement.CornerRadiusProperty, value);
		}

		public IPlatformElementConfiguration<T, BoxView> On<T>() where T : IConfigPlatform
		{
			return _platformConfigurationRegistry.Value.On<T>();
		}

		[Obsolete("OnSizeRequest is obsolete as of version 2.2.0. Please use OnMeasure instead.")]
		protected override SizeRequest OnSizeRequest(double widthConstraint, double heightConstraint)
		{
			return new SizeRequest(new Size(40, 40));
		}
	}
}