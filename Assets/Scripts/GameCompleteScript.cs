using UnityEngine;
using System.Collections;

public class GameCompleteScript : MonoBehaviour {

	public bool isNextButton;
	public string nextLevel;

	void OnMouseUp()
	{
		if (isNextButton) {
			Application.LoadLevel (nextLevel);		
		} else {
			Application.LoadLevel("Menu");
		}
	}
}
