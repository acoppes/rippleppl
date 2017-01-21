using UnityEngine;
using UnityEngine.UI;

public class HealthBarModel : MonoBehaviour {

	public Image health;

	public void SetHealth(float factor)
	{
		this.health.fillAmount = factor;
	}

}
