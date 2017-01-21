using UnityEngine;

public class Wave : MonoBehaviour
{
	public WaveModel model;

	public int maxPower = 5;

	public float[] speedPerPower = new float[] {
		1.0f, 2.0f, 3.0f, 4.0f, 5.0f
	};

	Vector3 direction;
	int power;

	bool isAlive;

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
		transform.position = transform.position + direction * speedPerPower [power - 1];
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

		// si es del otro, se restan

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
		Destroy(this.gameObject);
	}
}
