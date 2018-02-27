using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour {
	private AudioSource gameMusic;
	[SerializeField] private LogoScreen logoScreen;
	[SerializeField] private ControlsScreen controlsScreen;
	[SerializeField] private UIController ingameGui;
	[SerializeField] private EndgameScreen endgameScreen;

	enum Fade {In, Out};
	float fadeTime = 4.0F;

	IEnumerator FadeAudio (float timer, Fade fadeType) {
		float start = fadeType == Fade.In? 0.0F : 1.0F;
		float end = fadeType == Fade.In? 1.0F : 0.0F;
		float i = 0.0F;
		float step = 1.0F/timer;

		while (i <= 1.0F) {
			i += step * Time.deltaTime;
			gameMusic.volume = Mathf.Lerp(start, end, i);
			yield return new WaitForSeconds(step * Time.deltaTime);
		}
	}

	public void fadeMusic(){
		StartCoroutine(FadeAudio(fadeTime, Fade.Out));
	}

	void Awake(){
		Messenger.AddListener (GameEvent.GAME_OVER, OnGameOver);
	}

	void OnDestroy(){
		Messenger.RemoveListener (GameEvent.GAME_OVER, OnGameOver);
	}

	void OnGameOver(){
		endgameScreen.Open ();
	}

	// Use this for initialization
	void Start () {
		gameMusic = gameObject.GetComponent<AudioSource> ();
		gameMusic.Play ();
		logoScreen.Open ();
		controlsScreen.Close ();
		ingameGui.Close ();
		endgameScreen.Close ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
