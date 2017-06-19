using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	float flySpeed = 10F;
	GameObject defaultCam;
	GameObject playerObject;
	bool isEnabled;

	bool shift;
	bool ctrl;
	float accelerationAmount = 30;
	float accelerationRatio = 3;
	float slowDownRatio = 0.2F;



	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {


		//use shift to speed up flight
		if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
		{
			shift = true;
			flySpeed *= accelerationRatio;
		}

		if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
		{
			shift = false;
			flySpeed /= accelerationRatio;
		}

		//use ctrl to slow up flight
		if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
		{
			ctrl = true;
			flySpeed *= slowDownRatio;
		}

		if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl))
		{
			ctrl = false;
			flySpeed /= slowDownRatio;
		}
		//
		if (Input.GetAxis("Vertical") != 0)
		{
			//transform.Translate(Vector3.forward * flySpeed * Input.GetAxis("Vertical"));
			this.GetComponent<Rigidbody> ().AddForce (Vector3.forward * flySpeed * Input.GetAxis ("Vertical"));
		}


		if (Input.GetAxis("Horizontal") != 0)
		{
			//transform.Translate(Vector3.right * flySpeed * Input.GetAxis("Horizontal"));
			this.GetComponent<Rigidbody> ().AddForce (Vector3.right * flySpeed * Input.GetAxis("Horizontal"));
		}


		if (Input.GetKey(KeyCode.E))
		{
			this.GetComponent<Rigidbody> ().AddForce (Vector3.up * flySpeed);
		}
		else if (Input.GetKey(KeyCode.Q))
		{
			transform.Translate(Vector3.down * flySpeed);
		}
		//if (Input.GetKeyDown(KeyCode.F12))
		//switchCamera();

		if (Input.GetKeyDown(KeyCode.M))
			playerObject.transform.position = transform.position; //Moves the player to the flycam's position. Make sure not to just move the player's camera.

	}
}
