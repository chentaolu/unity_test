using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class playerClient : MonoBehaviour
{
    public static bool isLogin = false;
    public static Socket serverSocket;
    IPAddress ip;
    public static IPEndPoint ipEnd;
    string recvString;
    string sendString;
    byte[] recvData = new byte[1024];
    public static byte[] sendData = new byte[1024];
    int recvLen;
    public static Thread connectThread;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hello world!");
        if (!isLogin){
            initSocket();
            isLogin = true;
        }          
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void initSocket()
    {
        try
        {   
            if (!IPAddress.TryParse ("0.tcp.ap.ngrok.io", out ip))
                ip = Dns.GetHostEntry ("0.tcp.ap.ngrok.io").AddressList[0];
            ipEnd = new IPEndPoint(ip, 13800);
            //server_ip_port
           /* ip = IPAddress.Parse("0.tcp.ap.ngrok.io".Text);
            print(ip);
            ipEnd = new IPEndPoint(ip, 13800);*/
            SocketConnect();
            SocketSend("{'component': 'player'}\n");
        } 
        catch (System.Net.Sockets.SocketException ex)
        {
            Debug.Log(ex);
        }

    }

    public static void SocketConnect()
    {   
        if (serverSocket != null)
        {
            serverSocket.Close();
        }
        serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        print("ready to connect");
        serverSocket.Connect(ipEnd);

    }

    public static void SocketSend(string sendStr)
    {
        //清空傳送快取
        sendData = new byte[1024];
        //資料型別轉換
        sendData = Encoding.ASCII.GetBytes(sendStr);
        //傳送
        serverSocket.Send(sendData, sendData.Length, SocketFlags.None);
    }


    public static void SocketQuit()
    {
        //關閉執行緒
        if (connectThread != null)
        {
            connectThread.Interrupt();
            connectThread.Abort();
        }
        //最後關閉伺服器
        if (serverSocket != null)
            serverSocket.Close();
        print("diconnect");
    }
}
