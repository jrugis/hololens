using System;
using System.Text;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class resize: MonoBehaviour
{
    [SerializeField]
    private string[] m_Keywords;
    private KeywordRecognizer m_Recognizer;

    Vector3 original_size;
    Vector3 original_position;

    void Start()
    {
        original_size = transform.localScale;
        original_position = transform.localPosition;

        m_Recognizer = new KeywordRecognizer(m_Keywords);
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_Recognizer.Start();
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        if (args.text == m_Keywords[0])
        {
            transform.localScale *= 1.1F; // larger
        }
        else if (args.text == m_Keywords[1])
        {
            transform.localScale /= 1.1F; // smaller
        }
        if (args.text == m_Keywords[2])
        {
            transform.localScale *= 2.0F; //double size
        }
        else if (args.text == m_Keywords[3])
        {
            transform.localScale /= 2.0F; // half size
        }
        else if (args.text == m_Keywords[4])
        {
            transform.localScale = original_size; // original size
            transform.localPosition = original_position; // original position
        }
    }
}