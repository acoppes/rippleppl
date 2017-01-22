using UnityEngine;

public class CybergirlAnimationsTest : MonoBehaviour {

	public CharacterModel character;

	public void Update()
	{
		if (Input.GetKeyUp (KeyCode.Alpha1)) {
			character.Idle ();
		}
		if (Input.GetKeyUp (KeyCode.Alpha2)) {
			character.Stomp ();
		}
		if (Input.GetKeyUp (KeyCode.Alpha3)) {
			character.Stun ();
		}
		if (Input.GetKeyUp (KeyCode.Alpha4)) {
			character.Charge ();
		}
	}

}
