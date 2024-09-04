using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target; // �÷��̾��� Ʈ������
    [SerializeField] Vector3 offset;   // �÷��̾�� ī�޶� �󸶳� �ָ� ������ ���� ������
    [SerializeField] float rate;
    [SerializeField] float distance; // �ڷ����� �̰� �³�?

    [SerializeField] float mouseSensitvity; // ���콺 �ΰ���
    [SerializeField] float yAngle; // y�� ���� ȸ������
    [SerializeField] float xAngle; // x�� ���� ȸ�� ����

    private void LateUpdate()
    {
        Rotate(); Move();
    }

    // ī�޶� �÷��̾ ���� �ֺ��� �ѷ����� ���
    void Rotate()
    {
        // ���콺 ��Ŭ���� �ϰ� ���� ���� ��, �ƹ��ϵ� �Ͼ�� �ʰ� �ϴ� if��
        if (Input.GetMouseButton(1) == false) return;

        // ���콺 ��Ŭ�� �� ȸ���� �����ϰ� ���ִ� �ڵ� �ۼ�
        xAngle -= Input.GetAxis("Mouse Y") * mouseSensitvity;
        yAngle += Input.GetAxis("Mouse X") * mouseSensitvity;
    }

    // ī�޶� �÷��̾ ���� �����̴� ���
    void Move()
    {
        // ī�޶��� x, y�� ȸ������ �÷��̾��� ȸ������ �����ϰ� ����
        transform.rotation = Quaternion.Euler(xAngle, yAngle, 0);
        // ī�޶��� ��ġ ���� 
        transform.position = transform.position - transform.forward * distance;
        // distance ���� �ڷ������� ���f��

        // ��ȭ�ǽ� ���(�ۼ��� �ص�)
        transform.rotation = Quaternion.Euler(xAngle, yAngle, 0);
        if (Physics.Raycast(target.position, -transform.forward, out RaycastHit hitInfo, distance))
        {
            Vector3 position = hitInfo.point;
            transform.position = Vector3.Lerp(transform.position, position, rate * Time.deltaTime);
        }
    }
}
