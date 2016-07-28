using UnityEngine;
using System.Collections;

public class TouchLogic : MonoBehaviour {

	public GameObject Vaso;
    GameObject Contenido;
	GameObject Vaso_Actual;
	//variables 
	Animator anim;
	public float Speed;
	public float Multiplier;
	public float Score;
	public float Cantidad_Vasos = 1 ;
	//-55.55 es el limite del vaso 

	// Use this for initialization
	void Start () {
//		Score = 0f;
//		Multiplier = 1f;
//		Speed = 10f;
		Vaso_Actual = GameObject.Find("Vaso");
		Contenido = GameObject.Find ("Vaso/Panel_Mask/Liquid");
	 	anim = Vaso_Actual.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void OnMouseDown()
	{
		Debug.Log ("Pressed left click.");

	}
	void Update ()
	{
		if (Input.GetMouseButton (0)) {	
			if (Contenido.transform.position.y < 160) {
                	Debug.Log (Contenido.transform.position.y);

                Contenido.transform.Translate (new Vector3 (0.0f, 1.0f * Speed ));
			} else {
				StartCoroutine( ChangeGlass ());
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



	IEnumerator ChangeGlass()
	{
		Debug.Log ("Cambio de Vaso");
		Vector3 centrado = Vaso_Actual.transform.position;

		anim.SetBool ("Completed", true);
		anim.SetTrigger ("Completed");

	
		Destroy (Vaso_Actual,2.0f);
		if (!Vaso_Actual)
		{
			Debug.Log ("Cambio de Vaso Satisfactorio");
			Cantidad_Vasos--;
			Vaso_Actual = GameObject.Find("Vaso");
			Contenido = GameObject.Find ("Vaso/Panel_Mask/Liquid");
			anim.SetBool ("Completed", true);
			anim.SetTrigger ("Completed");
			yield return new WaitForSeconds (2.0f);
			anim.SetBool ("Completed", false);
		    anim = Vaso_Actual.GetComponent<Animator> ();
		}
		//Posicion momentanea
		if (Cantidad_Vasos == 1 ) {


			GameObject vasonuevo =  GameObject.Instantiate(Resources.Load("Vaso", typeof(GameObject)),new Vector3(-250.0f,0.0f,0.0f),new Quaternion()) as GameObject;
			//GameObject vasonuevo =  GameObject.Instantiate(Vaso,new Vector3(0.0f,0.0f,0.0f),new Quaternion()) as GameObject;
			vasonuevo.transform.parent = GameObject.Find ("Canvas").transform;
			//Contenido.transform.Translate (0.0f, -150.0f, 0.0f);
			vasonuevo.name = "Vaso";
		
			Contenido = GameObject.Find ("Vaso/Panel_Mask/Liquid");
			Cantidad_Vasos++;
		}
	
	}
}
