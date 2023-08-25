using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teleport : MonoBehaviour
{
    Camera teleportationCamera;
    GameObject secondPlayer;
    NavMeshAgent secondAgent;
    // Start is called before the first frame update
    void Start()
    {
        secondPlayer = GameObject.FindWithTag("SecondPlayer");
        secondAgent = secondPlayer.GetComponent<NavMeshAgent>();
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
        if (Controller.isTeleport && gameObject.tag == "TeleportPoint")
        {
            secondAgent.destination = gameObject.transform.position;
            //secondPlayer.transform.position = new Vector3(gameObject.transform.position.x, secondPlayer.transform.position.y, gameObject.transform.position.z);
        }
    }
}
