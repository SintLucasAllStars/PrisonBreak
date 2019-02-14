using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Web : MonoBehaviour
{
    
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log(": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log( ":\nReceived: " + webRequest.downloadHandler.text);
                
                
            }
        }
    }
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRequest("http://www.moonmoonmoonmoon.com/api/marks"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
