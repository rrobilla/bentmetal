using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  enum EnemyStates {alive, dead};


public class WanderingAI : MonoBehaviour {
	public float enemySpeed = 3.0f;
	public float obstacleRange = 5.0f;
	private EnemyStates _state;
	[SerializeField] private GameObject _laserBeamPrefab;
	private GameObject _laserBeam;

	public void ChangeState(EnemyStates state) {
		_state = state;
	}

	// Use this for initialization
	void Start () {
		_state = EnemyStates.alive;
		
	}
	
	// Update is called once per frame
	void Update () {

		//Spherecast and determine if enemy needs to turn

		if (_state == EnemyStates.alive) {

			//Move enemy and generate Ray
			transform.Translate (0, 0, enemySpeed * Time.deltaTime);
			Ray ray = new Ray (transform.position, transform.forward);
			RaycastHit hit;
			if (Physics.SphereCast (ray, 0.75f, out hit)) {
				GameObject hitObject = hit.transform.gameObject;
				if (hitObject.GetComponent<PlayerCharacter> ()) {
					if (_laserBeam == null){
						_laserBeam = Instantiate (_laserBeamPrefab) as GameObject;
						_laserBeam.transform.position = transform.TransformPoint (0, 1.0f, 1.0f);
						//_laserBeam.transform.position = transform.TransformPoint (0, 1.5f, 1.5f);
						_laserBeam.transform.rotation = transform.rotation;
				}
			}
			else if (hit.distance < obstacleRange) {
				float turnAngle = Random.Range (-110, 110);
				transform.Rotate (0, turnAngle, 0);
			}
			}

		}
	}
}
