using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText timeText;

	private bool gameOver;
	private bool restart;
	private int score;
	public int timeNow;

	void Start()
	{
		score = 0;
		UpdateScore ();
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		StartCoroutine (SpawnWaves () );
	}

	void Update()
	{
		if (restart)
		{
			if(Input.GetKeyDown (KeyCode.R))
			   {
				Application.LoadLevel (Application.loadedLevel);
			   }
		}
		timeNow = Mathf.RoundToInt (Time.timeSinceLevelLoad);
	//	result = s.ToString ("#0.00");
		timeText.text = "Time: " + timeNow;

	}
	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(startWait);
			while (true) {
							for (int i = 0; i < hazardCount; i ++) {
				                    GameObject hazard = hazards[Random.Range (0, hazards.Length )];
									Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
									Quaternion spawnRotation = Quaternion.identity; 
									Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait  / (Time.timeSinceLevelLoad/5 + 1));
							}
			yield return new WaitForSeconds(waveWait);
			if(gameOver)
			{
				restartText.text = " Press 'R' for another game. ";
				restart = true ;
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
		gameOverText.text = "Game Over ";
			//"\r\nYou Have Defeated By 'BO XIE' DAMOWANG!";
		gameOver = true;
	}





}
