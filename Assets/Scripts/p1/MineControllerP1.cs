using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineControllerP1 : MonoBehaviour {



		private string scriptOwner;
		[SerializeField] private string buttonToActivate;



		[SerializeField] private GameObject _abilityPrefab;
		[SerializeField] private string abilityName; // used to reference the array containing the abilities - will be used to instantiate the abilitys and their amounts
		[SerializeField] private string releaseDirection; // the direction the ability gets released
		[SerializeField] private int payloadSize; // amount of shots you get with the ability - this can also control the size of the array
		[SerializeField] private int abilityMoveSpeed;
		[SerializeField] private int distanceLimitCheck; // Distance limit for the projectile from you before it explodes


		private GameObject[] abilityContainer;


		private string playerName;
		private string playerAbility;


		//Messenger.AddListener (GameEvent.<Event Enum name>, <Function to call>);
		void Awake(){
			Messenger<string>.AddListener (GameEvent.ABILITY_PICKUP, OnAbilityCollect);
			Messenger.AddListener (GameEvent.GAME_OVER, OnGameOver);
		}

		void OnDestroy(){
			Messenger<string>.RemoveListener (GameEvent.ABILITY_PICKUP, OnAbilityCollect);
			Messenger.RemoveListener (GameEvent.GAME_OVER, OnGameOver);
		}

		void OnGameOver(){
			buttonToActivate = "home";
		}

		private int salvoIndex;
		private bool abilityFired;


		void OnAbilityCollect(string player){
			if (abilityContainer == null) {
				abilityContainer = new GameObject[payloadSize];
			}
			salvoIndex = payloadSize - 1;

		}

		/* Instantiates a prefab at the Parent's position */
		void fireAbility(){
			Messenger<string>.Broadcast (GameEvent.ABILITY_FIRED, playerAbility);
			//Debug.Log ("fireAbility fired");
			if ((abilityContainer != null) && (salvoIndex >= 0)){
				//Debug.Log ("fireAbility toggle was true");
				abilityContainer [salvoIndex] = Instantiate (_abilityPrefab) as GameObject;
				scriptOwner = gameObject.name;
				abilityContainer [salvoIndex].tag = scriptOwner;
				AudioSource abilitySound = abilityContainer[salvoIndex].GetComponent<AudioSource> ();
				abilitySound.Play ();
				abilityContainer [salvoIndex].transform.position = this.transform.position;
				abilityContainer [salvoIndex].transform.rotation = this.transform.rotation;


				salvoIndex -= 1;
				abilityFired = true;
			}
			else {
				Debug.Log ("OUT OF AMMO");
				//Messenger.Broadcast(GameEvent.OUT_OF_AMMO, outOfAmmo); // Call OutOfAmmo in GUI controller
			}
		}


		// Use this for initialization
		void Start () {
			playerName = gameObject.name;
			playerAbility = playerName + " " + abilityName;
			//OnAbilityCollect ();
		}

		// Update is called once per frame
		void Update () {

			if (Input.GetKeyDown (buttonToActivate)) {
				fireAbility ();
			}




			/* Toggle: If abilityContainer has been created
		 * Moves each projectile in a straight line
		 */
			if (abilityContainer != null){
				if (abilityFired){
					//Debug.Log("Container was not empty");
					foreach (GameObject shot in abilityContainer) {
						if (shot != null) {
							/*if (directionSet) { // this if needs work to make the rotate only happen once per item
							Debug.Log ("DO while triggered");
							shot.transform.Rotate (shot.transform.rotation.x, turnDirection, shot.transform.rotation.z);
							directionSet = false;
						}*/
							shot.transform.position += shot.transform.forward * abilityMoveSpeed * Time.deltaTime;
						}
					}
				}
			}



			//end: if (abilityContainer)

		}
	}
