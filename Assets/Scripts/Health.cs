using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	
	public int hp;						// value for hp.
	public bool isEnemy = true;			// bool if health script's owner is enemy.
	private GameObject gui;		// var for GUI Health
//	private Score guiScore;
	
	
	void Start()
	{
		gui = GameObject.Find ("GUI");

		if (gui == null)
			Debug.LogError ("There is no game object named GUIHealth");
	}
	
	// Do that on collision from bullet / laser
	void OnCollisionEnter2D( Collision2D coll)
	{
		ShootScript shot = coll.gameObject.GetComponent<ShootScript> ();
		if (shot != null) {
			if (isEnemy) {
				hp -= shot.dammage;
			}
			else{
				if (hp == 1) {
					hp -= shot.dammage;
					gui.SendMessage ("MinHealth", 1);
				} 
				else{
					hp -= shot.dammage;
					gui.SendMessage ("MinHealth", shot.dammage);
				}
			}
		}
	}
	
	void Dead()
	{
		hp = 0;
		gui.SendMessage("Dead");
	}
	
	void AddHp()
	{
		hp++;
	}
	
	void Update()
	{
		if(hp <= 0)
		{
			if(!isEnemy)
			{
				ActionHelper.instanceAction.GameOver();
			}
			FxHelper.instanceFX.CrashFX(transform.position);
			SoundHelper.instanceSound.DeadSound();
			Destroy(gameObject);
		}
	}
}
