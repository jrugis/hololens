using System;
using System.Text;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class all_vis_on: MonoBehaviour
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
        Renderer[] renders = GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in renders)
            rend.enabled = true;
    }
}