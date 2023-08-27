using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
public class Controller : MonoBehaviour
{
    public GameObject teleportationPlane;
    public GameObject mainCamera;
    public GameObject teleportCamera;
    public GameObject instructionsPanel;
    public static bool isTeleport = false;
    bool isTalking = false;
    public static DialogTrigger mainTrigger;
    public static DialogTrigger secondTrigger;
    GameObject mainPlayer;
    GameObject secondPlayer;
    

    void Start()
    {
        SetCursorState(true);
        mainPlayer = GameObject.FindWithTag("Player");
        secondPlayer = GameObject.FindWithTag("SecondPlayer");
        mainTrigger = mainPlayer.GetComponent<DialogTrigger>();
        secondTrigger = secondPlayer.GetComponent<DialogTrigger>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            instructionsPanel.SetActive(false);
        if (Input.GetKeyDown(KeyCode.H))
            instructionsPanel.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
        if(Input.GetKeyDown(KeyCode.T))
        {
            if (isTeleport)
            {
                teleportCamera.SetActive(false);
                teleportationPlane.SetActive(false);
                mainCamera.GetComponent<Camera>().enabled = true;
                SetCursorState(true);
                isTeleport = false;

            }
            else
            {
                SetCursorState(false);
                mainCamera.GetComponent<Camera>().enabled = false;
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
    public void SetCursorState(bool value)
    {
        if(value)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.Confined;

    }
}
