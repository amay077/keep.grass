﻿using System;

using System.Linq;

using Xamarin.Forms;
using ImageCircle.Forms.Plugin.Abstractions;

namespace keep.grass
{
    public class AlphaCircleImageCell : ViewCell
	{
		protected Image
		Image = AlphaFactory.MakeCircleImage();
		protected Label TextLabel = new Label();
		protected Image RightImage = new Image();

		public AlphaCircleImageCell() : base()
		{
			View = new Grid().SetSingleChild
			(
				new StackLayout
				{
					Orientation = StackOrientation.Horizontal,
					VerticalOptions = LayoutOptions.Center,
					Padding = new Thickness(20, 2, 0, 2),
					Children =
					{
						Image,
						TextLabel,
						RightImage,
					},
				}
			);

            Image.IsVisible = null != Image.Source;
            Image.VerticalOptions = LayoutOptions.Center;
			TextLabel.VerticalOptions = LayoutOptions.Center;
			TextLabel.HorizontalOptions = LayoutOptions.StartAndExpand;
			RightImage.VerticalOptions = LayoutOptions.Center;
			RightImage.HorizontalOptions = LayoutOptions.End;
			RightImage.Source = AlphaFactory.GetApp().GetRightImageSource();
			RightImage.IsVisible = null != CommandValue;
		}

		private Command CommandValue = null;
		public Command Command
		{
			set
			{
				CommandValue = value;
				RightImage.IsVisible = null != CommandValue;
			}
			get
			{
				return CommandValue;
			}
		}
		protected override void OnTapped()
		{
			base.OnTapped();
			if (null != CommandValue)
			{
				CommandValue.Execute(this);
			}
		}

		public ImageSource ImageSource
		{
			get
			{
				return Image.Source;
			}
			set
			{
				Image.Source = value;
                Image.IsVisible = null != Image.Source;
            }
        }

		public String Text
		{
			get
			{
				return TextLabel.Text;
			}
			set
			{
				TextLabel.Text = value;
			}
		}
		public Color TextColor
		{
			get
			{
				return TextLabel.TextColor;
			}
			set
			{
				TextLabel.TextColor = value;
			}
		}
	}
}

