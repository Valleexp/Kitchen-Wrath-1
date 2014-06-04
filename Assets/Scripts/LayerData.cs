﻿using UnityEngine;
using System.Collections;

public class LayerData : MonoBehaviour {

	private static LayerData layerInstance = null;

	public enum LAYERVALUE
	{
		PLAYER = 8,
		CHEF,
		POLICE,
		FOOD
	};
	
	private static LayerData Instance
	{
		get
		{
			if (layerInstance == null)
			{
				layerInstance = (new GameObject("LayerData")).AddComponent<LayerData>();
			}
			return layerInstance;
		}
	}
}