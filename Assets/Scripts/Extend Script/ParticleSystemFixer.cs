using UnityEngine;
using System.Collections;

public class ParticleSystemFixer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "Player";
	}
}
