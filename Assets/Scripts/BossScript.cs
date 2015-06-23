using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour {

	private bool enemySpawn;
	private Weapon[] addWeapons;
	public float speed;
	private float posMin = -1.719578f;
	private float posMax = 1.653888f;
	public bool moveRight;
	public GameObject mainCam;
	private float coolDown;
	public float attackTime;
	private Weapon weapon;
//	private Score scoreGui;
	private Health health;


	
	void Start()
	{

		health = GetComponent<Health> ();
//		scoreGui = GameObject.Find ("GUI").GetComponentInChildren<Score> ();
		coolDown = attackTime;

		addWeapons = GetComponentsInChildren<Weapon> ();
		weapon = GetComponent<Weapon> ();

		GetComponent<Collider2D>().isTrigger = true;
		
		float initialMove = Random.Range(1, 10);
		if (initialMove <= 5) {
			moveRight = true;		
		} 
		else if (initialMove > 5) {
			moveRight = false;	
		}
		
		
		
		enemySpawn = false;
		foreach (Weapon addWeapon in addWeapons) {
			addWeapon.enabled = false;
		}
		Vector2 pos = transform.position;
		pos.x = Random.Range (posMin, posMax);
		transform.position = pos;
		
	}
	
	
	void Update()
	{
		if (coolDown > 0) {
			coolDown -= Time.deltaTime;
		}
		if (coolDown <= 0) {
			coolDown = attackTime;	
		}
		if (enemySpawn == true && BossNotAttack == false) {	
			foreach (Weapon addWeapon in addWeapons){
				addWeapon.enabled = true;	
				}
			weapon.enabled = false;
			}
		else if( enemySpawn&& BossNotAttack)
		{
			weapon.enabled = true;
		}


		if (health.hp == 0) {
			ActionHelper.instanceAction.FinishLevel();
			FxHelper.instanceFX.CrashFX(transform.position);
		}
	
	}
	
	
	void FixedUpdate()
	{ 
		if(enemySpawn) {
			Spawn ();	
		}
	}
	
	private void Spawn()
	{

		if (moveRight == true) {
			transform.Translate (Vector2.right * speed * Time.deltaTime);
		} 
		if(moveRight == false)
		{
			transform.Translate (Vector2.right * -speed * Time.deltaTime);;
		}
		
	}


	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "BorderLeft") {
			moveRight = true;
		}
		
		if (coll.gameObject.tag == "BorderRight") {
			moveRight = false;
		}
		if (coll.gameObject.tag == "Player Laser") {
			Score scoreScript = GameObject.Find("GUI").GetComponent<Score>();
			scoreScript.AddPoint();		
		}
	}


	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "BorderTop") {
			enemySpawn = true;
			GetComponent<Collider2D>().isTrigger = false;
		//	transform.Translate(Vector2.up * -0.1f);
			transform.parent = mainCam.transform;
			transform.localPosition  = new Vector2(transform.position.x, 4.8f);
		}
	}

	public bool BossNotAttack
	{
		get
		{
			return coolDown >= 0f && coolDown <= 2f;
		}
	}
}
