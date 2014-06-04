using UnityEngine;
using System.Collections;

public class Police : MonoBehaviour {

	public float policeX = 0.0f;
	public float policeY = 0.0f;
	public float differenceX = 0.0f;
	
	private GameObject player = null;
	private GameObject platformRemover = null;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		platformRemover = GameObject.FindGameObjectWithTag("PlatformRemover");

//		transform.position = new Vector3(platformRemover.transform.position.x, player.transform.position.y);
		renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position - new Vector3(differenceX, 0.0f);
	}

	void OnCollisionEnter2D(Collision2D obj)
	{
		switch(obj.gameObject.tag)
		{
		case "Player":
			Debug.Log("GAMEOVER");
			break;
		}
	}
}