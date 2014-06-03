using UnityEngine;
using System.Collections;

public class CheckPlatformRemove : MonoBehaviour {
	
	//pointer for performance back to manager
	public GameObject gameManager;

	void Awake()
	{
		gameManager = GameObject.Find("LevelLoader");
	}
	
	// Use this for initialization
	void Start () {

	}
	
	void OnTriggerEnter2D(Collider2D obj)
	{
		// if we touch the collider
		if(obj.gameObject.tag == "PlatformRemover")
		{	
			// check if the platforms need any instantiating or removings
			transform.position = new Vector3 (gameManager.GetComponent<LevelLoader>().newPlatformPositionX, transform.position.y, 0.0f);
			gameManager.GetComponent<LevelLoader>().newPlatformPositionX += transform.localScale.x;
//			Debug.Log("Collided");
		}
	}
}