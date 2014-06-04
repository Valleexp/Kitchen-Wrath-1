using UnityEngine;
using System.Collections;

public class PlatformRemover : MonoBehaviour {

	public float differenceDist = 0.0f;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x - differenceDist, transform.position.y);
	}
}
