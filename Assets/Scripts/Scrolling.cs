using UnityEngine;
using System.Collections;

public class Scrolling : MonoBehaviour {

	public float scrollingSpeed = 0.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Scroll();
	}

	private void Scroll()
	{
		renderer.material.mainTextureOffset = new Vector2(Time.time * scrollingSpeed, 0.0f);
	}
}
