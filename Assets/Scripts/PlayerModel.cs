using UnityEngine;
using UnityEngine.UI;

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

}
