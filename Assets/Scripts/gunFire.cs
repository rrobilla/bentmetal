using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunFire : MonoBehaviour {
	[SerializeField] private string buttonToActivate;
	[SerializeField] private GameObject _bulletSparks;
	[SerializeField] private float machinegunRange;
	[SerializeField] private AudioClip mgFiringSFX;

	[SerializeField] private GameObject uiCont;

	private IEnumerator hitIndicator(Vector3 hitPosition){
		GameObject bulletSpark = Instantiate (_bulletSparks) as GameObject;
		bulletSpark.transform.localScale = new Vector3 (2, 0.5f, 0.5f);
		bulletSpark.transform.position = hitPosition;

		yield return new WaitForSeconds (0.5f);

		Destroy (bulletSpark);
	}

	void Awake(){
		Messenger.AddListener (GameEvent.GAME_OVER, OnGameOver);
	}

	void OnDestroy(){
		Messenger.RemoveListener (GameEvent.GAME_OVER, OnGameOver);
	}

	void OnGameOver(){
		buttonToActivate = "home";
	}
	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(buttonToActivate)) {
			AudioSource.PlayClipAtPoint (mgFiringSFX, gameObject.transform.position);

			Vector3 point = this.transform.position;
			Ray ray = new Ray(point, transform.forward);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, machinegunRange)){
				GameObject hitObject =  hit.transform.gameObject;
				Component hitHasCC = hitObject.GetComponent<CarController>();
				string whichPlayer = hitObject.name;
				Debug.Log ("Hit Object name: " + whichPlayer);

				if (hitHasCC != null) {
					StartCoroutine (hitIndicator (hit.point));
					Debug.Log ("Player hit !");
					UIController detectHit = uiCont.GetComponent<UIController> ();
					detectHit.MachineGunHit (whichPlayer);

				} else {
					StartCoroutine (hitIndicator (hit.point));
				}
			}

		}
		
	}
}
