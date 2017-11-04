using System;
using UnityEngine;

namespace ProcJam2017
{
	[CreateAssetMenu(menuName = "Music/NoteDefinition")]
	public class NoteDefinition : ScriptableObject
	{
		public AudioClip Sample;
		public int NoteId;
		public string InstrumentName;

		public NoteDefinition ()
		{
		}
	}
}

