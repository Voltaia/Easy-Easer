using UnityEngine;
using System.Collections;
using EasyEaser;

public class Example : MonoBehaviour
{
	// Inspector
	public Vector3 DesiredPosition;
	public Color DesiredColor;
	public float EaseSeconds;

	// General
	private SpriteRenderer spriteRenderer;

	private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		StartCoroutine(EaseSelf());
	}

	private IEnumerator EaseSelf()
	{
		// Get starting state
		Vector3 startPosition = transform.position;
		Color startColor = spriteRenderer.color;

		// Create an easer that lasts for some amount of seconds with a smooth curve
		Easer easer = new(EaseSeconds);
		easer.CurveType = Easer.Curve.SmoothStep;

		// Ease until easer is finished
		while (easer.IsEasing)
		{
			transform.position = easer.EaseVector(startPosition, DesiredPosition);
			spriteRenderer.color = easer.EaseColor(startColor, DesiredColor);
			Debug.Log($"Linear Amount Eased: {easer.Progress}");
			Debug.Log($"Curved Amount Easer: {easer.CurveProgress}");
			yield return null;
		}
	}
}
