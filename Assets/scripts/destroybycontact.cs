using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroybycontact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplpsion;
	private gamecontroler gameControler;
	public int scorevalue;

	void Start()
	{
		GameObject gamecontrolerobject = GameObject.FindWithTag ("GameController");
		if (gamecontrolerobject != null)
		{
			gameControler = gamecontrolerobject.GetComponent<gamecontroler> ();
		}
		if (gamecontrolerobject == null) 
		{
			Debug.Log ("cannot find the gamecontroller");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Boundary") || other.CompareTag("Enemy") ) 
		{
			return;
		}

		if (explosion != null) 
		{
			Instantiate (explosion, transform.position, transform.rotation);
		}

		if (other.tag == "Player") 
		{
			Instantiate (playerExplpsion, other.transform.position, other.transform.rotation);
			gameControler.GameOver ();
		}
		gameControler.AddScore (scorevalue);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
