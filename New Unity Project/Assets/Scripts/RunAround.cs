using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAround : MonoBehaviour {

    public float moveSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

        GetComponent<Rigidbody>().AddForce(move.normalized * moveSpeed);
	}
}
