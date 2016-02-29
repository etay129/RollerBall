using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
	public Text nextLevelText;

	private Rigidbody rb;
	private int count;
	private bool win;

	private Scene level1;
	private Scene level2;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		count = 0;
		win = false;
		winText.text = "";
		nextLevelText.text = "";
		DisplayText ();

		level1 = SceneManager.GetSceneByName ("Level 1");
		level2 = SceneManager.GetSceneByName ("Level 2");
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void Update() {
		if (win) {
			if (Input.GetKeyDown("space")) {
				Debug.Log ("next level");
				SceneManager.LoadScene ("Level 2");
			}
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag("Pick Up")) {
			other.gameObject.SetActive(false);
			count++;
			DisplayText ();
			}
		}


	void DisplayText () {
		countText.text = "Gold Collected: " + count.ToString ();
		if (count >= 12) {
			if (level1.isLoaded) {
				winText.text = "You've collected all the gold!";
				nextLevelText.text = "Press 'Space' for Next Level";
				win = true;
			}
			if (level2.isLoaded) {
				winText.text = "You've collected all the gold!";
			}
		}
	}

}

