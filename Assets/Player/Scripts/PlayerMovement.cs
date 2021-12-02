using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private CharacterController controller;
    private float x, z;
    Vector3 moveDir;

    [Header("LookAt")]
    [SerializeField] private Camera cameraRef;
    [SerializeField] private LayerMask groundLayer;
    private Vector3 lookPoint;

    public delegate void OnMovementUpdate();
    public static event OnMovementUpdate movementUpdate;

    public Vector3 GetDirection { get { return lookPoint; }}


    private void Start()
    {
        if(cameraRef == null)
        cameraRef = Camera.main;
        if (controller == null)
            controller = GetComponent<CharacterController>();
    }

    public Vector3 UpdatePos()
    {
        return new Vector3(x, 0, z);
    }

    private void Update()
    {
        HandleMovement();

        LookAt();

    }

    private void LookAt()
    {
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
        moveDir.Normalize();
        moveDir = new Vector3(x, 0, z) * movementSpeed * Time.deltaTime;

        controller.Move(moveDir);
        //transform.position += moveDir;

    }
}
