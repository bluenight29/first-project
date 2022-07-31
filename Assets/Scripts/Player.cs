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

    // 스크립트가 실행될때 한번마 호출, Start함수가 호추되기 전에 
    //호출되며 주로 게임의 상태 값 또는 변수의 초기화에 사용, 코루틴으로 실행불가

    void Awake()
    {
        //Animator 변수를 GetComponentInChildren()로 초기화
        anim = GetComponentInChildren<Animator>();


    }

    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        // 새로운 input을 위해 Edit -> Setting -> inputManager에서 Size를 늘려
        // input을 늘려준다.

        // Shift를 누를때만 작동되도록GetButton()함수사용
        wDown = Input.GetButton("Walk");


        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        // Transform이동은 꼭 Time.delta.Time까지 곱해줘야한다.
        transform.position += moveVec * speed * (wDown ? 0.3f : 1f) * Time.deltaTime;

        transform.position += moveVec * speed * Time.deltaTime;

        //SetBool()함수로 파라메터 값을 설정
        anim.SetBool("isRun", moveVec != Vector3.zero);
        anim.SetBool("isWalk", wDown);

        // LookAt() 지정된 벡터로 회전시켜주는 함수
        transform.LookAt(transform.position + moveVec);

    }
}
