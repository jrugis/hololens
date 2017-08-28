using System;
using System.Text;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class toggle_vis : MonoBehaviour
{
    [SerializeField]
    private string[] m_Keywords;

    private KeywordRecognizer m_Recognizer;

    void Start()
    {
        m_Recognizer = new KeywordRecognizer(m_Keywords);
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_Recognizer.Start();
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
    }
}