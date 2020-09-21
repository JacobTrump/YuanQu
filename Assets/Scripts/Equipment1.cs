using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment1 : Base
{
    protected override void ShowItem()
    {
        GameObject.Find("楼层").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("楼层").transform.GetChild(2).gameObject.SetActive(false);
        ui.CutUI(2);
        cameraEdit.SetObj(GameObject.Find("楼层").transform.GetChild(1).gameObject, 2);
    }

    public void Return()
    {
        GameObject.Find("楼层").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Find("楼层").transform.GetChild(2).gameObject.SetActive(true);
        ui.CutUI(1);
        cameraEdit.SetObj(GameObject.Find("楼层").transform.GetChild(0).gameObject, 1);
    }
}
