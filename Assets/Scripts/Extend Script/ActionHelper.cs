using UnityEngine;
using System.Collections;
// Action helper digunakan sebagai helper ketika player game over & finish level
public class ActionHelper : MonoBehaviour {

	private CameraFollow camFo;			// ref script CameraFollow
	private GameObject[] lasers;		// ref semua objek lasers
	private GameObject[] enemies;		// ref semua objek enemy
	public GameObject gameCompleteGui;	// GUI yg tampil apabila level complete
	public GameObject gameoverGui;		// GUI yg tampil apabila game over
	private GameObject guiObj;			// ref objek GUI
	public string nextLevel;			// Ref untuk level selanjutnya.
	// var supaya ActionHelper dapat diakses dr script lain.
	public static ActionHelper instanceAction; 

	// Setiap objek Awake.
	void Awake()
	{
		// menginstance this, supaya Actionhelper static (Accessable).
		instanceAction = this;
	}

	// Setiap scene pertama kali running
	void Start()
	{
		// reference camFo, script harus terdapat pada Main Camera.
		camFo = GameObject.Find("Main Camera").GetComponent<CameraFollow> ();
		//... jika null
		if (camFo == null) 
						Debug.Log ("Tidak terdapat game objek dg nama Main Camera. Lihat CameraFollow.cs");
		// reference guiObj sebagai objek game GUI
		//...  GUI berisi GUI Score, GUI Health, GUI Bonustime
		guiObj = GameObject.Find("GUI");
		//... Jika null
		if(guiObj == null)
			Debug.LogError("Tidak Ada objek dengan nama GUI");
	}

	// Kondisi ketika level complete. 
	public void FinishLevel()
	{
		// Play game finish sound.
		SoundHelper.instanceSound.FinishSound();
		// kolektif semua objek dengan tag Player Laser
		lasers = GameObject.FindGameObjectsWithTag ("Player Laser");
		//... untuk setiap Player laser
		foreach (GameObject laser in lasers) {
			//... buat collider menjadi true tidak collision
			laser.GetComponent<Collider2D>().isTrigger = true;		
		}
		// buat script Camera Follow nonaktif
		camFo.enabled = false;
		// tampilkan GUI game complete
		gameCompleteGui.SetActive (true);
		// kolektif semua game objek enemy
		enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		//... Untuk setiap enemy
		foreach (GameObject enemy in enemies) {
			//... buat nonaktif
			enemy.SetActive(false);		
		}
		// Reference script Score dari GameObject GUI (guiObj)
		Score scoreScript = guiObj.GetComponent<Score> ();
		// Set score ke PlayerPrefs dari value score dari script Score
		PlayerPrefs.SetInt ("Score", scoreScript.score);
		// isikan value untuk level selanjutnya, sehingga tampil di menu.
		PlayerPrefs.SetString("Level", nextLevel);
	}
	
	// Kondisi ketika game over
	public void GameOver()
	{
		// koleksi semua objek enemy laser
		lasers = GameObject.FindGameObjectsWithTag ("Enemy Laser");
		// Untuk setiap laser
		foreach (GameObject laser in lasers) {
			//... Buat trigger, sehingga tak terjadi collision
			laser.GetComponent<Collider2D>().isTrigger = true;		
		}
		// buat Script CameraFollow nonaktif
		camFo.enabled = false;
		// Tampilkan tampilan GameOver
		gameoverGui.SetActive (true);
		// koleksi semua objek enemy
		enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		// untuk setiap objek enemy
		foreach (GameObject enemy in enemies) {
			//... buat semua enemy nonaktif
			enemy.SetActive(false);		
		}
		// nonaktifkan objek GUI
		guiObj.SetActive (false);
	}

}
