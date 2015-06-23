using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float speedMove;
	public float bonusTime;

	private bool toLeft = false;
	private bool toRight = false;
	
	public GameObject shield;
	public GUIText bonustimeText;

	private bool counting = false;
	private float counter;

	private Weapon[] addWeapons;

	public Sprite strongShip;
	public Sprite normalSprite;
	public Sprite shieldSprite;

	private SpriteRenderer sRender;
	private Weapon weaponScript;

	void Start () {

		counter = bonusTime;

		sRender = GetComponent<SpriteRenderer> ();
		addWeapons = GetComponentsInChildren<Weapon> ();
		foreach (Weapon addWeapon in addWeapons) {
			addWeapon.enabled = false;
		}

		weaponScript = GetComponent<Weapon>();
		weaponScript.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.A)) {
			toLeft = true;		
		}
		if (Input.GetKeyUp (KeyCode.A)) {
			toLeft = false;		
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			toRight = true;		
		}
		if (Input.GetKeyUp (KeyCode.D)) {
			toRight = false;		
		}


		if (counting) {
			counter -= Time.deltaTime;
			bonustimeText.text = counter.ToString("#0.0");
		}
	}


	void FixedUpdate()
	{
		if (toLeft) {
			MoveLeft();
		}

		if (toRight) {	
			MoveRight();
		}
	}


	public void MoveLeft()
	{
		transform.Translate(Vector2.right * -speedMove* Time.deltaTime);
	}


	public void MoveRight()
	{
		transform.Translate(Vector2.right * speedMove * Time.deltaTime);
	}


	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "StrongMode") {
			Destroy (coll.gameObject);
			counting = true;
			StrongMode();
			Invoke ("Downgrade", bonusTime);
		}


		if (coll.gameObject.tag == "ShieldMode") {
			Destroy (coll.gameObject);
			counting = true;
			ShieldMode();
			Invoke("Downgrade", bonusTime);
		}

		if (coll.gameObject.tag == "Life") {
			GUIHealth gui = GameObject.Find ("GUI").GetComponent<GUIHealth> ();
			gui.AddHealth();
			SendMessage("AddHp");
			SoundHelper.instanceSound.PickUpSound();
			Destroy(coll.gameObject);
		}

		if (coll.gameObject.tag == "Enemy") {
			SendMessage("Dead");
		}
	}

	void Downgrade()
	{
		SoundHelper.instanceSound.BonusDownSound ();
		counting = false;
		bonustimeText.text = "";
		counter = bonusTime;

		sRender.sprite = normalSprite;
		weaponScript.enabled = true;
		foreach (Weapon addWeapon in addWeapons) {
			addWeapon.enabled = false;
		}
		weaponScript.enabled = true;
		shield.SetActive (false);
	}


	void StrongMode()
	{
		SoundHelper.instanceSound.BonusUpSound ();
		sRender.sprite = strongShip;
		foreach (Weapon addWeapon in addWeapons) {
			addWeapon.enabled = true;
		}
		weaponScript.enabled = false;
	}


	void ShieldMode()
	{
		SoundHelper.instanceSound.BonusUpSound ();
		sRender.sprite = shieldSprite;
		shield.SetActive (true);
	}


//	void OnDestroy()
//	{
//		bonustimeText.text = "";
//	}
}
