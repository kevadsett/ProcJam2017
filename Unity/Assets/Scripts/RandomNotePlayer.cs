using UnityEngine;
using GAudio;

public class RandomNotePlayer : MonoBehaviour
{
	public GATSampleBank SampleBank;

	public BeatManager BeatManager;

	private string[] _sampleNames
	{
		get {
			return SampleBank.AllSampleNames;
		}
	}

	void OnEnable ()
	{
		BeatManager.OnCrotchetOccurred += OnBeatOccurred;
	}

	void Disable()
	{
		BeatManager.OnCrotchetOccurred -= OnBeatOccurred;
	}

	void OnBeatOccurred (int beatCount, int barCount)
	{
		GATData sampleData = SampleBank.GetAudioData (_sampleNames [Random.Range(0, _sampleNames.Length)]);
		GATManager.DefaultPlayer.PlayData (sampleData, 0, 0.2f);
	}
}
