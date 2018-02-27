using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	[SerializeField] private Text p1MissleCount;
	[SerializeField] private Text p1MineCount;
	[SerializeField] private Text p1HealthCount;

	[SerializeField] private Text p2MissleCount;
	[SerializeField] private Text p2MineCount;
	[SerializeField] private Text p2HealthCount;

	[SerializeField] private Text winnerText;

	private int maxHealth = 200;

	private int p1Health;
	private int p1Missle;
	private int p1Mine;


	private int p2Health;
	private int p2Missle;
	private int p2Mine;


	//Event Listeners
	// eg. Messenger.AddListener (GameEvent.ENEMY_HIT, OnEnemyHit);
	void Awake(){

		//Hit Register Listeners
		Messenger<string>.AddListener (GameEvent.PLAYER_HIT, OnPlayerHit);

		//Ability fired Listener
		Messenger<string>.AddListener (GameEvent.ABILITY_FIRED, OnAbilityFired);

		//Pickup Listeners
		Messenger<string>.AddListener (GameEvent.ABILITY_PICKUP, OnAbilityPickup);
	}

	//Destroy Listeners
	// eg. Messenger.RemoveListener (GameEvent.ENEMY_HIT, OnEnemyHit);
	void OnDestroy(){
		Messenger<string>.RemoveListener (GameEvent.PLAYER_HIT, OnPlayerHit);
		Messenger<string>.RemoveListener (GameEvent.ABILITY_FIRED, OnAbilityFired);
		Messenger<string>.RemoveListener (GameEvent.ABILITY_PICKUP, OnAbilityPickup);
	}

	public void Open(){
		this.gameObject.SetActive (true);
	}

	public void Close(){
		this.gameObject.SetActive (false);
	}


	void OnPlayerHit(string s){
		string playerHitWithType = s;
		if (playerHitWithType == "player1Car Missle") {
			p1Health -= 20;
			p1HealthCount.text = p1Health.ToString ();
		}
		if (playerHitWithType == "player1Car Mine") {
			p1Health -= 30;
			p1HealthCount.text = p1Health.ToString ();
		}


		if (playerHitWithType == "player2Car Missle") {
			p2Health -= 20;
			p2HealthCount.text = p2Health.ToString ();
		}
		if (playerHitWithType == "player2Car Mine") {
			p2Health -= 30;
			p2HealthCount.text = p2Health.ToString ();
		}

	}

	void OnAbilityFired(string s){
		string abilityNameFired = s;
		if (abilityNameFired == "player1Car Missle") {
			p1Missle -= 1;
			p1MissleCount.text = p1Missle.ToString ();
			}
		if (abilityNameFired == "player1Car Mine") {
			p1Mine -= 1;
			p1MineCount.text = p1Mine.ToString ();
		}
		if (abilityNameFired == "player2Car Missle") {
			p2Missle -= 1;
			p2MissleCount.text = p2Missle.ToString ();
		}
		if (abilityNameFired == "player2Car Mine") {
			p2Mine -= 1;
			p2MineCount.text = p2Mine.ToString ();
		}
	}

	void OnAbilityPickup(string abilityName){
		Debug.Log ("UI Controller - OnAbilityPickup triggered");
		if (abilityName.StartsWith("player1Car healthPickup")) {
			p1Health += 40;
			if (p1Health > maxHealth) {
				p1Health = maxHealth;
			}
			p1HealthCount.text = p1Health.ToString ();
		}
		if (abilityName.StartsWith("player1Car weaponPickup")) {
			p1Missle = 3;
			p1MissleCount.text = p1Missle.ToString ();
		}
		if (abilityName.StartsWith("player1Car minePickup")) {
			p1Mine = 2;
			p1MineCount.text = p1Mine.ToString ();
		}


		if (abilityName.StartsWith("player2Car healthPickup")) {
			p2Health += 40;
			if (p2Health > maxHealth) {
				p2Health = maxHealth;
			}
			p2HealthCount.text = p2Health.ToString ();
		}
		if (abilityName.StartsWith("player2Car weaponPickup")) {
			p2Missle = 3;
			p2MissleCount.text = p2Missle.ToString ();
		}
		if (abilityName.StartsWith("player2Car minePickup")) {
			p2Mine = 2;
			p2MineCount.text = p2Mine.ToString ();
		}
	}

	public void MachineGunHit(string playerHit){
		if (playerHit == "player1Car") {
			p1Health -= 1;
			p1HealthCount.text = p1Health.ToString ();
		}
		if (playerHit == "player2Car") {
			p2Health -= 1;
			p2HealthCount.text = p2Health.ToString ();
		}
	}

	// Use this for initialization
	void Start () {
		p1Health = 200;
		p1HealthCount.text = p1Health.ToString ();
		p1Missle = 0;
		p1MissleCount.text = p1Missle.ToString ();
		p1Mine = 0;
		p1MineCount.text = p1Mine.ToString ();


		p2Health = 200;
		p2HealthCount.text = p2Health.ToString ();
		p2Missle = 0;
		p2MissleCount.text = p2Missle.ToString ();
		p2Mine = 0;
		p2MineCount.text = p2Mine.ToString ();

	}
	
	// Update is called once per frame
	void Update () {
		if (p1Health <= 0) {
			winnerText.text = "Player 1 Wins!";
			Messenger.Broadcast ("GAME_OVER");
		}
		if (p2Health <= 0) {
			winnerText.text = "Player 2 Wins!";
			Messenger.Broadcast ("GAME_OVER");
		}
	}
}
