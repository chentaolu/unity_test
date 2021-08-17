using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class signInButton : MonoBehaviour
{
    public InputField userID;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick(){
        playerClient.SocketSend("{'sendTo':'databaseConnector', 'purpose':'registUser', 'userName':'" + userID.text + "'}");
        
    }
}
