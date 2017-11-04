using UnityEngine;
using System.Collections.Generic;

namespace ProcJam2017
{
	[CreateAssetMenu(menuName = "Music/ScaleDefinition")]
	public class ScaleDefinition : ScriptableObject
	{
		public List<int> NoteIds;
	}
}

