using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

//	public Transform followObject;
	public BoxCollider2D leftObstacle;
	public BoxCollider2D rightObstacle;
	public BoxCollider2D topObstacle;
	private Camera mainCam;
	public float speed = 0.5f;
	
	private float initialOffset;
	
	// Use this for initialization
	void Start ()
	{
		mainCam = this.GetComponent<Camera>();

		leftObstacle.size = new Vector2 (1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
		leftObstacle.offset = new Vector2 (mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 0.7f , 0f);

		rightObstacle.size = new Vector2 (1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
		rightObstacle.offset = new Vector2 (mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + 0.7f, 0f);
	
		topObstacle.size = new Vector2 (mainCam.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
		topObstacle.offset = new Vector2 (0f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y + 0.45f);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		transform.Translate (Vector2.up * speed * Time.deltaTime);
	}
}
