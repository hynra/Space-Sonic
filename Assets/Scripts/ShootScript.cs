using UnityEngine;
using System.Collections;

public class ShootScript : MonoBehaviour {

	public int dammage = 1;
	public bool isEnemyShot = false;
	public Sprite lightDestroy;
	public float laserTime;
	private float increament;
	

	void Update()
	{
		laserTime -= Time.deltaTime;
		if (laserTime <= 0) {
			Destroy(gameObject);
		}
	}


	void FixedUpdate()
	{
		if (!isEnemyShot) {
			this.transform.Translate (Vector2.up * 6 * Time.deltaTime);
		} else {
			this.transform.Translate (Vector2.up * -6 * Time.deltaTime);
		}
	}

	void OnCollisionEnter2D( Collision2D coll)
	{
		if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "Enemy") 
		{
			gameObject.transform.localScale = new Vector2 (1, 1);
			gameObject.GetComponent<SpriteRenderer> ().sprite = lightDestroy;
			gameObject.GetComponent<BoxCollider2D> ().isTrigger = true;
			Destroy (gameObject, 0.05f);
		} else {
			Destroy(gameObject);
		}
	}
}
