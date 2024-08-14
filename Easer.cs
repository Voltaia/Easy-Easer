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
			Smooth
		}

		public bool IsEasing
		{
			get { return Progress <= 1.0f; }
			private set { }
		}

		public float Progress
		{
			get { return (Time.time - startTime) / easeSeconds; }
		}

		public float CurveProgress
		{
			get
			{
				switch (CurveType)
				{
					default:
						return Progress;
					case Curve.Smooth:
						return Mathf.SmoothStep(0.0f, 1.0f, Progress);
				}
			}
		}

		public Easer(float easeSeconds)
		{
			startTime = Time.time;
			this.easeSeconds = easeSeconds;
		}

		public Vector3 EaseVector(Vector3 from, Vector3 to)
		{
			return Vector3.Lerp(from, to, CurveProgress);
		}

		public Quaternion EaseQuaternion(Quaternion from, Quaternion to)
		{
			return Quaternion.Lerp(from, to, CurveProgress);
		}

		public void EaseTransform(Transform transform, Vector3 from, Vector3 to)
		{
			transform.position = EaseVector(from, to);
		}

		public void EaseITransform(ITransform iTransform, Vector3 from, Vector3 to)
		{
			iTransform.position = EaseVector(from, to);
		}
	}
}