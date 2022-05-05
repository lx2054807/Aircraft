using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponcontroller : MonoBehaviour {

	public GameObject shot;
	public Transform shotspawn;
	public float firerate;
	public float delay;

	private AudioSource audiosource;

	void Start () 
	{
		audiosource = GetComponent<AudioSource> ();
		InvokeRepeating ("Fire", delay, firerate);
	}

	void Fire()
	{
		Instantiate (shot, shotspawn.position, shotspawn.rotation);
		audiosource.Play ();
	}

}
