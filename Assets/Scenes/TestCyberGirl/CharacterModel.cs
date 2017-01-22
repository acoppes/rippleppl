using UnityEngine;

public class CharacterModel : MonoBehaviour
{
	public Animator animator;

	public void Idle()
	{
		animator.Play ("Idle");
	}

	public void Stomp()
	{
		animator.Play ("Stomp");
	}

	public void Stun()
	{
		animator.Play ("Stun");
	}

	public void Charge()
	{
		animator.Play ("Charge");
	}

	public void Victory()
	{
		animator.Play ("Victory");
	}

	public void Defeat()
	{
		animator.Play ("Defeat");
	}
}
