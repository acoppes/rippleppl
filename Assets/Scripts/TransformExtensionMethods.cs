using UnityEngine;

public static class TransformExtensionMethods
{
	public static void SetTransformY(this Transform t, Transform otherTransform)
	{
		var p = t.position;
		p.y = otherTransform.position.y;
		t.position = p;
	}

	public static void SetTransformY(this Transform t, float y)
	{
		var p = t.position;
		p.y = y;
		t.position = p;
	}

	public static void SetTransformLocalY(this Transform t, float y)
	{
		var p = t.localPosition;
		p.y = y;
		t.localPosition = p;
	}
}
