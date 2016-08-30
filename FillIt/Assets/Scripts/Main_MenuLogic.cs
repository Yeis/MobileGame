using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Main_MenuLogic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
	}
	public void toSinglePlayerGame()
	{
		//SceneManager.LoadScene ("Sample_Scene");
		Debug.Log("going to The Real Game");

		Application.LoadLevel ("Sample_Scene");
	}

	public void toLeaderBoards()
	{
	//	SceneManager.LoadScene ("User_Scene");
		Debug.Log("going to Leaderboards Menu");
		Application.LoadLevel ("User_Scene");
	}
}
