using UnityEngine;
using System.Collections;

public class SoundHelper : MonoBehaviour {

	public AudioClip bonusUp;
	public AudioClip bonusDown;
	public AudioClip pickUp;
	public AudioClip playerLaser;
	public AudioClip enemyLaser;
	public AudioClip deadSound;
	public AudioClip finish;

	public static SoundHelper instanceSound;

	void Awake()
	{
		instanceSound = this;
	}

	private void PlaySound(AudioClip clip)
	{
		GetComponent<AudioSource>().PlayOneShot (clip);
	}

	public void BonusUpSound()
	{
		PlaySound (bonusUp);
	}

	public void BonusDownSound()
	{
		PlaySound (bonusDown);
	}

	public void PickUpSound()
	{
		PlaySound (pickUp);
	}

	public void PlayerLaserSound()
	{
		PlaySound (playerLaser);
	}

	public void EnemyLaserSound()
	{
		PlaySound (enemyLaser);
	}

	public void DeadSound()
	{
		PlaySound (deadSound);
	}

	public void FinishSound()
	{
		PlaySound (finish);
	}
}
