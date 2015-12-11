using UnityEngine;
using System.Collections;

public class FlowerController : MonoBehaviour {
	// PRIVATE INSTANCE VARIABLES
	private Rigidbody2D _rigidbody2D;
	private Transform _transform;

	private GameController gameController;
	
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
		this._rigidbody2D = gameObject.GetComponent<Rigidbody2D> ();
		this._transform = gameObject.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	// Remove 1 life if the player hit the flower.
	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.CompareTag ("Player")){
			GetComponent<AudioSource>().Play();
			gameController.TakeDamage();
		}
	}
}
