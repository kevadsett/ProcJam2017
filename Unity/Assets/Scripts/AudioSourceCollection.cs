using System.Collections.Generic;
using UnityEngine;

namespace ProcJam2017
{
	public class AudioSourceCollection : MonoBehaviour
	{
		public int PoolSize = 10;

		[Range(0.0f, 1.0f)]
		public float Volume = 1.0f;

		[Range(0.0f, 2.0f)]
		public float Pitch = 1.0f;

		private List<AudioSource> _collection;

		void Start ()
		{
			_collection = new List<AudioSource> ();
			for (int i = 0; i < PoolSize; i++)
			{
				var source = gameObject.AddComponent <AudioSource> ();
				source.volume = Volume;
				source.pitch = Pitch;
				_collection.Add (source);
			}
		}

		public AudioSource GetAvailableSource()
		{
			foreach (AudioSource source in _collection)
			{
				if (source.isPlaying == false)
				{
					return source;
				}
			}
			return null;
		}

		public void Stop()
		{
			foreach (AudioSource source in _collection)
			{
				source.Stop ();
			}
		}
	}
}

