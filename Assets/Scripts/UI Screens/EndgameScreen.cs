using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndgameScreen : MonoBehaviour {



	public void Open(){
		this.gameObject.SetActive (true);
	}

	public void Close(){
		this.gameObject.SetActive (false);
	}

	public void OnRestartButton(){
		SceneManager.LoadScene (0);
	}

	public void OnExit(){
		Application.Quit();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("r") && gameObject.activeSelf){
			this.OnRestartButton();
		}
		if (Input.GetKeyDown("escape") && gameObject.activeSelf){
			this.OnExit ();
		}
	}
}
