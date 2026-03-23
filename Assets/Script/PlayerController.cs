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
        //테스트 용으로 update에 작성 -> 이후 함수로 만들 것
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // 이동 벡터 설정
        Vector3 move = new Vector3(horizontal, 0, vertical).normalized;

        transform.position += move * moveSpeed * Time.deltaTime;

    }
}
