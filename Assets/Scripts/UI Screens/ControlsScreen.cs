using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsScreen : MonoBehaviour {
	[SerializeField] private UIController ingameGui;
	[SerializeField] private SceneController guiManager;

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
			guiManager.fadeMusic ();

			ingameGui.Open ();
		}
	}
}
