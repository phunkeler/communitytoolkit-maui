﻿using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Maui.Views;

namespace CommunityToolkit.Maui.Sample.Pages.Views;

[RequiresUnreferencedCode("Expander is not trim safe")]
[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
public partial class ExpanderPageCS : ContentPage
{
	public ExpanderPageCS()
	{
		const string dotnetBotUrl = "https://avatars.githubusercontent.com/u/9011267?v=4";
		const string dotnetMauiUrl = "https://dot.net/maui";

		Title = "Expander Page, C# UI";

		Content = new VerticalStackLayout()
		{
			Spacing = 12,

			Children =
			{
				new Label()
					.Text("Expander C# Sample")
					.Font(bold: true, size: 24)
					.CenterHorizontal().TextCenter(),

				new Picker() { ItemsSource = Enum.GetValues<ExpandDirection>(), Title = "Direction" }
					.CenterHorizontal().TextCenter()
					.Assign(out Picker picker),

				new Expander
				{
					Header = new Label()
								.Text("Expander\n(Tap Me)")
								.TextCenter()
								.Font(bold: true, size: 18),

					Content = new VerticalStackLayout()
					{
						new Image()
							.Source(dotnetBotUrl)
							.Size(120)
							.Aspect(Aspect.AspectFit),

						new Label()
							.Text(".NET Multi-platform App UI (.NET MAUI) is a cross-platform framework for creating mobile and desktop apps with C# and XAML. Using .NET MAUI, you can develop apps that can run on Android, iOS, iPadOS, macOS, and Windows from a single shared codebase.")
							.Font(italic: true),

						new Button()
							.Text("Learn more")
							.Invoke(button => button.Clicked += static async (_, _) => await Launcher.OpenAsync(dotnetMauiUrl))

					}.Padding(10)

				}.CenterHorizontal()
				 .Bind(Expander.DirectionProperty,
						static (Picker picker) => picker.SelectedIndex,
						source: picker,
						convert: (int selectedIndex) => Enum.IsDefined(typeof(ExpandDirection), selectedIndex) ? (ExpandDirection)selectedIndex : default)
			 }
		};
	}
}