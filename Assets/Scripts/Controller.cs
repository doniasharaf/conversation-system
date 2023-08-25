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
    public StarterAssetsInputs starterAssetsInputs;
   
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
