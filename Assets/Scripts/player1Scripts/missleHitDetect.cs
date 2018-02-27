using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missleHitDetect : MonoBehaviour {

	public AudioClip explosion;
	[SerializeField] private GameObject _explosionFX;

	private IEnumerator explosionEffects(Vector3 expPos){
		AudioSource.PlayClipAtPoint (explosion, expPos);
		GameObject exp = Instantiate (_explosionFX) as GameObject;
		exp.transform.position = expPos;


		yield return new WaitForSeconds (2f);

		Destroy (exp);
	}

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 point = this.transform.position;
		Ray ray = new Ray(point, transform.forward);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 2.0f)){
			GameObject hitObject =  hit.transform.gameObject;
			Component hitHasCC = hitObject.GetComponent<CarController>();
			string hitPlayer = hitObject.name;

			//Debug.Log ("Object name: " + hitPlayer);

			if ((hitHasCC != null) && (gameObject.tag != hitPlayer)){
				Debug.Log (hitPlayer + " hit !");
				Vector3 explosionPoint = transform.position;
				Destroy (gameObject);
				StartCoroutine (explosionEffects (explosionPoint));
				//Broadcast to UI controller that player1 was hit using whichPlayer as a passed string
				string playerHitAbility = hitPlayer + " Missle";
				Messenger<string>.Broadcast ("PLAYER_HIT", playerHitAbility);
			}else {
				Vector3 explosionPoint = transform.position;
				Destroy (gameObject);
				StartCoroutine (explosionEffects (explosionPoint));
			}
		}
	}
}
