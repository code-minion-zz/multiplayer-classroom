using UnityEngine;
using System.Collections;

public class TweenAlphaPanel : MonoBehaviour {

	public float FadeInTime = .5f;
	private UIPanel panel;

	// Use this for initialization
	void Start () {
		panel = GetComponent<UIPanel>();
	}
	
	// Update is called once per frame
	void Update () {
		if (panel.alpha >= 1) return;
		float delta = Time.smoothDeltaTime / FadeInTime;
		panel.alpha += delta;
	}
}
