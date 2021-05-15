using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 砖块生成控制脚本
/// </summary>
public class Brick : MonoBehaviour
{
    public GameObject brick_1;//红砖模型
    public GameObject brick_2;//黄砖模型
    public Vector3 clone_brick;//砖块位置基准  
    
    public int[,] bricks;//砖块位置数组
    public int brick_number;//砖块数量
    public bool check;//是否开始定义砖块位置
    public bool reset;//是否重新生成砖块
    public int choose = -1;//选择那种砖块定义模式
    public bool again;//是否是再次进入游戏
    public int[,] special =
    {
        {0,0,0,0,0,0,0,0,0,1 },//1
        {0,0,1,1,1,1,1,1,1,1 },//8
        {0,0,1,0,0,1,0,0,0,0 },//2
        {0,0,1,1,1,1,1,1,1,0 },//7
        {0,0,0,0,0,0,0,0,1,0 },//1
        {0,0,0,1,1,1,0,0,0,0 },//3
        {0,0,0,1,0,0,0,0,0,0 },//1
        {1,1,1,1,1,1,1,1,1,1 },//10
        {0,0,0,1,0,0,0,0,0,0 },//1
        {0,0,0,1,1,1,1,0,0,0 },//4
    };//彩蛋砖块图

    // Update is called once per frame
    public void DefinedTheBricks_0(int brick_number)//第零种定义模式
    {
        while (brick_number > 0)//随机生成定义数量的砖块(属于反向生成)
        {
            int m = 0, n = 0;
            m = Random.Range(0, 10);
            n = Random.Range(0, 10);
            if (bricks[m, n] != 0)
            {
                bricks[m, n] = 0;
                brick_number--;
            }
        }
    }

    public void DefinedTheBricks_1()//第一种定义模式
    {
        for (int i = 0; i < 5; i++) 
        {
            for (int j = 0; j < i; j++)
                bricks[j, 9 - i] = 0;
            for (int j = 9; j > 9 - i; j--)
                bricks[j, 9 - i] = 0;
        }
        for(int i=5;i<10;i++)
        {
            for (int j = 0; j < 10; j++)
                bricks[j, 9 - i] = 0;
        }
    }
    public void DefinedTheBricks_2()//第二种定义模式
    {
        for(int i=0;i<10;i+=2)
        {
            for (int j = 0; j < 10; j++)
                bricks[j, i] = 0;
        }
    }
    public void DefinedTheBricks_3()//第三种定义模式
    {
        for (int i = 0; i < 10; i ++)
        {
            for (int j = 0; j < 10; j++)
                bricks[i, j] = special[9 - i, 9 - j]; 
        }
    }

    public void CreateTheBricks()//在游戏场景生成砖块
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (bricks[i, j] == 1)
                {
                    clone_brick.x = i * 2 - 9;//定义位置
                    clone_brick.y = j;
                    clone_brick.z = 1;
                    GameObject a = GameObject.Instantiate(brick_1, clone_brick, transform.rotation);//赋上模型、位置和方向
                    a.transform.parent = this.transform;//绑定父物体
                }
                if (bricks[i, j] == 2)
                {
                    clone_brick.x = i * 2 - 9;
                    clone_brick.y = j;
                    clone_brick.z = 1;
                    GameObject a = GameObject.Instantiate(brick_2, clone_brick, transform.rotation);
                    a.transform.parent = this.transform;
                }
            }
        }
    }

    void Start()
    {
        bricks = new int[10, 10];
        for (int i = 0; i < 10; i++)//初始化砖块颜色
        {
            for (int j = 0; j < 10; j++)
            {
                if ((i + j) % 2 == 0)
                    bricks[i, j] = 1;
                else
                    bricks[i, j] = 2;
            }
        }
        check = false;
        reset = false;
        again = false;
    }

    void Update()
    {
        if(check)//开始定义砖块
        {
            brick_number = 100 - brick_number;//反向生成的砖块数
            if(again==false)
            {
                switch (choose)//选择定义模式
                {
                    case 0:
                        DefinedTheBricks_0(brick_number);
                        break;
                    case 1:
                        DefinedTheBricks_1();
                        break;
                    case 2:
                        DefinedTheBricks_2();
                        break;
                    case 3:
                        DefinedTheBricks_3();
                        break;
                    default:
                        Debug.Log("出错");
                        break;
                }
                CreateTheBricks();//在场景中生成砖块
                check = false;//一次只生成一次砖块
            }
        }
        if (reset)//重新生成砖块
        {
            CreateTheBricks();
            reset = false;
        }
        if(again==true)//再次开始游戏的时候重新初始化砖块
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if ((i + j) % 2 == 0)
                        bricks[i, j] = 1;
                    else
                        bricks[i, j] = 2;
                }
            }
        }
    }
}
