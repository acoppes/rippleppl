using UnityEngine;

public class Wave : MonoBehaviour
{
	public WaveModel model;

	public int maxPower = 5;

	Vector3 direction;
	int power;

	bool isAlive;

	GameController controller;

	public void Init(GameController controller)
	{
		this.controller = controller;
	}

	void UpdatePower (int updatedPower)
	{	
		power = updatedPower;

		if (power > maxPower)
			power = maxPower;
		
		model.SetPower (power);
	}

	void DestroyWave()
	{
		isAlive = false;
		Destroy (this.gameObject);
	}

	public void Fire(Vector3 position, Vector3 direction, int power)
	{
		if (power > maxPower)
			power = maxPower;
		
		model.SetPower (power);

		transform.position = position;

		this.power = power;
		this.direction = direction;
		// start movement

		isAlive = true;
	}

	void FixedUpdate()
	{
		transform.position = transform.position + direction * controller.data.waveSpeeds[power - 1] * Time.deltaTime;
	}

	void OnCollisionEnter2D(Collision2D otherCollider) {
		if (!isAlive)
			return;
		
		if (this == null || this.gameObject == null || otherCollider == null || otherCollider.gameObject == null)
			return;
		
		var otherWave = otherCollider.gameObject.GetComponent<Wave> ();

		if (otherWave == null)
			return;

		if (!otherWave.isAlive)
			return;

		// si es mia se suman

		if (otherCollider.gameObject.layer == this.gameObject.layer) {
			// es mi player

			UpdatePower (power + otherWave.power);
			otherWave.DestroyWave ();

		} else {
			// es el otro player

			if (power < otherWave.power) {
				otherWave.UpdatePower (otherWave.power - power);
				DestroyWave ();
			} else if (power > otherWave.power) {
				UpdatePower (power - otherWave.power);
				otherWave.DestroyWave ();
			} else {
				DestroyWave ();
				otherWave.DestroyWave ();


			}
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		// si es player stun
		// si es base hitpoints

		var playerBase = collider.GetComponent<Base> ();

		if (playerBase != null) {
			playerBase.ReceiveDamage (power);
			Destroy(this.gameObject);
		}

		var playerCharacter = collider.GetComponent<PlayerController> ();

		if (playerCharacter != null) {
			if (!playerCharacter.CanBeStun ())
				return;
			playerCharacter.Stun (power);
			Destroy(this.gameObject);
		}

		var block = collider.GetComponent<Block> ();

		if (block != null) {
			block.PlayAnimation (power, controller.data.blockConfig);
		}

	}
}
