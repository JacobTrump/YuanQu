using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEdit : MonoBehaviour
{
    private GameObject itemObj;
    public GameObject objective;
    private float radius;//当前视距
    private float radiusTemp;
    private bool isWait = true;

    private float[] radiusConfig = { 500f, 100f, 80f, 80f };
    private float[] tempRadiusConfig = { 200f, 50f, 10f, 10f };
    private Vector3[] psConfig = new Vector3[] { new Vector3(133.5f, 78.4f, 174.4f), new Vector3(33.0f, 18.5f, 36.3f), new Vector3(5.4f, 3.3f, 7.7f), new Vector3(5.7f, 2.52f, 7.8f) };
    private Vector3 ps;
    private int configIndex = 0;

    private float speed = 0.8f;
    private float deltaTime;



    private float ScrollWheelValue
    {
        get
        {
            return Input.GetAxis("Mouse ScrollWheel");
        }
    }

    public int ConfigIndex { get => configIndex; }

    private void Awake()
    {
        itemObj = new GameObject("item");
        //itemObj.transform.position = transform.position;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isWait)
        {
            CheckRotate();
            CheckRadius();
            SetTransNormal();
        }
        else OnSceneChange();
    }

    float touchTimer;
    private void CheckRotate()
    {
        if (Input.GetMouseButton(0))
        {
            itemObj.transform.position = transform.position;
            itemObj.transform.eulerAngles = transform.eulerAngles;

            itemObj.transform.RotateAround(objective.transform.position, this.transform.right, -Input.GetAxis("Mouse Y") * 2);
            itemObj.transform.RotateAround(objective.transform.position, Vector3.up, Input.GetAxis("Mouse X") * 2);

            if (itemObj.transform.position.y < 0) return;

            transform.position = itemObj.transform.position;
            transform.eulerAngles = itemObj.transform.eulerAngles;
        }
    }

    private void CheckRadius()
    {
        if (ScrollWheelValue != 0) AddRadius(-ScrollWheelValue * 50);
    }

    private void SetTransNormal()
    {
        if (radius == 0) return;
        //Debug.Log("radius: " + radius);
        Vector3 newpos = objective.transform.position;
        //Debug.Log("newpos: " + newpos);
        newpos += (transform.position - objective.transform.position).normalized * radius;
        //Debug.Log("newpos: " + newpos);
        transform.position = newpos;
    }


    private void AddRadius(float value)
    {
        radius -= value;
        float tempRadius = tempRadiusConfig[configIndex];

        if (radius <= tempRadius) radius = tempRadius;

        if (radius >= radiusConfig[configIndex])
            radius = radiusConfig[configIndex];
        radiusTemp = radius;
    }

    public void SetObj(GameObject obj, int i)
    {
        objective = obj;
        configIndex = i;
        ps = obj.transform.position + psConfig[i];
        isWait = false;
    }

    private void OnSceneChange()
    {
        //转视角
        deltaTime += Time.deltaTime * speed;
        if (deltaTime > 1) deltaTime = 1;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(20.5f, 217.1f, 0)), deltaTime);
        transform.position = Vector3.Lerp(transform.position, ps, deltaTime);

        //当摄影机移动完毕则重新设置 nowStatus
        if (deltaTime == 1)
        {
            deltaTime = 0;
            radius = 0;
            isWait = true;
        }
    }
}
