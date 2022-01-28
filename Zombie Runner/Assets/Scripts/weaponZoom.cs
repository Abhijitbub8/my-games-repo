using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class weaponZoom : MonoBehaviour
{
    [SerializeField] Camera FOV;
    [SerializeField] int zoomIN = 32;
    [SerializeField] int zoomOUT = 60;
    [SerializeField] float zoomOUTsensitivity = 2f;
    [SerializeField] float zoomINsensitivity = 0.2f;

    bool zoomIn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !zoomIn)
        {
            ZOOMIN();
        }
        else if (Input.GetMouseButtonDown(1) && zoomIn)
        {
            ZOOMOUT();
        }
    }

    private void ZOOMIN()
    {
        FOV.fieldOfView = zoomIN;
        GetComponent<RigidbodyFirstPersonController>().mouseLook.XSensitivity = zoomINsensitivity;
        GetComponent<RigidbodyFirstPersonController>().mouseLook.YSensitivity = zoomINsensitivity;
        zoomIn = true;
    }

    private void ZOOMOUT()
    {
        FOV.fieldOfView = zoomOUT;
        GetComponent<RigidbodyFirstPersonController>().mouseLook.XSensitivity = zoomOUTsensitivity;
        GetComponent<RigidbodyFirstPersonController>().mouseLook.YSensitivity = zoomOUTsensitivity;
        zoomIn = false;
    }
}
