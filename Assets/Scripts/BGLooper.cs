using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {

	public float posMin = -2.359058f;		// value for min random position of x
	public float posMax = 2.245874f;		// ... and it's for max.
	private SpriteRenderer sRender;			// reference for initial SpriteRendere component.

	void Start () {
		// collect all game object with tag Meteor first.
		GameObject[] meteors = GameObject.FindGameObjectsWithTag ("Meteor");
		// for every single meteor game object, we need to do something
		foreach (GameObject meteor in meteors) {
			//... place every meteor to some random x positions
			Vector2 pos = meteor.transform.position;
			pos.x = Random.Range(posMin, posMax);
			meteor.transform.position = pos;
			//... don't forget for rotation, also random
			meteor.transform.rotation = Quaternion.Euler(0,0, Random.Range(0,90));
			//... ah, give that some variations. just play around with color of spriterenderer.
			sRender = meteor.GetComponent<SpriteRenderer>();
			sRender.color = new Color(Random.Range(0.7f, 1.0f), Random.Range(0.7f, 1.0f), Random.Range(0.7f, 1.0f));
		}
		// collect all game object with tag Stars first.
		GameObject[] stars = GameObject.FindGameObjectsWithTag ("Star");
		// for every single star game object, we need to do something
		foreach (GameObject star in stars) {
			//... place every star to some random x positions.
			Vector2 pos = star.transform.position;
			pos.x = Random.Range(posMin, posMax);
			star.transform.position = pos;
		}
	}

	// do looper thing in this void
	void OnTriggerEnter2D(Collider2D coll)
	{
		// First, we need the backgrounds look like looper (parallax).
		//So, if trgigered with tag Background, move that to right position
		if (coll.tag == "Background") {
			//... just find the best number to calculate with vector2-up.
			coll.transform.Translate (Vector2.up * 7.66f);
		}
		//And if triggered with tag Meteor, do something like...
		if (coll.tag == "Meteor") {
			//... throw it to above camera (y position), so they are move again repeatly
			Vector2 pos = coll.transform.position;
			pos.y = transform.position.y + 8;
			pos.x = Random.Range(posMin, posMax);
			coll.transform.position = pos;
			//... give that shit random rotation too
			coll.transform.rotation = Quaternion.Euler(0,0, Random.Range(0,90));
			//... last, also give some random color too.
			sRender = coll.GetComponent<SpriteRenderer>();
			sRender.color = new Color(Random.Range(0.7f, 1.0f), Random.Range(0.7f, 1.0f), Random.Range(0.7f, 1.0f));
		}
		// If triggered with tag Star, throw it to above camera too, so they're move repeatly.
		if (coll.tag == "Star") {
			sRender = coll.GetComponent<SpriteRenderer>();
			Vector2 pos = coll.transform.position;
			pos.y = transform.position.y + 8;
			pos.x = Random.Range(posMin, posMax);
			coll.transform.position = pos;
		}
		// Nah, if we meet the cunts, kill her.
		if (coll.tag == "Enemy") {
			Destroy(coll.gameObject);		
		}
	}
}
