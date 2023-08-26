using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
public class Controller : MonoBehaviour
{
    public GameObject teleportationPlane;
    public GameObject mainCamera;
    public GameObject teleportCamera;
    public static bool isTeleport = false;
    bool isTalking = false;
    public static DialogTrigger mainTrigger;
    public static DialogTrigger secondTrigger;
    

    void Start()
    {
        mainTrigger = GameObject.FindWithTag("Player").GetComponent<DialogTrigger>();
        secondTrigger = GameObject.FindWithTag("SecondPlayer").GetComponent<DialogTrigger>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            if (isTeleport)
            {
                teleportCamera.SetActive(false);
                teleportationPlane.SetActive(false);
                mainCamera.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;

                isTeleport = false;

            }
            else
            {
                Cursor.lockState = CursorLockMode.Confined;
                mainCamera.SetActive(false);
                teleportationPlane.SetActive(true);
                teleportCamera.SetActive(true);
                isTeleport = true;
            }
        }
        if (!isTalking && Input.GetKeyDown(KeyCode.G))
        {
            isTalking = true;
            secondTrigger.triggerDialog();
        }
    }
}
