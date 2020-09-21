using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : Base
{
    protected override void ShowItem()
    {
        yuanqu.SetActive(false);
        ui.CutUI(1);
        cameraEdit.SetObj(GameObject.Find("楼层").transform.GetChild(0).gameObject, 1);

    }

    public void Return()
    {
        yuanqu.SetActive(true);
        ui.CutUI(0);
        cameraEdit.SetObj(GameObject.Find("Object001"), 0);
    }

}
