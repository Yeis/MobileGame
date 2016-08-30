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
	public ParticleSystem D_Izquierda;
	public ParticleSystem D_Derecha;


	//variables locales 
	public bool Comenzar_Llenado = false;
	//-55.55 es el limite del vaso 

	void Awake()
	{
		Soda.Stop ();
		D_Izquierda.Stop ();
		D_Derecha.Stop ();
	}

	// Use this for initialization
	void Start () {
//		Score = 0f;
//		Multiplier = 1f;
//		Speed = 10f;

		//DETENEMOS TODAS NUESTRAS PARTICULAS 
		Soda.Stop ();
		D_Izquierda.Stop ();
		D_Derecha.Stop ();
		//INSTANCIAMOS LOS  OBJETOS NESESARIOS 
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
				if (Input.GetMouseButton (0))
				{	
					//4- NO se haya sobrellenado el vaso 
					if (Contenido.transform.position.y < 150) {
						//5- El chorro haya llegado hasta abajo 
						if (Comenzar_Llenado == true) {
							Contenido.transform.Translate (new Vector3 (0.0f, 1.0f * Speed));	
						}


						Soda.Play ();
				
						//Contenido.transform.Translate (new Vector3 (0.0f, 1.0f * Speed));
					}
					//el vaso se encuntra en el margen de llenado apropiado 
					else if (Contenido.transform.position.y < 160) {
						//SE LLENO EL VASO CORRECTAMENTE 
						Debug.Log ("El Vaso fue llenado correctamente");
						Soda.Stop ();
						ChangeGlass ();

					}
					//NOS PASAMOS CON EL VASO 
					else if (Contenido.transform.position.y >160)
					{
						D_Derecha.Start ();
						D_Izquierda.Start ();
						Debug.Log("El vaso esta demasiado lleno")
					}
				}
			//no se esta presionando el boton
				else if(Input.GetMouseButtonUp(0))
				{
					Soda.Clear ();
					Soda.Stop ();
					ChangeGlass ();
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


	//METODO QUE REPARTE PUNTOS DEPENDIENDO SI EL VASO FUE LLENADO BIEN O NO 
	//SE ENCARGA TAMBIEN DE CORRER ANIMACIONES AL TEXTO 
	void PointsHandler(){
	}


	//EN EL CASO DE QUE EL VASO NO SEA LLENADO EN SU TOTALIDAD RESETEAMOS 
	void Reset()
	{

		Debug.Log ("Se ha perdido la racha");
		Speed = 10f;
		Multiplier = 1f;
		Contenido.transform.position = new Vector3 (-1.7f, -80f, 0.0f);
	}
	//INICIALIZA EL NUEVO VASO Y LO MUEVE A SU POSICION DE LLENADO 
	void InicializaVaso()
	{
		Debug.Log ("Nuevo Vaso Puesto");
		Cantidad_Vasos--;
		Vaso_Actual = GameObject.Find("Vaso");
		Contenido = GameObject.Find ("Vaso/Panel_Mask/Liquid");
		anim = Vaso_Actual.GetComponent<Animator> ();
		anim.SetBool ("Inicializa", true);
		//anim.SetBool ("Completed", false);
		anim.SetTrigger ("Inicializa");
		Comenzar_Llenado = false;
		//Hacemos randoms los colores 



	}
	//METODO QUE SE ENCARGA DE CAMBIAR EL VASO POR UNO NUEVO 
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
