using UnityEngine;
using System.Collections;

public class TouchControl : MonoBehaviour {

	public GUITexture moveLeft;
	public GUITexture moveRight;
	public GUITexture fire;
	public GameObject player;
	private PlayerMovement playerMove;
	private Weapon[] weapons;

	void Start()
	{
		playerMove = player.GetComponent<PlayerMovement> ();
	}

	void CallFire()
	{
		weapons = player.GetComponentsInChildren<Weapon> ();
		foreach (Weapon weapon in weapons) {
			if(weapon.enabled == true)
			weapon.Fire();		
		}
	}

	void Update()
	{
//		int i = 0;
		if(Input.touchCount > 0)
		{
			for(int i =0; i < Input.touchCount; i++)
			{
//			if(moveLeft.HitTest(Input.GetTouch(i).position, Camera.main))
//			{
//				if(Input.touchCount > 0)
//				{
//					playerMove.MoveLeft();
//				}
//			}
//			if(moveRight.HitTest(Input.GetTouch(i).position, Camera.main))
//			{
//				if(Input.touchCount > 0)
//				{
//					playerMove.MoveRight();
//				}
//			}
//			if(moveLeft.HitTest(Input.GetTouch(i).position, Camera.main))
//			{
//				if(Input.touchCount > 0)
//				{
//					CallFire();
//				}
//			}
				Touch t = Input.GetTouch (i);
				Input.multiTouchEnabled = true;

				if(t.phase == TouchPhase.Began || t.phase == TouchPhase.Stationary)
				{
					if(moveLeft.HitTest(t.position, Camera.main))
					{
						playerMove.MoveLeft();
					}
					if(moveRight.HitTest(t.position, Camera.main))
					{
						playerMove.MoveRight();
					}
				}
				if(t.phase == TouchPhase.Began)
				{
					if(fire.HitTest(t.position, Camera.main))
					{
						CallFire();
					}
				}


				if(t.phase == TouchPhase.Ended)
				{

				}
			}
		}
	}
}
