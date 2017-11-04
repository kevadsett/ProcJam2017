using System;
using UnityEngine;

namespace ProcJam2017
{
	public class RhythmSequencer
	{
		public delegate void PlayNote();
		public delegate void OnSequenceFinished(float nextTick);

		private readonly PlayNote _playNoteAction;
		private readonly OnSequenceFinished _sequenceFinishedAction;

		private RhythmDefinition _definition;
		private bool _loop;

		private float _nextNoteTick;

		private int _noteIndex;

		public RhythmSequencer (RhythmDefinition definition, PlayNote playNoteAction, bool loop, OnSequenceFinished sequenceFinishedAction)
		{
			_definition = definition;
			_playNoteAction = playNoteAction;
			_sequenceFinishedAction = sequenceFinishedAction;
			_loop = loop;
			BeatManager.OnTickOccurred += OnTickOccurred;
		}

		public void Destroy()
		{
			BeatManager.OnTickOccurred -= OnTickOccurred;
		}

		public void ChangeRhythm (RhythmDefinition newDefinition, bool loop, float startTick)
		{
			Debug.Log ("CHANGE RHYTHM");
			_definition = newDefinition;
			_loop = loop;
			_nextNoteTick = startTick;
			_noteIndex = 0;
		}

		private void OnTickOccurred(float tick)
		{
			Debug.Log (string.Format ("Current tick: {0}, next note at {1}", tick, _nextNoteTick));
			if (tick == _nextNoteTick)
			{
				if (_noteIndex < _definition.Notes.Count)
				{
					PlayTheNote (tick);
				}
				else
				{
					_sequenceFinishedAction (_nextNoteTick);
					PlayTheNote (tick);
				}
			}
		}

		private void PlayTheNote(float tick)
		{
			_playNoteAction ();
			float lastNoteLength = RhythmDefinition.GetValue (_definition.Notes [_noteIndex]);
			_nextNoteTick = tick + lastNoteLength;
			_noteIndex++;
		}
	}
}

