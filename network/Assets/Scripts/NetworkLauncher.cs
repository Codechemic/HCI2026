
using Unity.Netcode;
using UnityEngine;

public class NetworkLauncher : MonoBehaviour
{
    private void OnGUI()
    {
        if (NetworkManager.Singleton == null)
            return;

        if (NetworkManager.Singleton.IsListening)
            return;

        GUILayout.BeginArea(new Rect(10, 10, 200, 150));

        if (GUILayout.Button("Host", GUILayout.Height(40)))
        {
            NetworkManager.Singleton.StartHost();
        }

        if (GUILayout.Button("Client", GUILayout.Height(40)))
        {
            NetworkManager.Singleton.StartClient();
        }

        if (GUILayout.Button("Server", GUILayout.Height(40)))
        {
            NetworkManager.Singleton.StartServer();
        }

        GUILayout.EndArea();
    }
}
