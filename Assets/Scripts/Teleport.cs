using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    Camera teleportationCamera;
    GameObject secondPlayer;
    // Start is called before the first frame update
    void Start()
    {
        secondPlayer = GameObject.FindWithTag("SecondPlayer");
        teleportationCamera = GameObject.FindWithTag("TeleportCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse clicked");
            RaycastHit raycastHit;
            Ray ray = teleportationCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 500f))
            {
                if (raycastHit.transform != null)
                {
                    Debug.Log("clicked object " + raycastHit.transform.gameObject);
                    onPointClicked(raycastHit.transform.gameObject);
                }
            }
        }
    }

    public void onPointClicked(GameObject gameObject)
    {
        if (gameObject.tag == "TeleportPoint")
        {
            secondPlayer.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        }
    }
}
