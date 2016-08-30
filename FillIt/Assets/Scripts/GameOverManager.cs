using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour {


	public bool didLose;

	Animator anim;

	void Awake()
	{
		//Get Animator
		anim = GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
		if (didLose) {
			anim.SetTrigger("GameOver");
		}


	}
}
