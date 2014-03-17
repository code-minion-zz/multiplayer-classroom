using UnityEngine;
using System.Collections;

public class TitleScene : MonoBehaviour
{
	private enum EState
	{
		FadeIn,
		Show,
		FadeOut,
	}

	public UIWidget fadeChalkboard;
	public float fadeInDuration;
	public float showDuration;
	public float fadeOutDuration;
	public string nextScene;

	private float timeElapsed;
	private EState state = EState.FadeIn;

	public void Start()
	{
		// Check for invalid data.
		if (fadeChalkboard == null) { Debug.LogError("fadeChalkboard not set.", this); }
		if (fadeInDuration == 0.0f) { Debug.LogWarning("fadeInDuration not set.", this); }
		if (showDuration == 0.0f) { Debug.LogWarning("showDuration not set.", this); }
		if (fadeOutDuration == 0.0f) { Debug.LogWarning("fadeOutTime not set.", this); }
		if (nextScene == null || nextScene == "") { Debug.LogWarning("nextScene not set.", this); }

		Color fadeColor = fadeChalkboard.color;
		fadeColor.a = 1.0f;
		fadeChalkboard.color = fadeColor;
	}

	public void Update()
	{
		// Update time for fading.
		switch (state)
		{
			case EState.FadeIn:
				{
					if (timeElapsed < fadeInDuration)
					{
						timeElapsed += Time.deltaTime;
						if (timeElapsed > fadeInDuration)
						{
							timeElapsed = fadeInDuration;
						}

						// Fade to black
						Color fadeColor = fadeChalkboard.color;
						fadeColor.a = 1.0f - (timeElapsed / fadeInDuration);
						fadeChalkboard.color = fadeColor;
					}

					// Once fading to black is complete loda the next scene.
					else if (timeElapsed == fadeInDuration)
					{
						state = EState.Show;
						timeElapsed = 0.0f;
					}
				}
				break;
			case EState.Show:
				{
					if (timeElapsed < showDuration)
					{
						timeElapsed += Time.deltaTime;
						if (timeElapsed > showDuration)
						{
							timeElapsed = showDuration;
						}
					}
					else if (timeElapsed == showDuration)
					{
						state = EState.FadeOut;
						timeElapsed = 0.0f;
					}
				}
				break;
			case EState.FadeOut:
				{
					if (timeElapsed < fadeOutDuration)
					{
						timeElapsed += Time.deltaTime;
						if (timeElapsed > fadeOutDuration)
						{
							timeElapsed = fadeOutDuration;
						}

						// Fade to black
						Color fadeColor = fadeChalkboard.color;
						fadeColor.a = (timeElapsed / fadeOutDuration);
						fadeChalkboard.color = fadeColor;
					}

					// Once fading to black is complete loda the next scene.
					else if (timeElapsed == fadeOutDuration && (nextScene != null && nextScene != ""))
					{
						Application.LoadLevel(nextScene);
					}
				}
				break;
			default:
				{
					Debug.LogError("Unhandled case.");
				}
				break;
		}
	}
}
