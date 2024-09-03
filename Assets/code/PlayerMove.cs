using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(x, 0, z);
        if (dir == Vector3.zero) return;

        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.LookRotation(dir);
    }
}
