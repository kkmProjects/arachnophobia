using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
	public Vector3 teleportPoint;
	public Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate(Vector3.forward * Time.deltaTime);
	}

	void FixedUpdate() {
		rb.MovePosition(transform.position + transform.forward * Time.deltaTime);
	}
}
