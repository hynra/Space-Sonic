using UnityEngine;
using System.Collections;

public class MeteorMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate () {
		transform.Translate(Vector2.up * -1* Time.deltaTime, Space.World);
	}
}
