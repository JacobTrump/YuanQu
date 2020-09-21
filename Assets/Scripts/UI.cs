using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    private List<GameObject> ui = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        ui.Add(transform.GetChild(0).gameObject);
        ui.Add(transform.GetChild(1).gameObject);
        ui.Add(transform.GetChild(2).gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HideAll()
    {
        foreach(GameObject uiItem in ui)
        {
            uiItem.SetActive(false);
        }
    }

    public void CutUI(int index)
    {
        HideAll();
        switch (index)
        {
            case 0:
                ui[1].SetActive(true);
                break;
            case 1:
                ui[0].SetActive(true);
                ui[2].SetActive(true);
                break;
            case 2:
                ui[0].SetActive(true);
                break;
            case 3:
                ui[0].SetActive(true);
                break;
            default:
                return;
        }
    }
}
