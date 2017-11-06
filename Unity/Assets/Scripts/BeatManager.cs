using System.Collections;
using UnityEngine;

public class BeatManager : MonoBehaviour
{
	public int BPM = 120;

	public bool ShouldPlay = false;

	private const float DELAY = 0.5f;

	public delegate void TickOccurredAction(float tick);
	public static event TickOccurredAction OnTickOccurred;

	public float NextTick
	{
		get { return _tickCount + 1 / DIVISOR; }
	}

	private const float DIVISOR = 32f;
	private float _tickCount = 0f;

	private float _singleTickTime;
	private float _timeSinceLastTick;

	void Start ()
	{
		_singleTickTime = 60f / (float)BPM / DIVISOR * 4f; // because a whole note (semibreve) is 4 beats
		StartCoroutine (StartTicking ());
	}

	void OnDestroy()
	{
		StopAllCoroutines ();
	}

	void Update()
	{
		if (ShouldPlay == false)
		{
			return;
		}

		_timeSinceLastTick += Time.deltaTime;

		if (_timeSinceLastTick >= _singleTickTime)
		{
			_timeSinceLastTick -= _singleTickTime;

			if (OnTickOccurred != null)
			{
				OnTickOccurred (_tickCount);

			}

			_tickCount += (1 / DIVISOR);
		}
	}
	private IEnumerator StartTicking()
	{
		yield return new WaitForSeconds (DELAY);
		ShouldPlay = true;
	}
}
