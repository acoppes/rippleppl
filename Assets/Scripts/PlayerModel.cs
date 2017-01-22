using UnityEngine;

public class PlayerModel : MonoBehaviour {

	public GameObject characterModelPrefab;

	CharacterModel character;

	public ChargeModel charge;

	void Awake()
	{
		var characterModelObject = GameObject.Instantiate (characterModelPrefab);
		character = characterModelObject.GetComponent<CharacterModel> ();
		character.transform.SetParent (this.transform, false);
	}

	public void SetFlip(bool flip)
	{
		character.transform.localScale = new Vector3 (flip ? -1 : 1, 1, 1);
	}

	public void Charging(int power, float s)
	{
		if (power > 0 || s > 0) {
			charge.SetCharge (power, s);
			character.Charge ();
		} else {
			charge.NotCharging ();
			character.Idle ();
		}
	}

	public void PlayFire()
	{
		character.Stomp ();
	}

	public void PlayFailedFire()
	{
		character.Idle ();
	}

//	public float rotation = 10.0f;
//
//	bool stunned = false;

	public void Stun()
	{
//		stunned = true;
		character.Stun ();
	}

	public void RecoverFromStun()
	{
//		stunned = false;
		transform.localEulerAngles = new Vector3 (0, 0, 0);
	
		character.Idle ();
	}

	public void SetInRecoveryMode(bool inRecovery)
	{
		LeanTween.cancel (character.gameObject);

		if (inRecovery) {
			LeanTween.alpha (character.gameObject, 0.0f, 0.35f).setLoopPingPong ();
		} else {
			LeanTween.alpha (character.gameObject, 1.0f, 0.01f);
		}
	}

//	void Update()
//	{
//		if (stunned) {
//			transform.localEulerAngles = transform.localEulerAngles + new Vector3 (0, 0, rotation * Time.deltaTime);
//		} 
//	}
//
}
