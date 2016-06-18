using UnityEngine;
using System.Collections;
using MidiJack;
using UnityEngine.UI;

namespace Klak.Midi
{
	[RequireComponent (typeof(KnobInput))]
	public class LearnCC : MonoBehaviour
	{

		public Image m_UIIndicator;
		public StoredCCValue.SavedName m_name;

		MidiChannel _channel = MidiChannel.All;
		bool m_isLearning = false;
		KnobInput m_knob;
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

			m_knob = GetComponent<KnobInput> () as KnobInput;

			if (PlayerPrefs.HasKey (m_name.ToString ()))
				m_knob.SetKnobNumberTo (PlayerPrefs.GetInt (m_name.ToString ()));
				

		}

		void OnEnable ()
		{
			MidiMaster.knobDelegate += OnKnobUpdate;
		}

		void OnDisable ()
		{
			MidiMaster.knobDelegate -= OnKnobUpdate;
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


		void OnKnobUpdate (MidiChannel channel, int knobNumber, float knobValue)
		{
			if (!m_isLearning)
				return;

			m_knob.SetKnobNumberTo (knobNumber);
			PlayerPrefs.SetInt (m_name.ToString (), knobNumber);
			m_isLearning = false;
			m_UIIndicator.color = new Color (0f, .7f, .2f, 1);

		}


	}

}
