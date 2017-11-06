using UnityEngine;

namespace ProcJam2017
{
	[RequireComponent(typeof(AudioSourceCollection))]
	public class Sequencer : MonoBehaviour
	{
		public delegate void PlayNote();
		public delegate void OnSequenceFinished(float nextTick);

		public bool JustRootNotes;

		public BeatManager BeatManager;

		public ScaleDefinition Scale;

		private PatternDefinition PatternDefinition;

		public string InstrumentName;

		private AudioSourceCollection _sources;

		private float _nextNoteTick;

		private int _noteIndex;

		private bool _loop = false;

		void Awake ()
		{
			PatternDefinition = PatternGenerator.Generate (JustRootNotes);
			_sources = GetComponent<AudioSourceCollection> ();
			BeatManager.OnTickOccurred += OnTickOccurred;
		}

		public void Destroy()
		{
			BeatManager.OnTickOccurred -= OnTickOccurred;
		}

		private void OnTickOccurred(float tick)
		{
			if (tick == _nextNoteTick)
			{
				if (_noteIndex < PatternDefinition.Notes.Count)
				{
					PlayTheNote (tick);
				}
				else
				{
					if (_loop == true)
					{
						_noteIndex = 0;
						PlayTheNote (tick);
					}
				}
			}
		}

		private void PlayTheNote(float tick)
		{
			Note note = PatternDefinition.Notes [_noteIndex];
			int noteIndex = note.ScalePosition - 1;
			noteIndex = noteIndex % Scale.NoteIds.Count;

			if (noteIndex < 0)
			{
				_sources.Stop ();
			}
			else
			{
				var source = _sources.GetAvailableSource ();
				if (source != null)
				{
					AudioClip clip = NoteDatabase.Instance.GetNote (InstrumentName, Scale.NoteIds [noteIndex]);
					source.clip = clip;
					source.Play ();
				}
			}

			float lastNoteLength = NoteLength.GetValue (PatternDefinition.Notes [_noteIndex].Length);
			_nextNoteTick = tick + lastNoteLength;

			_noteIndex = (_noteIndex + 1) % PatternDefinition.Notes.Count;
		}
	}
}

