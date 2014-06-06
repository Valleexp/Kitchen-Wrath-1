using UnityEngine;
using System.Collections;

public class Scrolling : MonoBehaviour {

	public float scrollingSpeed = 0.0f;
	private GameObject mainCamera = null;

	void Awake()
	{
	}

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(mainCamera.GetComponent<MainCamera>().transform.position.x,
		                                 transform.position.y,
		                                 transform.position.z);
		Scroll();
	}

	private void Scroll()
	{
		renderer.material.mainTextureOffset = new Vector2(Time.time * scrollingSpeed, 0.0f);
	}
}
