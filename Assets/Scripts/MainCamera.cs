using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	private GameObject levelLoader = null;
	public GameObject player = null;

	public float offset = 0.0f;

	// Use this for initialization
	void Start () {
		levelLoader = GameObject.Find("LevelLoader");
		player = levelLoader.GetComponent<LevelLoader>().player;
	}
	
	// Update is called once per frame
	void Update () {
		// stick the camera to the player

		//1st method
//		transform.position += Vector3.right * Time.deltaTime * (player.GetComponent<Player>().playerSpeed);

		//2nd method
		transform.position = new Vector3(player.transform.position.x + offset, transform.position.y, transform.position.z);

		//temporary
//		transform.position = new Vector3(player.GetComponent<Player>().transform.position.x - player.GetComponent<Player>().playerX, 
//		                                 transform.position.y, transform.position.z);
	}
}
