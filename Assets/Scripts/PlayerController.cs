using UnityEngine;

public class PlayerController : MonoBehaviour {

	public PlayerModel model;

	public GameController gameController;

    public PlayerInput input;

	int wavePower;

	float chargedTime;

	public GameObject wavePrefab;

	public Vector3 lookingDirection;

	int currentLane = 1;

	void Start()
	{
		model.Charging (0, 0);
	}

	bool fired = false;

	void Fire()
	{
		// disparo con power 0
		var waveObject = GameObject.Instantiate (wavePrefab);

		waveObject.layer = gameController.GetWaveLayer (gameObject.layer);

		Wave wave = waveObject.GetComponent<Wave> ();
		wave.Init (gameController);
		wave.Fire (transform.position, lookingDirection, wavePower);
		wavePower = 0;
		model.PlayFire ();

		fired = true;
	}

	void MoveLaneUp()
	{
		MoveToLane (gameController.GetLaneUp (currentLane));
	}

	void MoveToLane (int lane)
	{
		if (lane == currentLane) {
			return;
		}
		var myposition = transform.position;
		myposition.y = gameController.GetLaneVerticalPosition (lane);
		transform.position = myposition;
		currentLane = lane;
	}

	void MoveLaneDown()
	{
		MoveToLane (gameController.GetLaneDown (currentLane));
	}

	// Update is called once per frame
	void Update () {

		if (input.Charging()) {

			if (!fired) {
				chargedTime += Time.deltaTime;

				while (chargedTime > gameController.GetChargeTime (wavePower)) {
					chargedTime -= gameController.GetChargeTime (wavePower);
					wavePower++;
				}

				float waveChargeTime = gameController.GetChargeTime (wavePower);

				model.Charging (wavePower, chargedTime / waveChargeTime);

				if (wavePower >= gameController.waveMaxPower) {
					Fire ();
					model.Charging (0, 0);
				}
			}

		} else if (input.Release()) {
			if (wavePower > 0) {
				Fire ();
			} else if (!fired) {
				model.PlayFailedFire ();
			}

			chargedTime = 0.0f;
			model.Charging (0, 0);

			fired = false;
		} else {

            // not firing

            if (input.MoveDown()) {
			    MoveLaneUp ();
		    } else if (input.MoveUp()) {
			    MoveLaneDown (); 
            }
		}

	}
}
