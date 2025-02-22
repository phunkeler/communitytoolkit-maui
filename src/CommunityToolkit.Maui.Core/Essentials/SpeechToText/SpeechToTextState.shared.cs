namespace CommunityToolkit.Maui.Media;

/// <summary>
/// Speech To Text listening state
/// </summary>
public enum SpeechToTextState
{
	/// <summary>
	/// Listening is stopped
	/// </summary>
	Stopped,

	/// <summary>
	/// Listening is active
	/// </summary>
	Listening,

	/// <summary>
	/// Listening is active, but no sound is detected
	/// </summary>
	Silence
}