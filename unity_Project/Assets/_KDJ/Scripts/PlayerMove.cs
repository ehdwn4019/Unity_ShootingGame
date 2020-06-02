﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //플레이어 이동
    public float speed = 5.0f; //플레이어 이동 속도
    public Vector2 margin;    //뷰포트좌표는 0,0f ~ 1.0f 사이의 값 

    //[SerializeField]
    //Camera cam;

    //Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        //pos = transform.position;
        // cam = GetComponent<Camera>();

        //pos = cam.WorldToViewportPoint(this.transform.position);
        margin = new Vector2(0.08f, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {

        Move();

       

        
        //if (pos.x < 0f) pos.x = 0f;
        //if (pos.x > 1f) pos.x = 1f;
        //if (pos.y < 0f) pos.y = 0f;
        //if (pos.y > 1f) pos.y = 1f;
        //transform.position = cam.WorldToViewportPoint(pos);

       
    }

    //플레이어 이동
    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(h * speed * Time.deltaTime, v * speed * Time.deltaTime, 0);

        //if (transform.position.x <0f) pos.x = 0f;
        //if (transform.position.x >2.3f) pos.x = 2.3f;
        //if (transform.position.y <0f) pos.y = 0f;
        //if (transform.position.y >2.3f) pos.y = 2.3f;


        //Vector3 dir = Vector3.right * h + Vector3.up * v;
        //Vector3 dir = new Vector3(h, v, 0);
        //transform.Translate(dir * speed * Time.deltaTime);

        //위치=현재위치 + (방향*시간)
        //p=p0+vt;
        //transform.position = transform.position+(dir*speed*Time.deltaTime);
        //transform.position += dir * speed * Time.deltaTime;

        //플레이어가 화면 밖으로 이동 못하게 만들기
        MoveInScreen();

    }

    private void MoveInScreen()
    {
        //position.x = 10;
        //transform.position = position;


        //방법은 크게 3가지
        //첫번째 : 화면밖의 공간에 큐브 4개 만들어서 배치
        //리지드바디의 충돌체로 이동 못하게 막기

        //두번째 : 플레이어의 포지션으로 이동처리
        //캐스팅 : 아래와 같이 transform.position의 값을 Vector3에 담아서 값을 계산 후 
        //다시 대입시키는 과정을 캐스팅이라고 한다. 
        //Vector3 position = transform.position;
        //position.x = Mathf.Clamp(position.x, -2.5f,2.5f);
        //position.y = Mathf.Clamp(position.y, -3.5f, 5.5f);
        //transform.position = position;

        //세번째 : 메인카메라의 뷰포트를 가져와서 처리한다(우린 이걸 사용한다)
        //스크린좌표 : 왼쪽하단(0,0) , 우측상단(maxX,maxY)
        //뷰포트좌표 : 왼쪽하단(0,0) , 우측상단(1.0f,1.0f)
        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);
        position.x = Mathf.Clamp(position.x, -0.0f+margin.x, 1.0f-margin.x);
        position.y = Mathf.Clamp(position.y, -0.0f+margin.y, 1.0f-margin.y);

        transform.position = Camera.main.ViewportToWorldPoint(position);

    }   


}