using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerShooting : MonoBehaviour {
	private CharacterController _player;
	[SerializeField] private GameObject _misslePrefab;
	[SerializeField] private int rocketSpeed;
	private GameObject[] missleSalvo;
	private int salvoCount;
	private bool missle2Fired;
	private bool missle1Fired;
	private bool missle0Fired;

	private bool empty; // DELETE THIS TO STOP CALLING PICKUP WHEN YOU RUN OUT OF MISSLES - next @ line 64





	// Listener: When misslePickup is "collected"

	// When the player picks up a 'missle' pickup, refill the players missleSalvo 
	void pickupMissles(){
		for (int i = 0; i < missleSalvo.Length; i++){
			if (missleSalvo [i] == null) {
				missleSalvo [i] = Instantiate (_misslePrefab) as GameObject;
				Debug.Log("[ Refilling salvo slot " + i + " of 3 ]");
			}
			salvoCount = 3;
			missle2Fired = false;
			missle1Fired = false;
			missle0Fired = false;
			//Broadcast: MissleBay full to update gui
		}
	}

	// this method is being used to give each missle object in the missleBay
	// the position of the parent object of the script (Obj it is attached to)

	// missle#Fired flag is turned on
	// salvoCount is reduced

	// figure a way to fire these a dynamic way so that it is adjustable
	// through a serializedfield variable ie. salvo count
	void fireMissle(){

		if (missleSalvo [2] != null && (salvoCount == 3)) {
			Debug.Log ("Firing missle 3");
			missleSalvo [2].transform.position = this.transform.position;
			missleSalvo [2].transform.rotation = this.transform.rotation;
			missle2Fired = true;
			salvoCount = 2;
		}

		else if (missleSalvo [1] != null && (salvoCount == 2)) {
			Debug.Log ("Firing missle 2");
			missleSalvo [1].transform.position = this.transform.position;
			missleSalvo [1].transform.rotation = this.transform.rotation;
			missle1Fired = true;
			salvoCount = 1;
		}
		else if (missleSalvo [0] != null && (salvoCount == 1)) {
			Debug.Log ("Firing missle 1");
			missleSalvo [0].transform.position = this.transform.position;
			missleSalvo [0].transform.rotation = this.transform.rotation;
			missle0Fired = true;
			salvoCount = 0;
		}

	}

	//Could change this to instantiate a particle effect, even a bullet hole

	//change the wait to longer so the bullet holes stay around a bit more

	//Will Need: bullet hole prefab


	private IEnumerator SphereIndicator(Vector3 hitPosition){
		GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		sphere.transform.localScale = new Vector3 (2, 0.5f, 0.5f);
		sphere.transform.position = hitPosition;

		yield return new WaitForSeconds (1);
		Destroy (sphere);
	}
	//Set _player to the character controller of the car
	//missleSalvo

	void Start () {
		_player = GetComponent<CharacterController> ();
		Debug.Log (" Start routine _player instantiated");
		missleSalvo = new GameObject[3];
		Debug.Log (" Start routine instantiate missleSalvo");
		salvoCount = 0;

		pickupMissles (); // This is here to keep the salvo full for testing - delete when you have the pickups implemented

		Debug.Log (" Start routine pickupMissles executed");

	}

	// Update is called once per frame
	void Update (){


		//Check the 'missle#Fired' tag from the fireMissle method. 
		// If the missle has been fired, transform its position 
		// forward * the rocketSpeed, and sync it with deltaTime.

		if (missle2Fired) {
			missleSalvo[2].transform.position += missleSalvo[2].transform.forward * rocketSpeed * Time.deltaTime;
			Debug.Log ("Missle 3 changing direction");
		}
		if (missle1Fired) {
			missleSalvo[1].transform.position += missleSalvo[1].transform.forward * rocketSpeed * Time.deltaTime;
			Debug.Log ("Missle 2 changing direction");
		}
		if (missle0Fired) {
			missleSalvo[0].transform.position += missleSalvo[0].transform.forward * rocketSpeed * Time.deltaTime;
			Debug.Log ("Missle 1 changing direction");
		}


		if (Input.GetButtonDown("Fire1Player2")) {
			Debug.Log ("Shoot Button Pressed");
			fireMissle ();
			Debug.Log ("FireMissle executed");

			//GameObject missle = Instantiate (_misslePrefab, this.transform.position, this.transform.rotation) as GameObject;
			//missle.GetComponent<Rigidbody> ().velocity = transform.forward;
			//missle.transform.Translate (Vector3.forward * Time.deltaTime);
			//Debug.Log ("P2 -- Point pos: " + point.ToString());
			//Debug.Log ("P2 -- Angles: " + rotatePoint.ToString ());
			//Debug.Log ("Missle Coords: " + missle.transform.position.ToString () + " | Angles: " + missle.transform.rotation.ToString ());


			//Ray casting code i dont quite understand - should figure it out
			Vector3 point = _player.transform.position;

			Ray ray = new Ray(point, transform.forward);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit)) {

				GameObject hitObject = hit.transform.gameObject;
				ReactiveTarget target = hitObject.GetComponent<ReactiveTarget> ();
				// is this our enemy?
				if (target != null) {
					target.ReactToHit ();
				} else {
					//visually indicate where hit
					StartCoroutine (SphereIndicator (hit.point));
				}
			}

		}
	}
}
