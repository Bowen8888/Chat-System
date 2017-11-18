using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chat : MonoBehaviour
{
    public List<string> chatHistory = new List<string>();
    private string currentMessage = string.Empty;
    private void OnGUI()
    {
        GUILayout.BeginHorizontal(GUILayout.Width(250));
        currentMessage = GUILayout.TextField(currentMessage);
        if ( GUILayout.Button("Send"))
        {
            if(!string.IsNullOrEmpty(currentMessage.Trim()))
            {
                networkView.RPC("CharMessage", RPCMode.AllBuffered, new object[] { currentMessage});
                currentMessage = string.Empty;
            }
        }
        GUILayout.EndHorizontal();

        foreach(string c in chatHistory)
        {
            GUILayout.Label(c);
        }



    }
	
}
