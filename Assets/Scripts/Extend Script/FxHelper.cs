using UnityEngine;
using System.Collections;

// FXHelper digunakan untuk handle fx (particle system), ketika player / enemy destroy.
public class FxHelper : MonoBehaviour {

	// buat FXHelper accesable
	public static FxHelper instanceFX;
	// setup crash effect
	public ParticleSystem crashParticle;
	// setup explode effects
	public ParticleSystem deadParticle;
	// setiap awake
	void Awake()
	{
		// instance dirinya sendiri
		instanceFX = this;
	}

	//  crash fx
	public void CrashFX(Vector2 position)
	{
		create(crashParticle, position);
		create(deadParticle, position);
	}
	// deadfx
	public void DeadFX(Vector2 position)
	{
		create(deadParticle, position);
	}

	// isi method create
	private ParticleSystem create(ParticleSystem prefab, Vector3 position)
	{
		ParticleSystem fx = Instantiate(prefab, position, Quaternion.identity) as ParticleSystem;
		Destroy(fx.gameObject, fx.startLifetime);
		return fx;
	}
}
