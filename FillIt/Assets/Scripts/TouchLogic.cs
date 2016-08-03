using UnityEngine;
using System.Collections;

public class TouchLogic : MonoBehaviour {

	public GameObject Vaso;
    GameObject Contenido;
	GameObject Cube_Collider;
	GameObject Vaso_Actual;
	//variables 
	Animator anim;
	public float Speed;
	public float Multiplier;
	public float Score;
	public float Cantidad_Vasos = 1 ;
	public ParticleSystem Soda;


	//variables locales 
	public bool Comenzar_Llenado = false;
	//-55.55 es el limite del vaso 

	void Awake()
	{
		Soda.Stop ();
	}

	// Use this for initialization
	void Start () {
//		Score = 0f;
//		Multiplier = 1f;
//		Speed = 10f;
		Soda.Stop ();
		Vaso_Actual = GameObject.Find("Vaso");
		Contenido = GameObject.Find ("Vaso/Panel_Mask/Liquid");
		Cube_Collider = GameObject.Find ("Cube");
	 	anim = Vaso_Actual.GetComponent<Animator> ();
	}
	

	void Update ()
	{
		//EL vaso debe llenarse siempre y cuando 
		//1- EL vaso exista
		if (Contenido != null) 
		{
			//2-  EL vaso se encuentre en el centro 
			if (Vaso_Actual.transform.position.x == 138)
			{
				//3- Se oprima el mousse o se haga touch en culaquier parte de la pantalla
				if (Input.GetMouseButton (0)) {	
					//4- NO se haya sobrellenado el vaso 
					if (Contenido.transform.position.y < 160  ) {
						//5- El chorro haya llegado hasta abajo 
						if(Comenzar_Llenado == true)
						{
							Contenido.transform.Translate (new Vector3 (0.0f, 1.0f * Speed));	
						}


						Soda.Play ();
				
						//Contenido.transform.Translate (new Vector3 (0.0f, 1.0f * Speed));
					} else {
						Soda.Stop ();
						ChangeGlass ();
					}
				}
			//no se esta presionando el boton
			else 
				{
					Soda.Stop ();
				}
			}
		} 
		else
		{
			Soda.Stop ();
			InicializaVaso ();
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

	void InicializaVaso()
	{
		Debug.Log ("COnfigurando vaso para que comienza su llenado ");
		Cantidad_Vasos--;
		Vaso_Actual = GameObject.Find("Vaso");
		Contenido = GameObject.Find ("Vaso/Panel_Mask/Liquid");
		anim = Vaso_Actual.GetComponent<Animator> ();
		anim.SetBool ("Inicializa", true);
		//anim.SetBool ("Completed", false);
		anim.SetTrigger ("Inicializa");

		//Hacemos randoms los colores 



	}
	void OnParticleCollision(GameObject Other)
	{
		Debug.Log ("Particulas estan colisionando con: "+ Other.name);
	}
	void ChangeGlass()
	{
		Debug.Log ("Cambio de Vaso");
		Vector3 centrado = Vaso_Actual.transform.position;
		anim.SetBool ("Completed", true);
		anim.SetTrigger ("Completed");
		Comenzar_Llenado = false;
		Destroy (Vaso_Actual,2.0f);
		//Posicion momentanea
		if (Cantidad_Vasos == 1 ) {

			//Solo queremos tener un vaso 
			GameObject vasonuevo =  GameObject.Instantiate(Resources.Load("Vaso", typeof(GameObject)),new Vector3(-250.0f,0.0f,0.0f),new Quaternion()) as GameObject;
			//GameObject vasonuevo =  GameObject.Instantiate(Vaso,new Vector3(0.0f,0.0f,0.0f),new Quaternion()) as GameObject;
			vasonuevo.transform.parent = GameObject.Find ("Canvas").transform;
			//Contenido.transform.Translate (0.0f, -150.0f, 0.0f);
			vasonuevo.name = "Vaso";
			Cantidad_Vasos++;
		}
	
	}
}
