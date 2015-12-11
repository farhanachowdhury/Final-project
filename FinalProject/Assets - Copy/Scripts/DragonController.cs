using UnityEngine;
using System.Collections;

public class DragonController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public float speed = 0.01f;
	public bool fire = false;
	public float Range = 300;

	public GameObject fireball;
	public Transform fireSpawn;

	private Transform _playerTransform;
	private SimplePlatformController _playerController;
	private Animator anim;
	// PRIVATE INSTANCE VARIABLES
	private Transform _transform;
	

	private int counter = 0;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		this._transform = gameObject.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (counter >= Range && counter < Range+80) {
			this.anim.SetBool ("fire", true);
			if (counter == Range+20){
				Instantiate (fireball, fireSpawn.position, fireSpawn.rotation);
				//GetComponet<AudioSource>.Play();
			}

		} else if (counter == Range + 80) {
			this.anim.SetBool ("fire", false);
			counter = 0;
			this._transform.position += new Vector3(speed,0,0);
		} else {
			this._transform.position += new Vector3(speed,0,0);
		}
		counter += 1;
	}
}
