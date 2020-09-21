using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnButton : MonoBehaviour
{
    private CameraEdit cameraEdit;

    private Floor floor;
    private Equipment1 equipment1;
    private Equipment2 equipment2;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraEdit = Camera.main.GetComponent<CameraEdit>();

        floor = GameObject.Find("Object001").GetComponent<Floor>();
        equipment1 = GameObject.Find("楼层").transform.GetChild(1).GetComponent<Equipment1>();
        equipment2 = GameObject.Find("楼层").transform.GetChild(2).GetComponent<Equipment2>();
        
        transform.GetComponent<Button>().onClick.AddListener(Return);

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Return()
    {
        Debug.Log("返回");
        int i = cameraEdit.ConfigIndex;
        switch (i)
        {
            case 0:
                break;
            case 1:
                floor.Return();
                break;
            case 2:
                equipment1.Return();
                break;
            case 3:
                equipment2.Return();
                break;
        }
    }
}
