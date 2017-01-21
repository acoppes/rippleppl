using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName="Ripple/Create Balance")]
public class GameLogicData : ScriptableObject {

	public float[] waveChargeTimes;

	[FormerlySerializedAs("waveSpeedTimes")]
	public float[] waveSpeeds;

	// public float playerHealth = 20.0f;

	// time stun
	// health

}
