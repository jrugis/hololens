using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if WINDOWS_UWP
using Windows.Storage.Pickers;
using Windows.Storage;
#endif

public class get_file : MonoBehaviour {

	// Use this for initialization
	void Start () {
#if UNITY_UWP
        ShowOpenPanel(true, false);
#endif
    }

    // Update is called once per frame
    void Update () {
		
	}

#if UNITY_UWP
    public static string ShowOpenPanel(bool includeFiles, bool includeDirectories)
    {
        Application.InvokeOnUIThread(async () => {
            var filePicker = new FileOpenPicker();
            filePicker.FileTypeFilter.Add("*");
            var file = await filePicker.PickSingleFileAsync();
        }, false);
        return string.Empty;
    }
#endif
}
