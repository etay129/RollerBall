using UnityEngine;
using System.Collections;

public class MovingObstacleLeft : MonoBehaviour {
	public int speed;

	private int dx;

	// Use this for initialization
	void Start () {
		dx = -1;
	}

	// Update is called once per frame
	void Update () {

		Rigidbody rb = this.GetComponent<Rigidbody> ();
		rb.velocity = new Vector3(speed*dx, 0, 0);
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Trigger")) {
			this.dx = dx*-1;
		}
	}

}
