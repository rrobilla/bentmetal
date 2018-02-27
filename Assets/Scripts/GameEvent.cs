using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour {
	//public const string ENEMY_HIT = "ENEMY_HIT";

	// Player hit Events
	public const string PLAYER_HIT = "PLAYER_HIT";


	//Ability fired event
	public const string ABILITY_FIRED = "ABILITY_FIRED";

	//Ability pickup event
	public const string ABILITY_PICKUP = "ABILITY_PICKUP";
	public const string ITEM_RESPAWN = "ITEM_RESPAWN";
	public const string ABILITY_RELOAD = "ABILITY_RELOAD";

	// Out of ammo event --From: Ability Controller/fireAbility()
	public const string OUT_OF_AMMO = "OUT_OF_AMMO";

	//Game over event
	public const string GAME_OVER = "GAME_OVER";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
