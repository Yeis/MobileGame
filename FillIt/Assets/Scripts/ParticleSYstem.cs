using UnityEngine;
using System.Collections;

public class ParticleSYstem : MonoBehaviour {
	

	public ParticleSystem Soda;
	GameObject gameLogic;
	TouchLogic logic;
	public float Speed;
	//var script;
	// Use this for initialization
	void Awake()
	{
		gameLogic = GameObject.Find ("GameLogic");
		logic = gameLogic.GetComponent<TouchLogic> ();
	//	Soda.Stop ();
	}
	void Start () {
	//	Soda.Stop ();
	//	script = GameObject.Find ("GameLogic").GetComponent(TouchLogic);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButton (0) )
		{
			//Soda.Play ();	
		} 
		else
		{
			//Soda.Stop();
		}
	}
	void OnParticleCollision(GameObject Other)
	{
		if(logic.Comenzar_Llenado == false)
		{
			logic.Comenzar_Llenado = true;
		}
	}


}
