using UnityEngine;

[CreateAssetMenu(menuName="Ripple/Create Balance")]
public class GameLogicData : ScriptableObject {

	public float[] waveChargeTimes;

	public float[] waveSpeeds;

	public float[] stunTimes;

	public float playerHealth = 20.0f;

	public float stunRecoveryTime = 1.0f;

	// multiplicador general para todas las velocidades de waves

	// time stun
	// health

}
