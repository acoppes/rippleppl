using UnityEngine;
using System;

[Serializable]
public class Health
{
	public float total;
	public float current;

	public float GetFactor()
	{
		return current / total;
	}

	public void Damage(float damage)
	{
		current -= damage;
		if (current < 0)
			current = 0.0f;
	}

	public bool IsDead()
	{
		return current <= 0.001f;
	}
}
