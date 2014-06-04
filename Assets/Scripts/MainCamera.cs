using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	private GameObject player = null;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		// stick the camera to the player
		transform.position += Vector3.right * Time.deltaTime * GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().playerSpeed;

		//temporary
//		transform.position = new Vector3(player.GetComponent<Player>().transform.position.x - player.GetComponent<Player>().playerX, 
//		                                 transform.position.y, transform.position.z);
	}
}
