using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControllerExample : MonoBehaviour {
	/*private int score;
	[SerializeField] private Text scoreValue;
    [SerializeField] private Text enemyValue;
	private int _health;
	[SerializeField] private Image healthbar;
	[SerializeField] private OptionsPopup optionsPopup;
	[SerializeField] private SettingsPopup settings;
	[SerializeField] private EndGamePopup endGame;

	void Awake(){
		Messenger.AddListener (GameEvent.ENEMY_HIT, OnEnemyHit);
		Messenger.AddListener (GameEvent.PLAYER_HIT, OnPlayerHit);
		Messenger.AddListener (GameEvent.PLAYER_DEAD, OnPlayerDead);
		Messenger.AddListener (GameEvent.HEALTH_CHANGED, OnHealthPickup);
	}

	void OnDestroy(){
		Messenger.RemoveListener (GameEvent.ENEMY_HIT, OnEnemyHit);
		Messenger.RemoveListener (GameEvent.PLAYER_HIT, OnPlayerHit);
		Messenger.RemoveListener (GameEvent.PLAYER_DEAD, OnPlayerDead);
		Messenger.RemoveListener (GameEvent.HEALTH_CHANGED, OnHealthPickup);
	}

	private void OnHealthPickup(){
		healthbar.fillAmount += 0.15f;
		if (healthbar.fillAmount >= 0.75f) {
			healthbar.color = Color.green;
		}
		if ((healthbar.fillAmount >= 0.25f) && (healthbar.fillAmount < 0.75f)){
			healthbar.color = Color.yellow;
		}
	}

	private void OnEnemyHit(){
		score += 1;
		scoreValue.text = score.ToString();
	}
	private void OnPlayerHit(){
		healthbar.fillAmount -= 0.02f;
		if (healthbar.fillAmount <= 0.75f) {
			healthbar.color = Color.yellow;
		}
		if (healthbar.fillAmount <= 0.25f){
			healthbar.color = Color.red;
		}
	}
	public void OnPlayerDead(){
		endGame.Open ();
		endGame.scoreSet(score.ToString ());
	}

	// Use this for initialization
	void Start () {
		score = 0;
		scoreValue.text = score.ToString ();
		healthbar.fillAmount = 1;
		healthbar.color = Color.green;
		optionsPopup.Close ();
		settings.Close ();
		endGame.Close ();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("escape")) {
			Messenger.Broadcast (GameEvent.MENU_OPEN);
			optionsPopup.Open ();
			settings.Close ();
		}
		 
		
	}*/
}
