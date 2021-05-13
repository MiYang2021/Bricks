using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 退出页面的控制脚本
/// </summary>

public class quet : MonoBehaviour
{
    public Button YES;//确认退出按钮
    public Button NO;//否认退出按钮
    /*其他脚本变量
     * UI_SET set_quet
     */
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        YES.GetComponent<Button>().onClick.AddListener(delegate ()//确认退出后退出应用
        {
            Application.Quit();
        });
        NO.GetComponent<Button>().onClick.AddListener(delegate ()//否认退出后返回
        {
            GameObject.Find("Main Camera").GetComponent<UI_SET>().set_quet = false;
        });
    }
}
