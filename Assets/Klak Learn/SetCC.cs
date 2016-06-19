using UnityEngine;
using System;
using System.Collections;
using MidiJack;


namespace Klak.Midi
{
	[RequireComponent (typeof(KnobInput))]
	public class SetCC : MonoBehaviour
	{

		//What the name of this knob corresponds to
		public StoredCCValue.SavedName m_name;

		KnobInput m_knob;

		void Awake ()
		{
			m_knob = GetComponent<KnobInput> () as KnobInput;
		}

		void Start ()
		{
			if (PlayerPrefs.HasKey (m_name.ToString ()))
				m_knob.SetKnobNumberTo (PlayerPrefs.GetInt (m_name.ToString ()));
		}
	}

	[Serializable]
	public class StoredCCValue
	{

		public enum SavedName
		{
			Knob1,
			Knob2,
			Knob3,
			Knob4,
			Knob5,
			Knob6,
			Knob7,
			Knob8
		}

		[SerializeField]
		public SavedName name = SavedName.Knob1;
	}
}
