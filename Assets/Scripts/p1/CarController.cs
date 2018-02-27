using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarController : MonoBehaviour {
	public CharacterController _charController; // make public to interact with other players / objects?
	[SerializeField] private float speed;

	public float gravity = -9.8f;


	[SerializeField] private string forwardMove;
	[SerializeField] private string backwardMove;
	[SerializeField] private string leftMove;
	[SerializeField] private string rightMove;

	//Listener: speedPickup triggered



	void resetY(){
		transform.position = new Vector3 (transform.position.x, -0.2f, transform.position.z);
	}

	void Awake(){
		Messenger.AddListener (GameEvent.GAME_OVER, OnGameOver);
	}

	void OnDestroy(){
		Messenger.RemoveListener (GameEvent.GAME_OVER, OnGameOver);
	}

	void OnGameOver(){
		forwardMove = "home";
		backwardMove = "home";
		leftMove = "home";
		rightMove = "home";
	}

	// Use this for initialization
	void Start () {
		_charController = GetComponent<CharacterController> ();


	}

	// Update is called once per frame
	void Update () {


		//makes car come back to original y position if it is off
		/*if (transform.position.y > -0.2f) {
			//Debug.Log ("WORKING");
			transform.Translate (Vector3.down * Time.deltaTime);
			//transform.Translate(x, y, z, Space.World);	
		}*/

		// Fixes you if you fall through the floor
		if (transform.position.y < -0.2f) {
			resetY ();
		}

		//Controls
		bool left = Input.GetKey (leftMove);
		bool right = Input.GetKey (rightMove);
		bool forward = Input.GetKey (forwardMove);
		bool back = Input.GetKey (backwardMove);

		/* Left movment is negative X, Right movement is positive X
	* Forward is negative Z, back is positive Z
	*/
		Vector3 horizontalMovementLeft = new Vector3 (-100, 0, 0);
		Vector3 horizontalMovementRight = new Vector3 (100, 0, 0);
		Vector3 horizontalMovementForward = new Vector3 (0, 0, 50);
		Vector3 horizontalMovementBack = new Vector3 (0, 0, -50);
		Vector3 horizontalMovementDiagLeft = new Vector3 (15, 0, 0);
		Vector3 horizontalMovementDiagRight = new Vector3 (-15, 0, 0);

		//Clamp magnitude for diagonal movement
		horizontalMovementLeft = Vector3.ClampMagnitude (horizontalMovementLeft, speed);
		horizontalMovementRight = Vector3.ClampMagnitude (horizontalMovementRight, speed);
		horizontalMovementForward = Vector3.ClampMagnitude (horizontalMovementForward, speed);
		horizontalMovementBack = Vector3.ClampMagnitude (horizontalMovementBack, speed);
		horizontalMovementDiagLeft = Vector3.ClampMagnitude (horizontalMovementDiagLeft, speed);
		horizontalMovementDiagRight = Vector3.ClampMagnitude (horizontalMovementDiagRight, speed);

		//Make gravity effect the car to keep it on the ground
		horizontalMovementLeft.y = gravity;
		horizontalMovementRight.y = gravity;
		horizontalMovementForward.y = gravity;
		horizontalMovementBack.y = gravity;
		horizontalMovementDiagLeft.y = gravity;
		horizontalMovementDiagRight.y = gravity;




		// These make Movement code Frame Rate Independant
		horizontalMovementLeft *= Time.deltaTime;
		horizontalMovementRight *= Time.deltaTime;
		horizontalMovementForward *= Time.deltaTime;
		horizontalMovementBack *= Time.deltaTime;
		horizontalMovementDiagLeft *= Time.deltaTime;
		horizontalMovementDiagRight *= Time.deltaTime;

		//This converts , using Transform Direction , local coods to global coords
		horizontalMovementLeft = transform.TransformDirection(horizontalMovementLeft);
		horizontalMovementRight = transform.TransformDirection(horizontalMovementRight);
		horizontalMovementForward= transform.TransformDirection(horizontalMovementForward);
		horizontalMovementBack= transform.TransformDirection(horizontalMovementBack);
		horizontalMovementDiagLeft= transform.TransformDirection(horizontalMovementDiagLeft);
		horizontalMovementDiagRight= transform.TransformDirection(horizontalMovementDiagRight);

		// if up is pressed
		if (forward) {
			_charController.Move (horizontalMovementForward);
		}
		// if down is pressedwa
		if (back) {
			_charController.Move (horizontalMovementBack);
		}
		//if left is pressed
		if (left) {
			this.transform.Rotate (0, -1f, 0);
		}

		//if right is pressed
		if (right) {
			this.transform.Rotate (0, 1f, 0);
		}
		// if left & up pressed at the same time
		if (left && forward) {
			this.transform.Rotate (0, -1f, 0);
			//_charController.Move (horizontalMovementDiagLeft);
		}

		// if left & down pressed at the same time
		if (left && back) {
			this.transform.Rotate (0, 1f, 0);
			//_charController.Move (horizontalMovementBack);
		}

		// if Right & up pressed at the same time
		if (right && forward) {
			this.transform.Rotate (0, 1f, 0);
			//_charController.Move (horizontalMovementDiagRight);
		}

		// if Right & down pressed at the same time
		if (right && back) {
			this.transform.Rotate (0, -1f, 0);
			//_charController.Move (horizontalMovementBack);
		}
	}
}
