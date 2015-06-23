using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	public bool isRetryButton;

	void OnMouseUp()
	{
		if (isRetryButton) {
			Application.LoadLevel (Application.loadedLevelName);		
		} else {
			Application.LoadLevel("Menu");
		}
	}
}
