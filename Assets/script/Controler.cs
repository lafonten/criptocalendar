using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler : MonoBehaviour
{
    public bool OnLeft;
    public bool OnRight;

    public static Controler instance;

    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Checker(transform.position);
    }

    void Checker(Vector3 position)
    {
        RaycastHit hit;

        Vector3 originLeft = new Vector3(position.x + 0.5f, position.y + 2f, position.z-0.52f);
        Vector3 originRight = new Vector3(position.x - 0.5f, position.y + 2f, position.z-0.52f);



        Ray rayLeft = new Ray(originLeft, Vector3.down);
        Ray rayRight = new Ray(originRight, Vector3.down);


        if (Physics.Raycast(rayRight, out hit, 3.5f))
        {
            OnRight = true;
        }
        else
        {
            OnRight = false;
        }

        if (Physics.Raycast(rayLeft, out hit, 3.5f))
        {
            OnLeft = true;
        }
        else
        {
            OnLeft = false;
        }

        Debug.DrawRay(originLeft, Vector3.down, Color.red);

        Debug.DrawRay(originRight, Vector3.down, Color.green);
    }
}
