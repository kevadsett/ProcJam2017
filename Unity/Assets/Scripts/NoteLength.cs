namespace ProcJam2017
{
	public enum eNoteLength
	{
		SemiBreve = 32,
		DottedMinim = 24,
		Minim = 16,
		DottedCrotchet = 12,
		Crotchet = 8,
		DottedQuaver = 6,
		Quaver = 4,
		DottedSemiQuaver = 3,
		SemiQuaver = 2
	}

	public static class NoteLength
	{
		public static float GetValue(eNoteLength noteLength)
		{
			return (float)noteLength / 32f;
		}
	}

}
