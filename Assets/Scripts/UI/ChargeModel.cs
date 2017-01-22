using UnityEngine;
using UnityEngine.UI;

public class ChargeModel : MonoBehaviour {

	public Image progressBar;

	public GameObject model;

	public void SetCharge(int power, float charge)
	{
		model.SetActive (true);
		progressBar.fillAmount = charge;
	}

	public void NotCharging()
	{
		model.SetActive (false);
	}

}
