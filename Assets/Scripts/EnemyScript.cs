using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	private bool enemySpawn;			// bool enemy is spawn
	private Weapon[] theweapons;		// get the weapons
	public float speed;					// speed of enemy right / left
	private float posMin = -1.719578f;	// minimal random x position
	private float posMax = 1.653888f;	// max random x position
	public bool moveRight;				// check enemy move to right / left
	

	void Start()
	{	

		// reference the weapons script to 'theWeapons'
		theweapons = GetComponentsInChildren<Weapon> ();
		// set all weapon's enemy off when start
		foreach (Weapon weapon in theweapons) {
			weapon.enabled = false;
		}
		// give random speed, you know variations
		speed = Random.Range(speed, speed*2);
		// first moving of enemy : left / right. Also, give random
		float initialMove = Random.Range(1, 10);
		if (initialMove <= 5) {
			moveRight = true;		
		} 
		else if (initialMove > 5) {
			moveRight = false;	
		}
		// set enemy spawn to false, so they are not moved at first
		enemySpawn = false;
		// set x transform of enemy at random position
		Vector2 pos = transform.position;
		pos.x = Random.Range (posMin, posMax);
		transform.position = pos;
		// at first, we set enemy's collider trigger to true, so they can OnTriggerEnter2D()
		GetComponent<Collider2D>().isTrigger = true;
	}


	void Update()
	{
	}


	void FixedUpdate()
	{
		// if enemySpawn is true, we need enemy to spawn / moved
		if (enemySpawn == true) {
			// ... so we call Spawn() function to do that
			Spawn();	
		}
	}

	// ... and here reference of what is Spawn() for
	private void Spawn()
	{

		//  we decided enemy at random movement to right / left at Start()
		//... so if moveRight is true, move it to right
		if (moveRight) {
			transform.Translate (Vector2.right * speed * Time.deltaTime);
		} 
		//... but, if false move it to left
		if(!moveRight)
		{
			transform.Translate (Vector2.right * -speed * Time.deltaTime);;
		}

	}


	// detect collision enter, we use it for enemy logic movement (right / left)
	void OnCollisionEnter2D(Collision2D coll)
	{
		// if enemy collision with gameobject tag's BorderLeft, move it to right.
		if (coll.gameObject.tag == "BorderLeft") {
			moveRight = true;
		}
		// if enemy collision with gameobject tag's BorderRight, move it to left.
		if (coll.gameObject.tag == "BorderRight") {
			moveRight = false;
		}
		// yea, if enemy hit player laser, make it point!
		if (coll.gameObject.tag == "Player Laser") {
			//... declare where Score attached.
			Score scoreScript = GameObject.Find("GUI").GetComponent<Score>();
			scoreScript.AddPoint();		
		}
	}

	// detect Trigger enter, we use it for switch enemySpawn from false to true, so they're move
	void OnTriggerEnter2D(Collider2D coll)
	{
		// if enemy triggered with collider's tag BorderTop, wake him up!
		if (coll.tag == "BorderTop") {
			//... but first, let's give that a little pull to fit with camera
			transform.Translate(Vector2.up * -8 *Time.deltaTime);
			//... wakeup, you little cunt!
			enemySpawn = true;
			//... set trigger to false again, let the enemy receive the dammage!
			GetComponent<Collider2D>().isTrigger = false;
			// set every weapon to active!
			foreach (Weapon weapon in theweapons) {
				weapon.enabled = true;		
			}
		}
	}
}
