using Unity.Netcode;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;                        //이동 속도

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //넷코드 활성화 시
        //if (!IsOwner) return;

        MoveMent();
    }

    public void MoveMent()
    {
       //키 입력 받기
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // 이동 벡터 설정
        Vector3 move = new Vector3(horizontal, 0, vertical).normalized;

        transform.position += move * moveSpeed * Time.deltaTime;

    }

}
