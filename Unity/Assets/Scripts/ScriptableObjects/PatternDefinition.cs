using System;
using UnityEngine;
using System.Collections.Generic;

namespace ProcJam2017
{
	[Serializable]
	public struct Note
	{
		public int ScalePosition;
		public eNoteLength Length;
	}

	[CreateAssetMenu(menuName = "Music/PatternDefinition")]
	public class PatternDefinition : ScriptableObject
	{
		public List<Note> Notes;
	}
}

