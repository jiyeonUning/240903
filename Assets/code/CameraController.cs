using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target; // 플레이어의 트랜스폼
    [SerializeField] Vector3 offset;   // 플레이어와 카메라가 얼마나 멀리 떨어져 있을 것인지
    [SerializeField] float rate;
    [SerializeField] float distance; // 자료형이 이게 맞나?

    [SerializeField] float mouseSensitvity; // 마우스 민감도
    [SerializeField] float yAngle; // y축 방향 회전각도
    [SerializeField] float xAngle; // x축 방향 회전 각도

    private void LateUpdate()
    {
        Rotate(); Move();
    }

    // 카메라가 플레이어를 따라서 주변을 둘러보는 기능
    void Rotate()
    {
        // 마우스 우클릭을 하고 있지 않을 시, 아무일도 일어나지 않게 하는 if문
        if (Input.GetMouseButton(1) == false) return;

        // 마우스 우클릭 시 회전이 가능하게 해주는 코드 작성
        xAngle -= Input.GetAxis("Mouse Y") * mouseSensitvity;
        yAngle += Input.GetAxis("Mouse X") * mouseSensitvity;
    }

    // 카메라가 플레이어를 따라서 움직이는 기능
    void Move()
    {
        // 카메라의 x, y축 회전값을 플레이어의 회전값과 동일하게 해줌
        transform.rotation = Quaternion.Euler(xAngle, yAngle, 0);
        // 카메라의 위치 설정 
        transform.position = transform.position - transform.forward * distance;
        // distance 무슨 자료형인지 못봣음

        // 심화실습 기능(작성만 해둠)
        transform.rotation = Quaternion.Euler(xAngle, yAngle, 0);
        if (Physics.Raycast(target.position, -transform.forward, out RaycastHit hitInfo, distance))
        {
            Vector3 position = hitInfo.point;
            transform.position = Vector3.Lerp(transform.position, position, rate * Time.deltaTime);
        }
    }
}
