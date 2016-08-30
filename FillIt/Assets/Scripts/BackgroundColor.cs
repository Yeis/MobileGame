using UnityEngine;
using System.Collections;

public class BackgroundColor : MonoBehaviour {

	// Use this for initialization

	//Colores 
	//Amarillo CDBB2F   205 187 47
	//Azul 1F1256  31 18 87
	//Morado 52, 15 , 91 
	//Cyan 84, 14, 68 
	//64 119 30
	// 95 75 185
	Color[] Color_Array;
	Camera camara;
	int num_fondo = 0;
	void Start ()
	{
		Color_Array = new Color[] {
			new Color (205f / 255.0f, 187f/ 255.0f, 47f/ 255.0f,1f),
			new Color (31f/ 255.0f, 18f/ 255.0f, 87f/ 255.0f,1f),
			new Color (52f/ 255.0f, 15f/ 255.0f, 91f/ 255.0f,1f),
			new Color (84f/ 255.0f, 14f/ 255.0f, 68f/ 255.0f,1f),
			new Color (64f/ 255.0f, 119f/ 255.0f, 30f/ 255.0f,1f),
			new Color (95f/ 255.0f, 75f/ 255.0f, 185f/ 255.0f,1f)
		};
		camara = GameObject.Find ("Main Camera").GetComponent<Camera> ();
		InvokeRepeating ("ChangeColor", 1f, 5f);
	

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void ChangeColor ()
	{

		camara.backgroundColor = Color_Array [num_fondo];
		// return  new WaitForSeconds(5f);

		if (num_fondo == 5)
		{
			num_fondo = -1;
		}
		num_fondo++;
		//Debug.Log (num_fondo.ToString ());

	}
}
