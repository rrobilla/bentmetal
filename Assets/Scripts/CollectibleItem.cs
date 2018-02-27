using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour {

	[SerializeField] private AudioClip pickupSound;

	private void OnTriggerEnter(Collider other){
		CarController player = other.GetComponent<CarController> ();
		string itemName = gameObject.name;
		if (player != null){
			string playerPickup = other.name + " " + gameObject.name;
			Debug.Log ("Ability picked up!");
			Messenger<string>.Broadcast (GameEvent.ABILITY_PICKUP, playerPickup);
			AudioSource.PlayClipAtPoint (pickupSound, gameObject.transform.position);
			Destroy (gameObject);
			Messenger<string>.Broadcast (GameEvent.ITEM_RESPAWN, itemName );

		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 3, 0);
	}
}
