using UnityEngine;

namespace EasyEaser
{
	public class Easer
	{
		public delegate float CurveFunction(float valueToCurve);
		public CurveFunction Curve;

		private float startTime;
		private float easeSeconds;

		public bool IsEasing => Progress <= 1.0f;
		public float Progress => (Time.time - startTime) / easeSeconds;
		public float CurveProgress => Curve(Progress);

		public Easer(float easeSeconds)
		{
			startTime = Time.time;
			this.easeSeconds = easeSeconds;
		}

		public float EaseFloat(float from, float to)
		{
			return Mathf.Lerp(from, to, CurveProgress);
		}

		public Vector3 EaseVector(Vector3 from, Vector3 to)
		{
			return Vector3.Lerp(from, to, CurveProgress);
		}

		public Quaternion EaseQuaternion(Quaternion from, Quaternion to)
		{
			return Quaternion.Lerp(from, to, CurveProgress);
		}

		public Color EaseColor(Color from, Color to)
		{
			return Color.Lerp(from, to, CurveProgress);
		}

		public Color32 EaseColor32(Color32 from, Color32 to)
		{
			return Color32.Lerp(from, to, CurveProgress);
		}
	}

	public static class Curves
	{
		public static float SmoothStep(float x)
		{
			return x * x * (3.0f - 2.0f * x);
		}

		public static float SuperSmoothStep(float x)
		{
			return x * x * x * (x * (6.0f * x - 15.0f) + 10.0f);
		}

		public static float Cubic(float x)
		{
			return x < 0.5f ? 4f * x * x * x : 1f - Mathf.Pow(-2f * x + 2f, 3f) / 2f;
		}

		public static float Bounce(float x)
		{
			const float bounceMultiplier = 7.5625f;
			const float bounceDivisor = 2.75f;

			if (x < 1f / bounceDivisor)
				return bounceMultiplier * x * x;
			else if (x < 2f / bounceDivisor)
				return bounceMultiplier * (x -= 1.5f / bounceDivisor) * x + 0.75f;
			else if (x < 2.5f / bounceDivisor)
				return bounceMultiplier * (x -= 2.25f / bounceDivisor) * x + 0.9375f;
			else
				return bounceMultiplier * (x -= 2.625f / bounceDivisor) * x + 0.984375f;
		}
	}
}