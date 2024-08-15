using UnityEngine;
using UnityEngine.UIElements;

namespace EasyEaser
{
	public class Easer
	{
		private float startTime;
		private float easeSeconds;
		public Curve CurveType;

		public enum Curve
		{
			None,
			SmoothStep,
			SuperSmoothStep
		}

		public bool IsEasing => Progress <= 1.0f;

		public float Progress => (Time.time - startTime) / easeSeconds;

		private float SmoothStep => Progress * Progress * (3.0f - 2.0f * Progress);
		private float SuperSmoothStep => Progress * Progress * Progress * (Progress * (6.0f * Progress - 15.0f) + 10.0f);

		public float CurveProgress
		{
			get
			{
				switch (CurveType)
				{
					default: return Progress;
					case Curve.SmoothStep: return SmoothStep;
					case Curve.SuperSmoothStep: return SuperSmoothStep;
				}
			}
		}

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
}
