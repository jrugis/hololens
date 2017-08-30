using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using System.IO;

public class create_nodes : MonoBehaviour {
    public string url = "https://onedrive.live.com/download?cid=3165488F3D3410E7&resid=3165488F3D3410E7%213106&authkey=AAQ9g5bO5jqlubk";
    private ParticleSystem nodes;
    private ParticleSystem.Particle[] points;

    IEnumerator Start() {
        const float point_size = 0.2f;
        const float nodes_scale = 0.01f;

        string line;
        int node_count;

        nodes = gameObject.GetComponent<ParticleSystem>();

        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();
        string fileData = System.Text.Encoding.ASCII.GetString(www.downloadHandler.data);
        StringReader strReader = new StringReader(fileData);

        do line = strReader.ReadLine(); while (line != "$Nodes");
        node_count = int.Parse(strReader.ReadLine());
        Debug.Log(node_count.ToString() + "nodes input");

        points = new ParticleSystem.Particle[node_count];
        for (int i = 0; i < node_count; i++) {
            string[] entries = strReader.ReadLine().Split();
            float x = nodes_scale * float.Parse(entries[1]);
            float y = nodes_scale * float.Parse(entries[2]);
            float z = nodes_scale * float.Parse(entries[3]);

            points[i].position = new Vector3(x, y, z);
            points[i].color = new Color(1f, 0f, 0f);
            points[i].size = point_size;
        }
        Debug.Log("particles assigned");
    }

    // Update is called once per frame
    void Update () {
        if (points == null) return;
        points[0].color = Color.green;
        nodes.SetParticles(points, points.Length);
    }
}
