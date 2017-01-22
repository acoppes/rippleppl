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

	public Collider2D hit;

	bool fired = false;

	ChargeBlock chargeBlock;

	public int player;

	public AudioSource switchLaneSound;
	public AudioSource hitSound;
	public AudioSource releaseSound;

	void Start()
	{
		model.Charging (0, 0);

		float height = gameController.GetLaneVerticalPosition (currentLane);
//		transform.position = new Vector3 (transform.position.x, height, transform.position.z);

//		chargeBlock = gameController.GetChargeBlock (player, currentLane);

		MoveToLane (currentLane);

		if (player == 0)
			model.SetFlip (false);
		else
			model.SetFlip (true);
	}

	void Fire()
	{
		var position = transform.position;
		position.y = gameController.GetLaneVerticalPosition (currentLane);

		// disparo con power 0
		var waveObject = GameObject.Instantiate (wavePrefab);

		waveObject.layer = gameController.GetWaveLayer (gameObject.layer);

		Wave wave = waveObject.GetComponent<Wave> ();
		wave.Init (gameController);
		wave.Fire (position, lookingDirection, wavePower, player);
		wavePower = 0;
		model.PlayFire ();

		fired = true;

		releaseSound.Play ();

		chargeBlock.GoDown ();
	}

	void MoveLaneUp()
	{
		var lane = gameController.GetLaneUp (currentLane);
		if (lane == currentLane) {
			return;
		}
		MoveToLane (lane);

		switchLaneSound.Play ();
	}

	void MoveToLane (int lane)
	{
		var myposition = transform.position;
		myposition.y = gameController.GetLaneVerticalPosition (lane);
		transform.position = myposition;

		currentLane = lane;

		chargeBlock = gameController.GetChargeBlock (player, currentLane);

		chargeBlock.LocateCharacter (model.transform);
//		model.transform.SetParent (chargeBlock.transform, false);
	}

	void MoveLaneDown()
	{
		var lane = gameController.GetLaneDown (currentLane);
		if (lane == currentLane) {
			return;
		}
		MoveToLane (lane);

		switchLaneSound.Play ();
	}

	bool stunned = false;
	float stunnedTime;

	bool recoverying = false;
	float lastStunTime = 0;

	// Update is called once per frame
	void Update () {

		lastStunTime -= Time.deltaTime;

		if (stunned) {
		
			stunnedTime -= Time.deltaTime;

			if (stunnedTime <= 0) {
				RemoveStun ();
			} else {
				return;
			}

		}

		if (input.Charging()) {

			if (!fired) {
				chargedTime += Time.deltaTime;

				while (chargedTime > gameController.GetChargeTime (wavePower)) {
					chargedTime -= gameController.GetChargeTime (wavePower);
					wavePower++;

					chargeBlock.Charge (wavePower);
				}

				float waveChargeTime = gameController.GetChargeTime (wavePower);

				model.Charging (wavePower, chargedTime / waveChargeTime);

				if (wavePower >= gameController.waveMaxPower) {
					StopCharging ();

					Fire ();
				}
			}

		} else if (input.Release()) {
			if (wavePower > 0) {
				Fire ();
			} else if (!fired) {
				model.PlayFailedFire ();
			}

			StopCharging ();

			fired = false;
		} else {

            // not firing

            if (input.MoveDown()) {
			    MoveLaneUp ();
		    } else if (input.MoveUp()) {
			    MoveLaneDown (); 
            }
		}

		if (recoverying) {
		
			lastStunTime -= Time.deltaTime;

			if (lastStunTime <= 0) {
				model.SetInRecoveryMode (false);
				recoverying = false;
			}
		
		}
	}

	void StopCharging()
	{
		chargedTime = 0.0f;
		model.Charging (0, 0);
	}

	void RemoveStun ()
	{
		model.RecoverFromStun ();
		stunned = false;

		hit.enabled = true;

		recoverying = true;
		lastStunTime = gameController.data.stunRecoveryTime;

		model.SetInRecoveryMode (true);
	}
		
	public bool CanBeStun()
	{
		return lastStunTime <= 0;
	}

	public void Stun (int power)
	{
		// stop charging...

		stunned = true;
		stunnedTime = gameController.data.stunTimes [power - 1];

		hit.enabled = false;

		StopCharging ();

		chargeBlock.GoDown ();

		model.Stun ();

		hitSound.Play ();
	}
}
