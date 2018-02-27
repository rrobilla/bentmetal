using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoScreen : MonoBehaviour {
	[SerializeField] private ControlsScreen controlsScreen;

	public void Open(){
		this.gameObject.SetActive (true);
	}

	public void Close(){
		this.gameObject.SetActive (false);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown ("space")) {
			gameObject.SetActive (false);

			controlsScreen.Open ();
		}
		
	}
}
