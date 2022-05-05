using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamecontroler : MonoBehaviour {

	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardcount;
	public float startTime;
	public float spawnTime;
	public float waveTime;

	public Text scoreText;
	public Text gameoverText;
	public Text restartText;

	private bool gameover;
	private bool restart;
	private int score;

	void Start ()
	{
		gameover = false;
		restart = false;
		gameoverText.text = "";
		restartText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	void Update()
	{
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}	
	}
	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startTime);
		while (true) 
		{
			for (int i = 0; i < hazardcount; i++)
			{
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnTime);
			}
			yield return new WaitForSeconds (waveTime);

			if (gameover) {
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver()
	{
		gameoverText.text = "Game Over";
		gameover = true;
	}
}
