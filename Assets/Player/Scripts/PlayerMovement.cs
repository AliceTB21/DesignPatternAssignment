using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private float x, z;
    Vector3 moveDir;

    public delegate void OnMovementUpdate();
    public static event OnMovementUpdate movementUpdate;

    public Vector3 UpdatePos()
    {
        return new Vector3(x, 0, z);
    }

    private void Update()
    {
        z = Input.GetAxisRaw("Vertical");
        x = Input.GetAxisRaw("Horizontal");

        moveDir = transform.position += new Vector3(x, 0, z) * movementSpeed * Time.deltaTime;
        moveDir.Normalize();

        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.z);
        transform.LookAt(mousePos);
    }
}
