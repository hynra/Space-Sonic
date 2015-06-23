using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public GUISkin menuSkin;
	private bool setting;
	private bool credit;
	private bool newGame;


	void OnGUI()
	{

			GUI.skin = menuSkin;
			GUILayout.BeginArea (new Rect (0, 0, Screen.width, Screen.height));
			GUILayout.FlexibleSpace ();
			GUILayout.BeginVertical (GUI.skin.window);

			GUILayout.BeginHorizontal ();
			GUILayout.FlexibleSpace ();
			GUILayout.Box ("", GUILayout.Width (Screen.width / 1.1f), GUILayout.Height (130));
			GUILayout.FlexibleSpace ();
			GUILayout.EndHorizontal ();

		if (! setting && !credit && !newGame) {

			if (PlayerPrefs.GetInt ("Score") > 0) {
				GUILayout.FlexibleSpace ();
				GUILayout.Label (PlayerPrefs.GetString ("Level") + "\nScore : " + PlayerPrefs.GetInt ("Score").ToString () + "\nHighscore : " + PlayerPrefs.GetInt ("Best").ToString (), GUILayout.Height (55));
				GUILayout.FlexibleSpace ();
			}

			GUILayout.FlexibleSpace ();
			if (PlayerPrefs.GetInt ("Score") > 0) {
				if (GUILayout.Button ("Continue", GUILayout.Height (50))) {
					Application.LoadLevel (PlayerPrefs.GetString ("Level"));
				}
			}

			if (GUILayout.Button ("New Game", GUILayout.Height (50))) {
				if (PlayerPrefs.GetInt ("Score") <= 0)
					Application.LoadLevel ("Level 1");
				else if(PlayerPrefs.GetInt("Score") > 0)
					newGame = true;
			}

			if (GUILayout.Button ("Setting", GUILayout.Height (50))) {
				setting = true;
			}

			if (GUILayout.Button ("Credit", GUILayout.Height (50))) {
				credit = true;
			}

			if (GUILayout.Button ("Exit", GUILayout.Height (50))) {
				Application.Quit();
			}

			GUILayout.FlexibleSpace ();
		}

		if (setting) {
			GUILayout.FlexibleSpace();

			GUILayout.Label("Switch On / Off \nof game Sound");

			string soundStatus = "";
			if(AudioListener.volume == 1)
				soundStatus = "Sound On";
			else if(AudioListener.volume == 0)
				soundStatus = "Sound Off";
			if (GUILayout.Button (soundStatus, GUILayout.Height (50))) {
				if(AudioListener.volume ==0)
					AudioListener.volume =1;
				else if(AudioListener.volume ==1)
					AudioListener.volume = 0;
			}
			GUILayout.Label("reset score, best score \n and levels");
			if (GUILayout.Button ("ResetS", GUILayout.Height (50))) {
				PlayerPrefs.DeleteAll();
			}
			GUILayout.FlexibleSpace();
			if (GUILayout.Button ("< Back", GUILayout.Height (50))) {
				setting = false;
			}
			GUILayout.FlexibleSpace();
		}


		if (credit) {
			GUILayout.FlexibleSpace();
			GUILayout.Label("[ SPACE SONIC V.0.1 ]");
			GUILayout.FlexibleSpace();
			GUILayout.Label("Game Developer : Hynra [Serabutan Dev.]");
			GUILayout.Label("Assets by : Kenney");
			GUILayout.Label("Music : K is for Kraken");
			GUILayout.FlexibleSpace();
			if (GUILayout.Button ("< Back", GUILayout.Height (50))) {
				credit = false;
			}

		}

		if (newGame) {
			GUILayout.FlexibleSpace();
			GUILayout.Label("WARNING!");
			GUILayout.Label("Play new Game will \n reset your score & Levels!");
			if (GUILayout.Button ("Start new game", GUILayout.Height (50))) {
				PlayerPrefs.DeleteKey("Score");
				PlayerPrefs.DeleteKey("Level");
				Application.LoadLevel("Level 1");
			}
			GUILayout.FlexibleSpace();
			if (GUILayout.Button ("< Back", GUILayout.Height (50))) {
				newGame = false;
			}
		}

				GUILayout.EndVertical ();
				GUILayout.FlexibleSpace ();
				GUILayout.EndArea ();
		
	}

}
