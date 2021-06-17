using System;
using UnityEngine;


public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    public cubeState CubeState = cubeState.freeMove;
    public GameObject Calendar;

    private void Update()
    {
        Rotate();
        SetParent();
    }

    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        mOffset = gameObject.transform.position - GetMouseWorldPos();

        //Debug.Log("Down");
        
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        if (CubeState == cubeState.freeMove)
        {
            transform.position = GetMouseWorldPos() + mOffset;
            //Debug.Log("Drag");
        }

        if (CubeState == cubeState.determinateMove)
        {
            transform.position =
                new Vector3(transform.position.x, GetMouseWorldPos().y + mOffset.y, transform.position.z);
        }
    }

    public void Rotate()
    {
        if (Controler.instance.OnLeft == false || Controler.instance.OnRight == false)
        {
            if (Input.GetMouseButtonDown(1))
            {
                gameObject.transform.Rotate(0, 0, 180);
            }
        }
    }

    void SetParent()
    {
        if (Controler.instance.OnLeft == true && Controler.instance.OnRight == true)
        {
            transform.SetParent(Calendar.transform);
            CubeState = cubeState.determinateMove;
        }

        if (Controler.instance.OnLeft == false || Controler.instance.OnRight == false)
        {
            transform.SetParent(null);
            CubeState = cubeState.freeMove;
        }
    }

}

public enum cubeState
{
    freeMove,
    determinateMove,
}
