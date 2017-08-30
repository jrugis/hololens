
//
// attach to existing "empty" Particle System
//   NOTE: disable Looping, Play On Awake 
// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using System.IO;
using UnityEngine.UI;

public class download_file : MonoBehaviour {
    public string url = "";
    private ParticleSystem nodes;
    private ParticleSystem.Particle[] points;

    //void Start()
    IEnumerator Start() 
    {
        DisplayMessage_00("downloading files...");

        // download data file url
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();    // wait for download
        string data_url = System.Text.Encoding.ASCII.GetString(www.downloadHandler.data);
        Debug.Log("data file URL: " + data_url);

        // download data file
        www = UnityWebRequest.Get(data_url);
        yield return www.SendWebRequest();    // wait for download
        string data = System.Text.Encoding.ASCII.GetString(www.downloadHandler.data);
        StringReader data_sr = new StringReader(data);

        // parse data file
        string line;
        do line = data_sr.ReadLine(); while (line != "$Nodes");
        int node_count = int.Parse(data_sr.ReadLine());
        node_count = 1000;
        Debug.Log("node count: " + node_count.ToString());

        // create particle system points from data
        nodes = gameObject.GetComponent<ParticleSystem>();
        const float point_size = 0.001f;
        const float nodes_scale = 0.01f;
        points = new ParticleSystem.Particle[node_count];
        for (int i = 0; i < node_count; i++)
        {
            string[] entries = data_sr.ReadLine().Split();
            float x = nodes_scale * float.Parse(entries[1]);
            float y = nodes_scale * float.Parse(entries[2]);
            float z = nodes_scale * float.Parse(entries[3]);

            points[i].position = new Vector3(x, y, z);
            points[i].color = new Color(1f, 0f, 0f);
            points[i].size = point_size;
        }
        DisplayMessage_00("");
    }

    private void DisplayMessage_00(string message)
    {
        Text t = GameObject.Find("Message_00").GetComponent<Text>();
        t.fontSize = 30;
        t.text = message;
    }

    // Update is called once per frame
    void Update () {
        if (points == null) return;
        points[0].color = Color.green;
        nodes.SetParticles(points, points.Length);

    }
}
