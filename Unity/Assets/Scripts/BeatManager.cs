using System.Collections;
using UnityEngine;

public class BeatManager : MonoBehaviour
{
	public int BPM = 120;

	public int BeatsPerBar = 4;

	public bool ShouldPlay = true;

	public float Delay = 0.5f;

	public delegate void BeatOccurredAction(int beatNumber, int barNumber);
	public static event BeatOccurredAction OnCrotchetOccurred;

	private const float DIVISOR = 8f;
	private float _tickCount = 1f;

	private int _barCount = 1;

	void Start ()
	{
		StartCoroutine (DoBeat ());
	}

	private IEnumerator DoBeat()
	{
		yield return new WaitForSeconds (Delay);
		while (true)
		{
			if (ShouldPlay)
			{
				Debug.Log ("[" + _barCount + ": " + _tickCount + "]");
				if (_tickCount % 1 == 0)
				{
					if (OnCrotchetOccurred != null)
					{
						OnCrotchetOccurred ((int)_tickCount, _barCount);
					}

				}
				_tickCount += (1 / DIVISOR);
				if (_tickCount == BeatsPerBar + 1)
				{
					_tickCount = 1f;
					_barCount++;
				}
			}
			yield return new WaitForSeconds (60f / (float)BPM / DIVISOR);
		}
	}
}
