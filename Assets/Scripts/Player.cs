using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;
    bool wDown;

    Vector3 moveVec;

    Animator anim;

    // ��ũ��Ʈ�� ����ɶ� �ѹ��� ȣ��, Start�Լ��� ȣ�ߵǱ� ���� 
    //ȣ��Ǹ� �ַ� ������ ���� �� �Ǵ� ������ �ʱ�ȭ�� ���, �ڷ�ƾ���� ����Ұ�

    void Awake()
    {
        //Animator ������ GetComponentInChildren()�� �ʱ�ȭ
        anim = GetComponentInChildren<Animator>();


    }

    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        // ���ο� input�� ���� Edit -> Setting -> inputManager���� Size�� �÷�
        // input�� �÷��ش�.

        // Shift�� �������� �۵��ǵ���GetButton()�Լ����
        wDown = Input.GetButton("Walk");


        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        // Transform�̵��� �� Time.delta.Time���� ��������Ѵ�.
        transform.position += moveVec * speed * (wDown ? 0.3f : 1f) * Time.deltaTime;

        transform.position += moveVec * speed * Time.deltaTime;

        //SetBool()�Լ��� �Ķ���� ���� ����
        anim.SetBool("isRun", moveVec != Vector3.zero);
        anim.SetBool("isWalk", wDown);

        // LookAt() ������ ���ͷ� ȸ�������ִ� �Լ�
        transform.LookAt(transform.position + moveVec);

    }
}
