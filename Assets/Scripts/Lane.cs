using UnityEngine;

public class Lane : MonoBehaviour
{
	ChargeBlock[] chargeBlocks;

	void Awake()
	{
		chargeBlocks = GetComponentsInChildren<ChargeBlock> ();
	}

	public ChargeBlock GetChargeBlock(int player)
	{
		return chargeBlocks[player];
	}
}
