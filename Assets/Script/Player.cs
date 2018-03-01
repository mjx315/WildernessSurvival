using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    //角色控制器
    public CharacterController CharacterController;
    //模拟重力
    public float vy = 0;
    //重力加速度
    public float graity = -8;

    //摄像机
    public Camera camera;
	// Use this for initialization
	void Start () {
        camera = Camera.main;
        //camera.transform.eulerAngles = new Vector3(45, 45, 45);
	}
	
	// Update is called once per frame
	void Update () {
        PlayerMove();
        CameraControl();
    }

#region 控制主角移动
    public void PlayerMove()
    {
        //水平轴输入值
        float vx = Input.GetAxis("Horizontal");
        //垂直轴输入值
        float vz = Input.GetAxis("Vertical");
        //CharacterController.SimpleMove(new Vector3(1,0,0));
        //CharacterController.Move(new Vector3(1, 0, 0));
        //Debug.Log(Input.GetKeyDown(KeyCode.Space));
        //Debug.Log(Input.GetAxis("Horizontal"));
        //重力计算
        //检测主角是否着地
        if (!CharacterController.isGrounded)
        {
            vy += graity * Time.deltaTime;
        }
        //跳跃
        if (CharacterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            vy = 2;
        }
        //角色移动
        CharacterController.Move(CharacterController.transform.TransformDirection(new Vector3(vx, vy, vz) * Time.deltaTime));

    }
#endregion
    
#region 摄像机视角旋转
    private void CameraControl()
    {
        //获取摄像机欧拉角
        Vector3 cmEuler = camera.transform.eulerAngles;
        cmEuler.y += Input.GetAxis("Mouse Y") * Time.deltaTime;
        cmEuler.x += Input.GetAxis("Mouse X") * Time.deltaTime;
        camera.transform.eulerAngles = cmEuler;

        //同步主角的欧拉角
        cmEuler.x = cmEuler.z = 0;
        this.transform.eulerAngles = cmEuler;

        //摄像机跟随
        camera.transform.position = this.transform.position;
    }
#endregion
}
