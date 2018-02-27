using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

	private GameObject[] spawnedItems;

	private int spawnPointCount = 10;

	private bool startOfGame;

	[SerializeField] private GameObject ingameGUI;

	[SerializeField] private GameObject healthPickup;
	[SerializeField] private GameObject weaponPickup;
	[SerializeField] private GameObject minePickup;

	void Awake(){
		Messenger<string>.AddListener (GameEvent.ITEM_RESPAWN, itemPickedup);
	}

	void OnDestroy(){
		Messenger<string>.RemoveListener  (GameEvent.ITEM_RESPAWN, itemPickedup);
	}


	void itemPickedup(string itemName){
		StartCoroutine (respawnTimedEvent (itemName));
	}

	private IEnumerator respawnTimedEvent(string itemName){
		Debug.Log ("COroutine was called");
		yield return new WaitForSeconds (30);
		string [] itemStringParts = itemName.Split (" "[0]);
		int spawnNumber = int.Parse(itemStringParts [2]);
		int randItem = Random.Range (1, 3);
		string sPoint = "sp " + spawnNumber.ToString ();

		if (randItem == 1) {
			spawnedItems [spawnNumber] = Instantiate (healthPickup) as GameObject;
			GameObject spawnPoin = GameObject.Find (sPoint);
			spawnedItems [spawnNumber].transform.position = spawnPoin.transform.position;
			spawnedItems [spawnNumber].name = "healthPickup sp " + spawnNumber;

		}
		if (randItem == 2) {
			spawnedItems [spawnNumber] = Instantiate (weaponPickup) as GameObject;
			GameObject spawnPoin = GameObject.Find (sPoint);
			spawnedItems [spawnNumber].transform.position = spawnPoin.transform.position;
			spawnedItems [spawnNumber].name = "weaponPickup sp " + spawnNumber;
		}
		if (randItem == 3) {
			spawnedItems [spawnNumber] = Instantiate (minePickup) as GameObject;
			GameObject spawnPoin = GameObject.Find (sPoint);
			spawnedItems [spawnNumber].transform.position = spawnPoin.transform.position;
			spawnedItems [spawnNumber].name = "minePickup sp " + spawnNumber;
		}
			


	}

	// Use this for initialization
	void Start () {
		spawnedItems = new GameObject [spawnPointCount];
		startOfGame = true;

	}
	
	// Update is called once per frame
	void Update () {


		// && ingameGUI.activeSelf
		if (startOfGame){
			for (int i = 0; i < spawnedItems.Length; i++) {
				int whichPickup = Random.Range (1, 3);

				if (whichPickup == 1) {
					spawnedItems [i] = Instantiate (healthPickup) as GameObject;
					string pickedSP = "sp " + i.ToString();
					GameObject chosenSpawnPoint = GameObject.Find (pickedSP);
					spawnedItems [i].transform.position = chosenSpawnPoint.transform.position;
					spawnedItems [i].name = "healthPickup sp " + i.ToString ();

				}
				if (whichPickup == 2) {
					spawnedItems [i] = Instantiate (weaponPickup) as GameObject;
					string pickedSP = "sp " + i.ToString();
					GameObject chosenSpawnPoint = GameObject.Find (pickedSP);
					spawnedItems [i].transform.position = chosenSpawnPoint.transform.position;
					spawnedItems [i].name = "weaponPickup " + "sp " + i.ToString ();

				}
				if (whichPickup == 3) {
					spawnedItems [i] = Instantiate (minePickup) as GameObject;
					string pickedSP = "sp " + i.ToString();
					GameObject chosenSpawnPoint = GameObject.Find (pickedSP);
					spawnedItems [i].transform.position = chosenSpawnPoint.transform.position;
					spawnedItems [i].name = "minePickup " + "sp " + i.ToString ();

				}
			}
			startOfGame = false;

		}


	}
}
