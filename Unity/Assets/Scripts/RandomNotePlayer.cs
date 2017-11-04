using UnityEngine;
using GAudio;
using System.Collections.Generic;

namespace ProcJam2017
{
	public class RandomNotePlayer : MonoBehaviour
	{
		public GATSampleBank SampleBank;

		public List<RhythmDefinition> Rhythms;

		public RhythmSequencer Sequencer;

		private string[] _sampleNames
		{
			get {
				return SampleBank.AllSampleNames;
			}
		}

		void Start()
		{
			if (Rhythms.Count == 0)
			{
				Debug.LogError ("Need to specify at least one rhythm");
			}
			Sequencer = new RhythmSequencer (Rhythms[Random.Range(0, Rhythms.Count)], PlayNote, false, OnSequenceFinished);
		}

		void PlayNote ()
		{
			GATData sampleData = SampleBank.GetAudioData (_sampleNames [Random.Range(0, _sampleNames.Length)]);
			GATManager.DefaultPlayer.PlayData (sampleData, 0, 0.2f);
		}

		void OnSequenceFinished(float nextTick)
		{
			Sequencer.ChangeRhythm (Rhythms[Random.Range(0, Rhythms.Count)], false, nextTick);

		}
	}
}
