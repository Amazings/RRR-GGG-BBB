//-----------------------------------
//     Potpourri Unity Framework
//     Copyright © 2013 Soupware
//-----------------------------------

using UnityEngine;
using System.Collections;

/// <summary>
/// This script implements functions need for a timescale-independent deltaTime.
/// </summary>

public class RealTime : MonoBehaviour {

	static RealTime _internalInstance = null;

	public static RealTime  Instance {
		get {
			if (_internalInstance == null) {
				_internalInstance = (new GameObject("_RealTime")).AddComponent<RealTime>();
			}
			return _internalInstance;
		}
	}

	/// <summary>
	/// The following are used to clamp values within three decimal places.
	/// </summary>

	const float timeResolution = 1000f;
	const float timeCutoff = 1f / timeResolution;

 	bool timeStarted = false;
	float lastFrameTime;
 	float realTime;
	float _internalDelta;

	bool isLerping = false;

	/// <summary>
	/// Variable to use in place of Time.deltaTime for timescale-independent events.
	/// </summary> 

	public static float realDeltaTime {
		get {
			return Instance._internalDelta;
		}
	}

	void Awake () {
		_Initialize();
		ResetTimeScale();
	}

	void Update () {
		UpdateRealTime();
		// Debug.Log("realDeltaTime: " + realDeltaTime);
	}

	/// <summary>
	/// Initializes our time, adding the execution delay, if given.
	/// </summary>

	private void _Initialize () {
		_internalDelta = 0f;
		lastFrameTime = Time.realtimeSinceStartup;
		timeStarted = true;
	}

	/// <summary>
	/// Updates the value of realDeltaTime. This function must be called on every frame.
	/// </summary>

	protected float UpdateRealTime () {
		if (timeStarted) {
			float currentTime = Time.realtimeSinceStartup;
			float delta = currentTime - lastFrameTime;
			realTime += Mathf.Max(0f, delta);
			_internalDelta = Mathf.Round(realTime * timeResolution) * timeCutoff;
			realTime -= _internalDelta;
			lastFrameTime = currentTime;
		} else {
			_Initialize();
		}

		return _internalDelta;
	}

	/// <summary>
	/// Set Time.timeScale and Time.fixedDeltaTime to its default values.
	/// </summary>

	public static void ResetTimeScale () {
		_SetTimeScale(1f);
	}

	/// <summary>
	/// Sets Time.timeScale and Time.fixedDeltaTime on (true) or off (false), over an optional duration.
	/// </summary>

	public static void SetTimeScaleActive ( bool state ) {
		if (state) {
			_SetTimeScale(0f);
		} else {
			_SetTimeScale(1f);
		}
	}

	/// <summary>
	/// Interpolates Time.timeScale between to values, over an optional duration.
	/// </summary>

	public static void LerpTimeScale ( float from, float to, float seconds = 0f ) {
		if (!Instance.isLerping) Instance.StartCoroutine(Instance.LerpCoroutine(from, to, seconds));
	}

	private IEnumerator LerpCoroutine ( float from, float to, float seconds ) {
		isLerping = true;
		if (seconds == 0f) {
			_SetTimeScale(to);
		} else {
			float current = 0f, ratio = 0f;
			while (ratio < 1) {
				ratio = current / seconds;
				_SetTimeScale(Mathf.Lerp(from, to, ratio));
				current += realDeltaTime;

				//Debug.Log("ratio: " + ratio);

				float pauseEndTime = Time.realtimeSinceStartup + realDeltaTime;
				while (Time.realtimeSinceStartup < pauseEndTime) {
					yield return 0;
				}
			}

			_SetTimeScale(to);
		}
		isLerping = false;
	}

	/// <summary>
	/// Sets Time.timeScale and scales fixedDeltaTime to ensure smooth rigidbody movement.
	/// </summary>

	private static void _SetTimeScale ( float scale ) {
		Time.timeScale = scale;
		Time.fixedDeltaTime = scale * 0.02f;
	}

	void OnApplicationQuit () {
		Destroy(this);
	}
}
