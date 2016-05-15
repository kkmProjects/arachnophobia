﻿using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	public Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
		rb.MovePosition(transform.position + transform.forward * Time.deltaTime);
	}

	void OnCollisionEnter(Collision col){
		transform.Rotate(0,Random.Range(100, 260),0);
	}

	
}
