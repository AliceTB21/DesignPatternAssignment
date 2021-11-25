using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    private float x, z;
    Vector3 moveDir;

    [Header("LookAt")]
    [SerializeField] private Camera cameraRef;
    [SerializeField] private LayerMask groundLayer;
    private Vector3 lookPoint;

    public delegate void OnMovementUpdate();
    public static event OnMovementUpdate movementUpdate;


    private void Start()
    {
        cameraRef = Camera.main;
    }

    public Vector3 UpdatePos()
    {
        return new Vector3(x, 0, z);
    }

    private void Update()
    {
        HandleMovement();

        Ray ray = cameraRef.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, groundLayer))
        {
            lookPoint = hit.point;
        }
        else
        {
            //Make script remember last pos
        }

        lookPoint.y = 0;
        

        transform.LookAt(lookPoint, Vector3.up);


    }

    private void HandleMovement()
    {
        z = Input.GetAxisRaw("Vertical");
        x = Input.GetAxisRaw("Horizontal");

        moveDir = transform.position += new Vector3(x, 0, z) * movementSpeed * Time.deltaTime;
        moveDir.Normalize();
    }
}
