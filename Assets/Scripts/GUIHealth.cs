using UnityEngine;
using System.Collections;

public class GUIHealth : MonoBehaviour {

	public Transform healthUI;
	private GameObject[] healthTexture;
	private int lastObj;
	public int initHealthPlus;

	void Start()
	{

		for (int i = 1; i <= initHealthPlus; i++) {
			AddHealth();		
		}
	}


	public void AddHealth()
	{
		healthTexture = GameObject.FindGameObjectsWithTag ("HealthUI");
		lastObj = healthTexture.Length - 1;
		var addUI = Instantiate(healthUI) as Transform;
		Vector2 pos = addUI.transform.position;
		addUI.transform.parent = this.transform;
		pos.x = healthTexture[lastObj].transform.position.x + 0.09f;
		addUI.transform.position = pos;
	}


	void MinHealth(int dammage)
	{
		int counter= 1;
		while (counter <= dammage) {
			healthTexture = GameObject.FindGameObjectsWithTag ("HealthUI");
			lastObj = healthTexture.Length - counter;
			Destroy (healthTexture [lastObj]);
			counter++;
		}
	}

	void Dead()
	{

		healthTexture = GameObject.FindGameObjectsWithTag ("HealthUI");
		for (int i = 0; i <= healthTexture.Length - 1; i++) {
			Destroy(healthTexture[i]);		
		}
	}
}

