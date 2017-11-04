using UnityEngine;

namespace ProcJam2017
{
	public class ScalePlayer : MonoBehaviour
	{
		public AudioSource Source;

		public string InstrumentName;

		public ScaleDefinition Scale;

		public RhythmDefinition Rhythm;

		private RhythmSequencer _sequencer;

		private int _index;

		void Start()
		{
			_sequencer = new RhythmSequencer (Rhythm, PlayNote, null, true);
		}

		void Disable()
		{
			_sequencer.Destroy ();
		}

		void PlayNote ()
		{
			AudioClip clip = NoteDatabase.Instance.GetNote (InstrumentName, Scale.NoteIds [_index]);
			Source.clip = clip;
			Source.Play ();
			_index = (_index + 1) % Scale.NoteIds.Count;
		}
	}
}
