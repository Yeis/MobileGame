using UnityEngine;
using System.Collections;

public class TouchLogic : MonoBehaviour {


	public GameObject Contenido;

	//variables 
	public float Speed;
	public float Multiplier;

	//-55.55 es el limite del vaso 

	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void OnMouseDown()
	{
		Debug.Log ("Pressed left click.");

	}
	void Update ()
	{
		if (Input.GetMouseButton (0))
			Contenido.transform.Translate (new Vector3 (0.0f, 1.0f));
		// {
		//	Debug.Log ("Released left click.");
		//
		//}
	}
}
