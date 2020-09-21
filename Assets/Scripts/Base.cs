using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Base : MonoBehaviour
{
    private float _prevouseClick;
    protected CameraEdit cameraEdit;
    protected GameObject yuanqu;
    protected UI ui;

    // Use this for initialization
    void Start()
    {
        _prevouseClick = Time.realtimeSinceStartup;
        cameraEdit = Camera.main.GetComponent<CameraEdit>();
        yuanqu = GameObject.Find("yuanqu");
        ui = GameObject.Find("Canvas").GetComponent<UI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit) && hit.transform == transform)
            {
                if ((Time.realtimeSinceStartup - _prevouseClick) < 0.2f)
                {
                    //Debug.Log("双击");
                    ShowItem();
                }
                else
                {
                    _prevouseClick = Time.realtimeSinceStartup;
                }
            }
        }
    }


    protected abstract void ShowItem();
}
