using Unity.Android.Gradle.Manifest;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;

public class PlayerController : MonoBehaviour
{
    protected Animator animator;

    public float moveSpeed = 5f;                        //이동 속도
    private CharacterController controller;             //캐릭터 컨트롤러 ->씬 내에서 플레이어 오브젝트의 자식 프리팹으로 올 캐릭터에 달려있다.
   //protected Animator animator;                          //애니메이터 역시   씬 내에서 플레이어 오브젝트의 자식 프리팹으로 올 캐릭터에 달려있다.

    private Vector3 moveDirection;                      //이동 방향
    private Vector3 cameraForward;                      //
    private Vector3 cameraRight;                        //

    public float gravity = 100.0f;                        //중력
    public float jumpForce = 50.0f;                     //점프 강도

    private bool isJump = false;
    private bool isMoving = false;

    void Start()
    {
        controller = GetComponentInChildren<CharacterController>();
        //애니메이터 작업은 아직 - 시작 후 주석 제거
        animator = GetComponentInChildren<Animator>();
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

        // 현재 카메라의 회전 값 가져오기
        cameraForward = Camera.main.transform.forward;
        cameraRight = Camera.main.transform.right;
        // Y축 방향 제거 (수직 이동 방지)
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        // 정규화 (길이를 1로 조정)
        cameraForward.Normalize();
        cameraRight.Normalize();

        //수평 이동 방향 계산 (임시 변수에 담기)
        Vector3 targetMove = (cameraForward * vertical + cameraRight * horizontal);
        if (targetMove.magnitude > 1f) targetMove.Normalize();

        //애니메이션 적용
        isMoving = move.magnitude > 0;
        animator.SetBool("isMoving", isMoving);

        // 중력 적용
        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpForce;
                isJump = true;
            }
            else 
            {
                moveDirection.y = -2f;
                isJump = false;
            }
        }
        else
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // 플레이어 회전
        if (targetMove.magnitude > 0.1f) // 움직임이 있을 때만 회전
        {
            // 이동할 방향을 쳐다보는 쿼터니언 생성
            Quaternion targetRotation = Quaternion.LookRotation(targetMove);

            // 부드럽게 회전 (속도 조절은 10f 부분 조정)
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        //수평 값은 새로 계산한 값으로, 수직 값(y)은 위에서 계산된 값 유지
        moveDirection.x = targetMove.x * moveSpeed;
        moveDirection.z = targetMove.z * moveSpeed;

        //이동
        controller.Move(moveDirection * Time.deltaTime);
    }

}
