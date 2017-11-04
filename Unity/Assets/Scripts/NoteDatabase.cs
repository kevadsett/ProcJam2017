using System.Collections.Generic;

using UnityEngine;

namespace ProcJam2017
{
	public class NoteDatabase
	{
		private static NoteDatabase _instance;
		public static NoteDatabase Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new NoteDatabase ();
					_instance.Load ();
				}
				return _instance;
			}
		}

		private Dictionary<string, Dictionary<int, AudioClip>> _notes;

		private void Load()
		{
			_notes = new Dictionary<string, Dictionary<int, AudioClip>> ();

			NoteDefinition[] definitions = Resources.LoadAll<NoteDefinition>("NoteDefinitions");
			for (int i = 0; i < definitions.Length; i++)
			{
				NoteDefinition noteDef = definitions [i];
				Dictionary<int, AudioClip> clipList;

				if (_notes.TryGetValue (noteDef.InstrumentName, out clipList) == false)
				{
					clipList = new Dictionary<int, AudioClip> ();
					_notes.Add (noteDef.InstrumentName, clipList);
				}

				clipList.Add (noteDef.NoteId, noteDef.Sample);
			}
		}

		public AudioClip GetNote(string instrumentName, int noteId)
		{
			Dictionary<int, AudioClip> clipList;
			if (_notes.TryGetValue (instrumentName, out clipList))
			{
				AudioClip clip;
				if (clipList.TryGetValue (noteId, out clip))
				{
					return clip;
				}
			}

			return null;
		}
	}
}

