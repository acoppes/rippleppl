using UnityEngine;

public class Base : MonoBehaviour {

	public HealthBarModel healthBar;

	public Health health;

	public void ReceiveDamage(int wavePower)
	{
		health.Damage (wavePower * 10.0f);
		healthBar.SetHealth (health.GetFactor ());
	}
}
