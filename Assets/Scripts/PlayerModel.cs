using UnityEngine;
using UnityEngine.UI;

public class PlayerModel : MonoBehaviour {
 
	public Image progressBar;

	public Text powerText;

	public GameObject characterModelPrefab;

	CharacterModel character;

	void Awake()
	{
		var characterModelObject = GameObject.Instantiate (characterModelPrefab);
		character = characterModelObject.GetComponent<CharacterModel> ();
		character.transform.SetParent (this.transform, false);
	}

	public void Charging(int power, float s)
	{
		if (power == 0)
			powerText.enabled = false;
		else
			powerText.enabled = true;
		
		progressBar.fillAmount = s;
		powerText.text = "" + power;

		if (power > 0 || s > 0) {
			character.Charge ();
		} else {
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
