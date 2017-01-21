using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerModel : MonoBehaviour {

	public Image progressBar;

	public Text powerText;

	public void Charging(int power, float s)
	{
		if (power == 0)
			powerText.enabled = false;
		else
			powerText.enabled = true;
		
		progressBar.fillAmount = s;
		powerText.text = "" + power;
	}

	public void PlayFire()
	{
		
	}

	public void PlayFailedFire()
	{

	}

	public float rotation = 10.0f;

	bool stunned = false;

	public void Stun()
	{
		stunned = true;
	}

	public void RecoverFromStun()
	{
		stunned = false;
		transform.localEulerAngles = new Vector3 (0, 0, 0);
	}

	void Update()
	{
		if (stunned) {
			transform.localEulerAngles = transform.localEulerAngles + new Vector3 (0, 0, rotation * Time.deltaTime);
		} 
	}

}
