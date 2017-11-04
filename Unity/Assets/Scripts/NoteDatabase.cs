using System;
using System.Collections.Generic;

using UnityEngine;

namespace ProcJam2017
{
	public static class NoteDatabase
	{
		private static Dictionary<string, Dictionary<int, AudioClip>> _notes;

		public static void Load()
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

		public static AudioClip GetNote(string instrumentName, int noteId)
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

