using UnityEngine;
using System.Collections;

public class Particle_Collider : MonoBehaviour {
	public ParticleSystem Soda;

	// Use this for initialization
	void Start () {
		//Soda.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnParticleCollision(GameObject Other)
	{
		Debug.Log ("Particulas estan colisionando ");
	}
}
