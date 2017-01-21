using UnityEngine;
using UnityEngine.UI;

public class WaveModel : MonoBehaviour {

	public Text powerText;

	public void SetPower(int power)
	{
		powerText.text = "" + power;
	}

}
