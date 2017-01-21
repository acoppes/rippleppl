using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public string horizontalAxis = "Horizontal";
	public string verticalAxis = "Vertical";

	// Update is called once per frame
	void Update () {

		float dx = Input.GetAxis (horizontalAxis);
		float dy = Input.GetAxis (verticalAxis);

		transform.position = transform.position + new Vector3 (0, 1 * dy, 0);

	}
}
