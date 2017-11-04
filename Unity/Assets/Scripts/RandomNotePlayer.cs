using UnityEngine;
using System.Collections.Generic;

namespace ProcJam2017
{
	public class RandomNotePlayer : MonoBehaviour
	{

		public List<RhythmDefinition> Rhythms;

		public RhythmSequencer Sequencer;


		void Start()
		{
			if (Rhythms.Count == 0)
			{
				Debug.LogError ("Need to specify at least one rhythm");
			}
			Sequencer = new RhythmSequencer (Rhythms[Random.Range(0, Rhythms.Count)], PlayNote, OnSequenceFinished);
		}

		void PlayNote ()
		{
			
		}

		void OnSequenceFinished(float nextTick)
		{
			Sequencer.ChangeRhythm (Rhythms[Random.Range(0, Rhythms.Count)], nextTick);

		}
	}
}
