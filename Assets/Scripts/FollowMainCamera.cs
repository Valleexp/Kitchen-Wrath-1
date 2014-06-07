using UnityEngine;
using System.Collections;

public class FollowMainCamera : MonoBehaviour {

	private GameObject mainCamera = null;
	
	// Use this for initialization
	void Start () {
		mainCamera = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(mainCamera.GetComponent<MainCamera>().transform.position.x,
		                                 transform.position.y,
		                                 transform.position.z);
	}
}
