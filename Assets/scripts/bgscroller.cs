using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgscroller : MonoBehaviour {

	public float scrollspeed;
	public float tilesizez;

	private Vector3 startposition;

	void Start () {
		startposition = transform.position;
	}
	
	void Update () {
		float newposition = Mathf.Repeat (Time.time * scrollspeed, tilesizez);
		transform.position = startposition + Vector3.forward * newposition;
	}
}
