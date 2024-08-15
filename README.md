# Easy Easer
A perplexingly simple easing class for Unity. Handles interpolation over a specified period of seconds for basic data types such as:
- `float`
- `Vector3` & `Quaternion`
- `Color` & `Color32`

It also supports interpolation of custom types by access of its `Progress` and `CurveProgress` properties.

Of course, an easer is no good without a handful of built-in curves.
- Smooth Step
- Super Smooth Step
- Cubic
- Bounce
- More coming soon

But if that's not enough, custom curves may be implemented with _ease_.

# Example
```csharp
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
		easer.Curve = Curves.SmoothStep;

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
```

<img src="./Example/Example Inspector.png" width="100%">
<img src="./Example/Example Ease.gif" width="100%">

# Using Custom Curves
Any function with a float for the input and a float as the return value may be used as a custom curve:
```csharp
float CustomCurve(float x)
{
	return x < 0.5f ? 4f * x * x * x : 1f - Mathf.Pow(-2f * x + 2f, 3f) / 2f;
}

Easer easer = new Easer(EaseSeconds);
easer.Curve = CustomCurve;
```