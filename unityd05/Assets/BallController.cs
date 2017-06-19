using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {


	public float speedH = 2.0f;
	public float speedV = 2.0f;

	private float yaw = 0.0f;
	private float pitch = 0.0f;

	// Use this for initialization
	void Start () {
		Camera.main.transform.position = new Vector3 (1, 10,-20) + this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKey (KeyCode.Space))
			this.GetComponent<Rigidbody> ().AddForce (new Vector3 (10, 0, 0));

		if (Input.GetKey (KeyCode.UpArrow))
			this.GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 0, 10));

		if (Input.GetKey (KeyCode.DownArrow))
			this.GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 0, -10));

		if (Input.GetKey (KeyCode.RightArrow))
			this.GetComponent<Rigidbody> ().AddForce (new Vector3 (10, 0, 0));
		if (Input.GetKey (KeyCode.LeftArrow))
			this.GetComponent<Rigidbody> ().AddForce (new Vector3 (-10, 0, 0));


		if (Input.GetKey (KeyCode.E))
			Camera.main.transform.position += new Vector3 (0,1,0);
		if (Input.GetKey (KeyCode.Q))
			Camera.main.transform.position += new Vector3 (0,-1,0);


			yaw += speedH * Input.GetAxis("Mouse X");
			pitch -= speedV * Input.GetAxis("Mouse Y");

			Camera.main.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

		//Camera.main.transform.position = new Vector3 (1, 10,-20) + this.transform.position;
	}
}
