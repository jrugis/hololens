using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.WSA.Input;

public class clicked : MonoBehaviour {
    GestureRecognizer gr = null;

    void Start () {
        gr = new GestureRecognizer();
        gr.TappedEvent += TappedEventDelegate;
        gr.StartCapturingGestures();
    }
    void TappedEventDelegate(InteractionSourceKind source, int tapCount, Ray headRay)
    {
        if (source == InteractionSourceKind.Hand)
        {
            GetComponent<Text>().enabled = !GetComponent<Text>().enabled;
        }
    }
}
