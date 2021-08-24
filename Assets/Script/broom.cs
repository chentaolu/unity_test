using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class broom : MonoBehaviour
{
    public float Speed = 5000;
    public float anSpeed = 5f;
    public int speed_MAX = 1000;
    private float ftime;
    public bool isStart;
    Rigidbody rigi;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hello");
        rigi = this.gameObject.GetComponent<Rigidbody>();
        isStart = true;
        ftime = 0f;
    }

    // Update is called once per frame
    void Update()
    {   
        //rigi.AddForce(new Vector3(0, -8000, 0), ForceMode.Force);
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //rigi.velocity = transform.forward * v * Speed * 50;
        if ( Input.GetKey("up")){
            //transform.Translate (Speed, 0, 0);
            if(rigi.velocity.z > -speed_MAX && rigi.velocity.z < speed_MAX && rigi.velocity.x > -speed_MAX && rigi.velocity.x < speed_MAX){
                rigi.AddForce(transform.forward * Speed, ForceMode.Force);
            }
              
        }

        if(isStart){
            ftime += Time.deltaTime;
            if(ftime >= 1f){
                print(ftime);
                playerClient.SocketSend("{'sendTo':'calculator', 'CurrentSpeed': " + Mathf.Abs(rigi.velocity.z) + "}\n");
                ftime = 0f;
            }
            
        }

        
        
        
        

        //print(rigi.velocity);
        rigi.angularVelocity = transform.up * h * anSpeed;
        /*rigi.AddForce(new Vector3(0, 0, 50), ForceMode.Force);
        //rigi.MovePosition(this.transform.position+new Vector3(-v,0,h)*Speed*Time.deltaTime);
        if(Input.GetAxis("Horizontal")!=0|| Input.GetAxis("Vertical")!=0)
        {
            Rotating(h,v);
        }*/

        

        /*if ( Input.GetKey("up")) {  
            //transform.Translate (speed, 0, 0);
            //rigi.AddForce(new Vector3(0, 0, 50), ForceMode.Force);  
            //transform.Translate(speed, 0, 0);
        }*/

        //if ( Input.GetKey("down")) {  rigi.AddForce(new Vector3(0, 0, -50), ForceMode.Force);  }

        /*if ( Input.GetKey("left")) {  
            transform.Rotate(0, -0.5f, 0);
        }*/

        //if ( Input.GetKey("right")) {  transform.Rotate(0, 0.5f, 0);  }        

        if ( Input.GetKey("z")) {  
            //this.gameObject.transform.position += new Vector3(0, 3, 0);  
            rigi.velocity = new Vector3(0,0,0);
        }

        if ( Input.GetKey("x")) {  this.gameObject.transform.position += new Vector3(0, 3, 0);  }
        
    }

    void Rotating(float horizontal, float vertical)
    {
        // 创建角色目标方向的向量
        Vector3 targetDirection = new Vector3(-vertical, 0f, horizontal);
        // 创建目标旋转值 并假设Y轴正方向为"上"方向
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up); //函数参数解释: LookRotation(目标方向为"前方向", 定义声明"上方向")
        // 创建新旋转值 并根据转向速度平滑转至目标旋转值
        //函数参数解释: Lerp(角色刚体当前旋转值, 目标旋转值, 根据旋转速度平滑转向)
        Quaternion newRotation = Quaternion.Lerp(rigi.rotation, targetRotation, Speed * Time.deltaTime);
        // 更新刚体旋转值为 新旋转值
        rigi.MoveRotation(newRotation);
    }
}
