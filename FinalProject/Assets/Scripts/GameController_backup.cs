using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GameController_backup : MonoBehaviour {

	
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
		life = 5;
		time = 5;
		spawnPoint = new Vector3 (0.1f,-1.71f,0f);
		UpdateScore ();
		UpdateLife();
		UpdateTime ();
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
	
	public void RemoveLife()
	{
		life -= 1;
		UpdateLife();
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
	public void Win()
	{
		Application.LoadLevel ("Win1");
		win = true;
	}
}
