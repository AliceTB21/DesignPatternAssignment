using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Vector3 cameraOffset;
    private Vector3 playerPos;
    PlayerMovement playerMovement;
    private void Start()
    {
        transform.position = Manager.Instance.GetPlayer.transform.position;
        
        playerMovement = Manager.Instance.GetPlayer.GetComponent<PlayerMovement>();

    }

    private void LateUpdate() // Gets the players position and sets the camera position
    {
        //playerPos = playerMovement.UpdatePos();
        playerPos = Manager.Instance.GetPlayer.transform.position;
        Vector3 cameraPos = new Vector3(playerPos.x - cameraOffset.x, playerPos.y + cameraOffset.y, playerPos.z - cameraOffset.z);

        transform.position = cameraPos;
    }
}
