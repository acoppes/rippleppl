using UnityEngine;

public class PlayerController : MonoBehaviour {

	public PlayerModel model;

	public string horizontalAxis = "Horizontal";
	public string verticalAxis = "Vertical";

	public float timeForWaveIncrement = 1.0f;

	int wavePower;

	float chargedTime;

	public GameObject wavePrefab;

	public Vector3 lookingDirection;

	// Update is called once per frame
	void Update () {

		float dy = Input.GetAxis (verticalAxis);

		transform.position = transform.position + new Vector3 (0, 1 * dy, 0);

		if (Input.GetButton (horizontalAxis)) {
			chargedTime += Time.deltaTime;

			while (chargedTime > timeForWaveIncrement) {
				wavePower++;
				chargedTime -= timeForWaveIncrement;
			}
		} else if (Input.GetButtonUp(horizontalAxis)) {
			if (wavePower > 0) {
				// disparo con power 0
				var waveObject = GameObject.Instantiate (wavePrefab);
				Wave wave = waveObject.GetComponent<Wave> ();

				wave.Fire (transform.position, lookingDirection, wavePower);

				wavePower = 0;

				model.PlayFire ();
			} else {
				model.PlayFailedFire ();
			}
		}

	}
}
