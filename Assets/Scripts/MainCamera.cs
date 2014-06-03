using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// stick the camera to the player
		transform.position = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, transform.position.y, transform.position.z);
	}
}
