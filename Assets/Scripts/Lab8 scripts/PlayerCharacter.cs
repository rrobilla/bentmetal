using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {
	public int _health;
	private int maxHealth = 50;
	// Use this for initialization
	void Start () {
		_health = 50;
	}

	public void FirstAid(){
		if (_health < maxHealth) {
			_health += 15;
			Debug.Log ("Health: " + _health);
			if (_health > maxHealth) {
				_health = maxHealth;
				Debug.Log ("Health: " + _health);
			}
			//Messenger.Broadcast (GameEvent.HEALTH_CHANGED);
		}
	}

	public void Hit(){
		_health -= 1;
		Debug.Log ("Player hit ! Health down to " + _health);
		if (_health == 0) {
			//Messenger.Broadcast (GameEvent.PLAYER_DEAD);
			Debug.Break ();
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
