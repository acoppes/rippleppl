using UnityEngine;

public class Base : MonoBehaviour {

	public HealthBarModel healthBar;

	Health health = new Health();

	public GameController gameLogic;

	public int player;

	void Awake()
	{
		health.total = gameLogic.data.playerHealth;
		health.current = health.total;
	}

	public void ReceiveDamage(int wavePower)
	{
		if (health.IsDead ())
			return;
        gameLogic.shakeCamera(0.2f);
		health.Damage (wavePower);
		healthBar.SetHealth (health.GetFactor ());

		if (health.IsDead ())
			gameLogic.OnBaseDeath (this);
	}
}
