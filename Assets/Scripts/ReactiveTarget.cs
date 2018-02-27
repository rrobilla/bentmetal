using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour {
	private BoxCollider bulletHit;
	[SerializeField] private GameObject _bulletSpark;


		

	public void ReactToHit(){
		CharacterController player = GetComponent<CharacterController> ();

		if (player != null) {
			Debug.Log ("YOU HIT THE OTHER PLAYER!");
			//enemyAI.ChangeState (EnemyStates.dead);
		}
			
		/*Animator enemyAnimator = GetComponent<Animator>();
		if (enemyAnimator != null) {
			enemyAnimator.SetTrigger ("Die");
		}*/
		//StartCoroutine (Die());
	}
	/*public IEnumerator Die(){
		//enemy falls over after 2 seconds
		//iTween.RotateAdd (this.gameObject, new Vector3(-75, 0, 0), 1);

		yield return new WaitForSeconds (2);
		Destroy (this.gameObject);
	}
	private void DeadEvent(){
		Messenger.Broadcast (GameEvent.ENEMY_HIT);
		Destroy (this.gameObject);
	}*/

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
