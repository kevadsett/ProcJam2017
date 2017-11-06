using UnityEngine;

namespace ProcJam2017
{
	public static class PatternGenerator
	{
		public static PatternDefinition Generate(bool JustRootNotes)
		{
			PatternDefinition pattern = ScriptableObject.CreateInstance<PatternDefinition> ();
			pattern.Notes = new System.Collections.Generic.List<Note> ();
			if (JustRootNotes)
			{
				Note note = new Note ();
				note.Length = eNoteLength.Crotchet;
				note.ScalePosition = 1;
				pattern.Notes.Add (note);
			}
			else
			{
				int noteCount = Random.Range (1, 16);
				var lengthValues = System.Enum.GetValues (typeof(eNoteLength));
				for (int i = 0; i < noteCount; i++)
				{
					Note note = new Note ();
					note.Length = (eNoteLength)lengthValues.GetValue (Random.Range (0, lengthValues.Length));
					note.ScalePosition = Random.Range (1, 17);
					pattern.Notes.Add (note);
				}
			}
			return pattern;
		}
	}
}

