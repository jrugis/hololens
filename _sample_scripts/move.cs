using System;
using System.Text;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class move: MonoBehaviour
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
        if (args.text == m_Keywords[0])
        {
            transform.localPosition += new Vector3(0, 0.1F, 0); // move up
        }
        else if (args.text == m_Keywords[1])
        {
            transform.localPosition -= new Vector3(0, 0.1F, 0); // move down
        }
    }
}