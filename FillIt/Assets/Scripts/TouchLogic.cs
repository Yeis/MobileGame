using UnityEngine;
using System.Collections;

public class TouchLogic : MonoBehaviour {

	public GameObject Vaso;
    GameObject Contenido;
	GameObject Vaso_Actual;
	//variables 
	public float Speed;
	public float Multiplier;
	public float Score;

	//-55.55 es el limite del vaso 

	// Use this for initialization
	void Start () {
//		Score = 0f;
//		Multiplier = 1f;
//		Speed = 10f;
		Vaso_Actual = GameObject.Find("Vaso");
		Contenido = GameObject.Find ("Vaso/Panel_Mask/Liquid");
	}
	
	// Update is called once per frame
	void OnMouseDown()
	{
		Debug.Log ("Pressed left click.");

	}
	void Update ()
	{
		if (Input.GetMouseButton (0)) {
			if (Contenido.transform.position.y < 69) {
                	Debug.Log (Contenido.transform.position.y);

                Contenido.transform.Translate (new Vector3 (0.0f, 1.0f * Speed ));
			} else {
				PerfectfillIt ();
			}
		}
		// {
		//	Debug.Log ("Released left click.");
		//
		//}
	}

	void Reset()
	{

		Debug.Log ("Se ha perdido la racha");
		Speed = 10f;
		Multiplier = 1f;
		Contenido.transform.position = new Vector3 (-1.7f, -80f, 0.0f);
	}
	void PerfectfillIt()
	{
		Debug.Log ("llenado Perfecto");
		var anim = Vaso_Actual.GetComponent<Animator> ();
		anim.SetBool ("Completed", true);
		anim.SetTrigger ("Completed");
		Destroy (Vaso_Actual, 3f);

		//Posicion momentanea
		bool nuevo = true ;
		if (nuevo) {
			GameObject nuevoVaso =  GameObject.Instantiate(Vaso,new Vector3(10,-80f,0.0f),new Quaternion()) as GameObject;
			nuevoVaso.transform.parent = GameObject.Find ("Canvas").transform;
			nuevo = false; 
		}
	}
}
