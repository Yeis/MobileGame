using UnityEngine;
using System.Collections;

public class DataBase_Manager : MonoBehaviour {

	private string secretkey = "woloolow";
	public string addScoreURL = "mryeis.bplace.net/addScore.php?";
	public string highscoreurl = "mryeis.bplace.net/displayScore.php";


	// Use this for initialization
	void Start () {
		StartCoroutine(GetScores());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator PostScores(string userid , string username , string score )
	{
		string hash = Md5Sum (userid + username + score + secretkey);
		string post_url = addScoreURL + "UserID=" + WWW.EscapeURL (userid) + "&Username=" + WWW.EscapeURL (username) + "&Score=" + WWW.EscapeURL (score)+"&hash="+WWW.EscapeURL(hash);


		//mandamos la informacion
		WWW hs_post = new WWW(post_url);
		yield return hs_post;
		if (hs_post.error != null) 
		{
			Debug.Log ("There was an error posting the score ");
		}
	}
	IEnumerator GetScores()
	{
		WWW hs_get = new WWW (highscoreurl);
		yield return hs_get;
		if (hs_get.error != null) {
			print ("There was an error getting th high score: " + hs_get.error);
		} 
		else
		{
			Debug.Log (hs_get.text);
		}
	}


	public  string Md5Sum(string strToEncrypt)
	{
		System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
		byte[] bytes = ue.GetBytes(strToEncrypt);

		// encrypt bytes
		System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
		byte[] hashBytes = md5.ComputeHash(bytes);

		// Convert the encrypted bytes back to a string (base 16)
		string hashString = "";

		for (int i = 0; i < hashBytes.Length; i++)
		{
			hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
		}

		return hashString.PadLeft(32, '0');
	}
}


