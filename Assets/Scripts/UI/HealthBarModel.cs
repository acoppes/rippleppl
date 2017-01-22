using UnityEngine;
using UnityEngine.UI;

public class HealthBarModel : MonoBehaviour {

	public Image health;

	public float minFillAmount = 0.0f;
	public float maxFillAmount = 0.9f;

	public void SetHealth(float factor)
	{
		this.health.fillAmount = Mathf.Clamp(factor, minFillAmount, maxFillAmount);

	}

}
