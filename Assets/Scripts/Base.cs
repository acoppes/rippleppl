using UnityEngine;

public class Base : MonoBehaviour {

	public HealthBarModel healthBar;

	Health health = new Health();

	public GameController gameLogic;

	void Awake()
	{
		health.total = gameLogic.data.playerHealth;
		health.current = health.total;
	}

	public void ReceiveDamage(int wavePower)
	{
		health.Damage (wavePower);
		healthBar.SetHealth (health.GetFactor ());
	}
}
