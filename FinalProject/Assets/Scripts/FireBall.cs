using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {
	public float speed=0.4f;
	private Transform _transform;
	//private Animator anim;
	private Rigidbody2D rb2d;
	private bool start = false;
	private Animator anim;
	// Use this for initialization
	void Awake () {
		//anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		this._transform = gameObject.GetComponent<Transform> ();
	}
	void Start () {
	}
	void Update () {
		//this._transform.position += new Vector3(speed,0,0);
		if (start) {
			this.anim.SetBool ("fireStart", true);
		}
		//this._transform.position += new Vector3(speed,0,0);

		rb2d.AddForce (Vector2.right * 200);
		rb2d.velocity = new Vector2 (Mathf.Sign (rb2d.velocity.x) * speed, rb2d.velocity.y);

		start = true;

	}
	// Destroy the fireball if hit by player.
	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			//GetComponent<AudioSource> ().Play ();
			/*
			gameObject.GetComponent<Renderer> ().enabled = false;
			gameObject.GetComponent<CircleCollider2D> ().enabled = false;
			// Delay 1f for the destroy action to ensure the audio is played
			Destroy (gameObject, 1f);
			*/
		}
	}
}
