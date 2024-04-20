using UnityEngine;
using System.Collections;

public class Toaster : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Renderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		Competetion competetion = FindObjectOfType<Competetion> ();
		if (competetion.isGameEnded ()) {
			if (competetion.winner == Chess.BLACK) {
				GetComponent<TextMesh> ().text = "BLACK WIN.\nTYPE ENTER TO RESTART.";
			} else {
				GetComponent<TextMesh> ().text = "WHITE WIN.\nTYPE ENTER TO RESTART.";
			}
			GetComponent<Renderer> ().enabled = true;
			if (Input.GetKeyDown (KeyCode.Return)) {
				UnityEngine.SceneManagement.SceneManager.LoadScene ("RoundScene");
			}
		}

	}

	public IEnumerator Toast(string text, float time) {
		GetComponent<Renderer> ().enabled = true;
		GetComponent<TextMesh> ().text = text;
		yield return new WaitForSeconds (time);
		GetComponent<TextMesh> ().text = "";
		GetComponent<Renderer> ().enabled = false;
	}
}
