using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Example : MonoBehaviour {
	public List <UISlider> bars = new List<UISlider> ();
	public GameObject themeSwitch;
	public List <Transform> switches = new List<Transform> ();

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		foreach (UISlider bar in bars) {
			bar.value = Mathf.Sin (Time.time) * 0.5f + 0.5f;
		}
	}
}
