using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GameController : MonoBehaviour {

    public GameObject coin;
    public Vector3 spawnValues;

	
	public Text scoreText;
	public Text lifeText;
	public Text timerText;

	//public GUIText gameOverText;
	
	private bool gameOver;
	private bool win;
	//private bool restart;
	private int score;
	private int life;
	private float time;

	private GameObject player;
	private GameObject dragon;

	private Transform player_trans;
	private Transform dragon_trans;

	private Vector3 spawnPoint;
	public bool respawn;
	
	void Start ()
	{
		gameOver = false;
		//restart = false;
		//restartText.text = "";
		//gameOverText.text = "";
		respawn = false;
		score = 0;
		life = 1000;
		time = 200;
		spawnPoint = new Vector3 (0.1f,-1.71f,0f);
		UpdateScore ();
		UpdateLife();
		UpdateTime ();
		GameObject player = GameObject.FindWithTag ("Player");
		GameObject dragon = GameObject.FindWithTag ("Dragon");
		player_trans = player.GetComponent<Transform> ();
		if (dragon != null) {
			dragon_trans = dragon.GetComponent<Transform> ();
		}
	}

	void Update(){
		UpdateTime ();
	}
	
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	
	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
		// currentGameScore is declared and can be passed across scenes
		PlayerPrefs.SetInt("currentGameScore",score);
		PlayerPrefs.Save();
	}
	
	public int GetLife()
	{
		return life;
	}

	public double GetTime()
	{
		return time;
	}
    public void SpawnWaves()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(coin, spawnPosition, spawnRotation);
    }

	public Vector3 GetSpawnPoint()
	{
		return spawnPoint;
	}

	public void SetSpawnPoint(Vector3 newSpawnPoint)
	{
		spawnPoint = newSpawnPoint;
	}

	public void RespawnTrigger(){
		respawn = !respawn;
	}

	public void Respawn(){
		player_trans.position = GetSpawnPoint ();
		if (dragon_trans != null) {
			dragon_trans.position = new Vector3 (GetSpawnPoint ().x - 10f, dragon_trans.position.y, dragon_trans.position.z);
		}
	}
	public void TakeDamage(){
		life -= 1;
		UpdateLife();
		if (life == 0) {
			GameOver();
		}
		else{
			Respawn();
		}
	}

	void UpdateTime()
	{
		if (time <= 0) {
			time = 0;
			//Time.timeScale = 0;
		} else {
			time -= Time.deltaTime;
		}
		timerText.text = "Time: " + time.ToString("0");
	}

	void UpdateLife()
	{
		lifeText.text = "Life: " + life;
	}

	//Load Lose scene
	public void GameOver()
	{
		Application.LoadLevel ("Lose");
		gameOver = true;
	}

	// Load Win scene
	public void Win(String level)
	{
		Application.LoadLevel (level);
		win = true;
	}
}
