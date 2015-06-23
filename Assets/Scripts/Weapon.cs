using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public Transform laserPrefab;
	public bool isEnemyWeapon = false;
	public float shootDelay = 1.0f;
	private float waitToShoot;

	void Start () {
		waitToShoot = 0f;
	}

	void Update () {

		if (waitToShoot > 0) {
			waitToShoot -= Time.deltaTime;		
		}

		if (Input.GetKeyDown (KeyCode.Space) && isEnemyWeapon == false) {
			Fire();
		}

		if (isEnemyWeapon == true && EnemyAttack == true) {
			waitToShoot = shootDelay;
			var shootLaser = Instantiate (laserPrefab) as Transform;
			Vector2 pos = shootLaser.transform.position;
			pos.x = transform.position.x;
			pos.y = transform.position.y - 0.1f;
			shootLaser.transform.position = pos;
			SoundHelper.instanceSound.EnemyLaserSound();
		}
	}


	public void Fire()
	{
		var shootLaser = Instantiate(laserPrefab) as Transform;
		Vector2 pos = shootLaser.transform.position;
		pos.x = transform.position.x;
		pos.y = transform.position.y + 0.5f;
		shootLaser.transform.position = pos;
		SoundHelper.instanceSound.PlayerLaserSound();
	}

public bool EnemyAttack
	{
		get
		{
			return waitToShoot <= 0f;
		}
	}
}