using UnityEngine;
using System.Collections;

public class RandomsGenerator : MonoBehaviour {

	private static RandomsGenerator randomsGeneratorInstance = null;
	
	private static RandomsGenerator Instance
	{
		get
		{
			if (randomsGeneratorInstance == null)
			{
				randomsGeneratorInstance = (new GameObject("RandomsGenerator")).AddComponent<RandomsGenerator>();
			}
			return randomsGeneratorInstance;
		}
	}

	public static int RandomInt(int min, int max)
	{
		return Random.Range(min, max);
	}

	public static float RandomFloat(float min, float max)
	{
		return Random.Range(min, max);
	}
}
