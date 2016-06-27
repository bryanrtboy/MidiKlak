//Requires changes to NoteInput.cs
//
//#region Learn functions
//
//public void SetNoteNumberTo (int noteNumber)
//{
//	if (_noteFilter == NoteFilter.NoteName) {
//		int note = noteNumber % 12;
//		_noteName = (NoteName)note;
//		Debug.Log (_noteName.ToString ());
//	}
//
//	if (_noteFilter == NoteFilter.NoteNumber) {
//		_lowestNote = noteNumber;
//		_highestNote = noteNumber;
//	}
//}
//
//#endregion

using UnityEngine;
using System.Collections;
using MidiJack;
using UnityEngine.UI;

namespace Klak.Midi
{
	[RequireComponent (typeof(NoteLearnInput))]
	public class LearnNote : MonoBehaviour
	{

		public Image m_UIIndicator;
		public StoredNoteValue.SavedName m_name;

		MidiChannel _channel = MidiChannel.All;
		bool m_isLearning = false;
		NoteLearnInput m_noteInput;
		Text m_UIIndicatorLabel;

		void Awake ()
		{
			if (m_UIIndicator == null)
				m_UIIndicator = GetComponent<Image> () as Image;

			if (m_UIIndicator == null) {
				Debug.LogError ("I can't be expected to assign controls without a UI Image!");
				Destroy (this.gameObject);
			}

			m_UIIndicatorLabel = m_UIIndicator.GetComponentInChildren<Text> () as Text;
			if (m_UIIndicatorLabel)
				m_UIIndicatorLabel.text = m_name.ToString ();

			m_noteInput = GetComponent<NoteLearnInput> () as NoteLearnInput;

			if (PlayerPrefs.HasKey (m_name.ToString ()))
				m_noteInput.SetNoteNumberTo (PlayerPrefs.GetInt (m_name.ToString ()));
				

		}

		void OnEnable ()
		{
			MidiMaster.noteOnDelegate += NoteOn;
		}

		void OnDisable ()
		{
			MidiMaster.noteOnDelegate -= NoteOn;
		}

		void Update ()
		{
			if (m_isLearning)
				m_UIIndicator.color = new Color (1f, 0f, 0f, Mathf.PingPong (Time.time, 1));
		}


		public void EnterLearnMode ()
		{
			m_isLearning = true;
		}


		void NoteOn (MidiChannel channel, int noteNumber, float knobValue)
		{
			if (!m_isLearning)
				return;

			m_noteInput.SetNoteNumberTo (noteNumber);
			PlayerPrefs.SetInt (m_name.ToString (), noteNumber);
			m_isLearning = false;
			m_UIIndicator.color = new Color (0f, .7f, .2f, 1);

		}


	}

}
