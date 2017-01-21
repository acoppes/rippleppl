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

	public void Fire(Vector3 position, Vector3 direction, int power)
	{
		model.SetPower (power);

		transform.position = position;

		this.power = power;
		this.direction = direction;
		// start movement
	}

	void FixedUpdate()
	{
		transform.position = transform.position + direction * speedPerPower [power];
	}
}
