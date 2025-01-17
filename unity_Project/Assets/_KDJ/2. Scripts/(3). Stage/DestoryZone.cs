﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryZone : MonoBehaviour
{
    //트리거 감지 후 해당 오브젝트 삭제
    private void OnTriggerEnter(Collider other)
    {
        //이곳에서 트리거에 감지된 오브젝트 제거하기 (총알, 에너미)
        //Destroy(other.gameObject);

        //if(other.gameObject.name.Contains("Bullet"))
        //{
        //    other.gameObject.SetActive(false);
        //}

        //레이어로 충돌체 찾기
        //if(other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        //{
        //    other.gameObject.SetActive(false);
        //    //플레이어 오브젝트의 플레이어파이어 컴포넌트의 리스트오브젝트풀 속성을 가져와서 추가해준다
        //    PlayerFire pf = GameObject.Find("Player").GetComponent<PlayerFire>();
        //    pf.bulletPool.Add(other.gameObject);
        //}

        //충돌된 오브젝트가 총알이라면 총알풀에 추가한다
        if (other.gameObject.name.Contains("Bullet"))
        {
            //총알 오브젝트는 비활성화 시킨다
            other.gameObject.SetActive(false);
            //오브젝트풀에 추가만 해준다
            PlayerFire pf = GameObject.Find("Player").GetComponent<PlayerFire>();
            pf.bulletPool.Enqueue(other.gameObject);
        }
    }
}
