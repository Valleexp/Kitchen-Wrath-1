using UnityEngine;
using System.Collections;

public class PlatformRemover : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x - 15.0f, transform.position.y);
	}
}
