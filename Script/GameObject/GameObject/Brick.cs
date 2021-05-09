using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;



public class Brick : MonoBehaviour
{

    public int brick_number;
    public GameObject brick_1;
    public GameObject brick_2;
    public int[,] bricks;
    public Vector3 clone_brick;
    public bool check;

    //public int GetRandomSeed()
    //{
    //    byte[] bytes = new byte[4];
    //    System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
    //    rng.GetBytes(bytes);
    //    return BitConverter.ToInt32(bytes, 0);
    //}
    //public void GetRandom(int num, int size)
    //{
    //    System.Random random = new System.Random(GetRandomSeed());
    //    num = random.Next(0, size);
    //}


    // Start is called before the first frame update

    //}

    // Update is called once per frame

    void Start()
    {
        bricks = new int[10, 10];
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
        check = false;
    }

    void Update()
    {
        if(check)
        {
            brick_number = 100 - brick_number;
            while (brick_number > 0)
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
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (bricks[i, j] == 1)
                    {
                        clone_brick.x = i * 2 - 9;
                        clone_brick.y = j;
                        clone_brick.z = 1;
                        GameObject a = GameObject.Instantiate(brick_1, clone_brick, transform.rotation);
                    }
                    if (bricks[i, j] == 2)
                    {
                        clone_brick.x = i * 2 - 9;
                        clone_brick.y = j;
                        clone_brick.z = 1;
                        GameObject a = GameObject.Instantiate(brick_2, clone_brick, transform.rotation);
                    }
                }
            }
            check = false;
            
        }
    }
}
