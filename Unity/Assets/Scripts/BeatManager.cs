using System.Collections;
using UnityEngine;

public class BeatManager : MonoBehaviour
{
	public int BPM = 120;

	public bool ShouldPlay = true;

	private const float DELAY = 0.5f;

	public delegate void TickOccurredAction(float tick);
	public static event TickOccurredAction OnTickOccurred;

	private const float DIVISOR = 32f;
	private float _tickCount = 0f;

	void Start ()
	{
		StartCoroutine (StartTicking ());
	}

	void OnDestroy()
	{
		StopAllCoroutines ();
	}

	private IEnumerator StartTicking()
	{
		yield return new WaitForSeconds (DELAY);
		while (true)
		{
			if (ShouldPlay)
			{
				if (OnTickOccurred != null)
				{
					OnTickOccurred (_tickCount);

				}
				_tickCount += (1 / DIVISOR);
			}
			yield return new WaitForSeconds (60f / (float)BPM / DIVISOR * 4); // because a whole note (semibreve) is 4 beats
		}
	}
}
