using UnityEngine;
using System.Collections;

public class ExitPointControllerL3 : MonoBehaviour {
	private GameController gameController;
	public string nextScene;
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Destroy the coin if hit by player.
	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.CompareTag ("Player")){
			gameController.Win(nextScene);
		}
	}
}
