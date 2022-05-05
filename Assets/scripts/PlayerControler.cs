﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin,xMax,zMin,zMax;

}
public class PlayerControler : MonoBehaviour 
{
	public Boundary boundary;
	public float speed;
	public float tilt;
	private Rigidbody rb;
	private AudioSource ac;

	public GameObject shots;
	public Transform[] shotspawns;
	public float firerate;

	private float nextfire;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		ac = GetComponent<AudioSource> ();
	}

	void Update()
	{
		if (Input.GetButton ("Fire1") && Time.time > nextfire)
		{
			nextfire = Time.time + firerate;
			foreach (var shotspawn in shotspawns) {
				Instantiate (shots, shotspawn.position, shotspawn.rotation);
			}
			ac.Play();
		}	
	}
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement * speed;
		rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
		);
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);

	}
}
