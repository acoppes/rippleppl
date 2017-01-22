using UnityEngine;

public class ChargeBlockTest : MonoBehaviour {

	public ChargeBlock chargeBlock;

	public int power;

	public void Update() {
		if (Input.GetKeyUp (KeyCode.Alpha1)) {
			power++;
			chargeBlock.Charge(power);
		}

		if (Input.GetKeyUp (KeyCode.Alpha2)) {
			chargeBlock.Fire ();
			power = 0;
		}
	}
	
}
