using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public int score = 0;
	private int highscore = 0;
	public GUIText scoreText;


	void Start()
	{
//		PlayerPrefs.DeleteAll ();
		if (PlayerPrefs.GetInt ("Score") <= 0) {
			score = 0;
		} else {
			score = PlayerPrefs.GetInt("Score");
		}
		if (PlayerPrefs.GetString ("Level") == "") {
			PlayerPrefs.SetString("Level", Application.loadedLevelName);		
		}

		highscore = PlayerPrefs.GetInt ("Best");

	}

	 public void AddPoint()
	{
		score++;
		if (score > highscore) {
			highscore = score;
		}
	}

	void OnDestroy()
	{
		PlayerPrefs.SetInt("Best", highscore);
	
	}

	void Update()
	{
		scoreText.text = "Score : " + score + "\nbest : "+highscore;
	}
}
