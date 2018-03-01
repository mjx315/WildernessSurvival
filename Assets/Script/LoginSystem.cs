using UnityEngine;
using UnityEngine.UI;
using System;
using System.Data;
using System.Data.SqlClient;

public class LoginSystem : MonoBehaviour {
    //用户字段
    public InputField AccountInput;
    //密码字段
    public InputField PasswordInput;
    //提交按钮
    public Button SubmitButton;
    //数据连接
    private SqlConnection SqlConnection;
    //音效管理器
    public AudioManager AudioManager;
    public Canvas OptionCanvas;
    public Camera UICamera;
    public Slider VolumeSlider;
    
    //private string SqlState;
	// Use this for initialization
	void Start () {
        //SubmitButton.onClick.AddListener(this.SubmitButtonOnClick);
        CloseOption();
	}
	
	// Update is called once per frame
	void Update () {
        AudioManager.Volume = VolumeSlider.value;
	}
    public void GetInput()
    {
        string Password = PasswordInput.GetComponent<InputField>().text;
        string Account = AccountInput.GetComponent<InputField>().text;
    }

    //连接数据库
    void SqlConnect()
    {
        const string constr = "Data Source=MJX;Initial Catalog=db;Integrated Security=True";
        SqlConnection = new SqlConnection(constr);
        Debug.Log("已连接数据库");
        if (SqlConnection.State == System.Data.ConnectionState.Closed)
            SqlConnection.Open();
        if (SqlConnection.State == System.Data.ConnectionState.Open)
            SqlConnection.Close();
        SqlCommand Sqlcmd = new SqlCommand();
        Sqlcmd.Connection = SqlConnection;
        Sqlcmd.CommandText = "select Account from Users where Account='mjx';";
    }
    //按钮触发
    public void SubmitButtonOnClick()
    {
        //Debug.Log("click");
        //SqlConnect();
        //AudioManager.GetComponent<AudioManager>().AudioSource.Play();
        //AudioManager.Play("Audio/ButtonEffect");
        Submit();
    }
    public void InputOnValueChange()
    {
        AudioManager.Play("Audio/InputEffect");
        Debug.Log("Input");
    }
    public void Submit()
    {
        AudioManager.Play("Audio/ButtonEffect");
        SqlConnect();
    }
   public void OptionButtonOnClick()
    {
        if (OptionCanvas.enabled == true)
        {
            CloseOption();
        }
        if (OptionCanvas.enabled == false)
        {
            ShowOption();
        }
        AudioManager.Play("Audio/ButtonEffect");
    }
    public void ShowOption()
    {
        OptionCanvas.enabled = true;
    }
    public void CloseOption()
    {
        OptionCanvas.enabled = false;
    }
    
}