﻿using CommunityToolkit.Maui.Core.Handlers;
using CommunityToolkit.Maui.Core.Views;
using CommunityToolkit.Maui.Views;

namespace CommunityToolkit.Maui;

/// <summary>
/// This class contains MediaElement's <see cref="MauiAppBuilder"/> extensions.
/// </summary>
public static class AppBuilderExtensions
{
	/// <summary>
	/// Initializes the .NET MAUI Community Toolkit MediaElement Library
	/// </summary>
	/// <param name="builder"><see cref="MauiAppBuilder"/> generated by <see cref="MauiApp"/>.</param>
	/// <param name="configureMediaOptions">
	/// The mechanism to define the shared options for use with the <see cref="MediaManager"/> implementations. Note this is optional.
	/// An example of configuring the media options for iOS and macOS, is as follows:
	/// <code>
	/// builder
	///     .AddAudio(
	///			configureMediaOptions: mediaOptions =>
	///			{
	///#if IOS || MACCATALYST
	///				mediaOptions.Category = AVFoundation.AVAudioSessionCategory.Playback;
	///				mediaOptions.Mode = AVFoundation.AVAudioSessionMode.Default;
	///				mediaOptions.CategoryOptions = AVFoundation.AVAudioSessionCategoryOptions.DefaultToSpeaker;
	///#endif
	///			});
	/// </code>
	/// </param>
	/// <returns><see cref="MauiAppBuilder"/> initialized for <see cref="MediaElement"/>.</returns>
	public static MauiAppBuilder UseMauiCommunityToolkitMediaElement(this MauiAppBuilder builder, Action<MediaOptions>? configureMediaOptions = null)
	{
		builder.ConfigureMauiHandlers(h =>
		{
			h.AddHandler<MediaElement, MediaElementHandler>();
		});
		
		var mediaOptions = new MediaOptions();
		configureMediaOptions?.Invoke(mediaOptions);
		MediaManager.DefaultMediaOptions = mediaOptions;

		return builder;
	}
}