using UnityEngine;

//public class CharacterModel : MonoBehaviour
//{
//	
//}

public class CybergirlAnimationsTest : MonoBehaviour {

	public Animator animator;

	public void Update()
	{
		if (Input.GetKeyUp (KeyCode.Alpha1)) {
			animator.Play ("Idle");
		}
		if (Input.GetKeyUp (KeyCode.Alpha2)) {
			animator.Play ("Stomp");
		}
		if (Input.GetKeyUp (KeyCode.Alpha3)) {
			animator.Play ("Stun");
		}
		if (Input.GetKeyUp (KeyCode.Alpha4)) {
			animator.Play ("Charge");
		}
	}

}
