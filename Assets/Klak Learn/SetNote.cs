using UnityEngine;
using System;
using System.Collections;
using MidiJack;


namespace Klak.Midi
{
	[RequireComponent (typeof(NoteInput))]
	public class SetNote : MonoBehaviour
	{

		//What the name of this knob corresponds to
		public StoredNoteValue.SavedName m_name;

		NoteInput m_noteInput;

		void Awake ()
		{
			m_noteInput = GetComponent<NoteInput> () as NoteInput;
		}

		void Start ()
		{
			if (PlayerPrefs.HasKey (m_name.ToString ()))
				m_noteInput.SetNoteNumberTo (PlayerPrefs.GetInt (m_name.ToString ()));
		}
	}

	[Serializable]
	public class StoredNoteValue
	{

		public enum SavedName
		{
			Button1,
			Button2,
			Button3,
			Button4,
			Button5,
			Button6,
			Button7,
			Button8
		}

		[SerializeField]
		public SavedName name = SavedName.Button1;
	}
}
