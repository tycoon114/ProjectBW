using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 lookPosition; // 보는 위치
    public Vector3 CameraOffset = new Vector3(0f, 0.5f, -4.0f);     //카메라 오프셋

    private float pitch = 0f;                                       //위아래 회전
    private float yaw = 0f;                                         //좌우 회전
    private float defaultFov = 40f;                                 //기본 시야각
    private float zoomFov = 20f;                                    //줌 시야각
    public float zoomSpeed = 5.0f;                                  //확대축소가 되는 속도
    public float mouseSensitivity = 60.0f;                          //감도
   
    private GameObject PlayerGo;                                    //플레이어 빈 게임 오브젝트
    public Transform Player;                                        //플레이어의 위치, 캐릭터 프리펩

    private void Start()
    {

    }



    void Update()
    {
        var players = GameObject.FindGameObjectsWithTag("Player");

    }


     void LateUpdate()
    {
        if (Player == null) return;
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yaw += mouseX;
        pitch += mouseY;
        //위 아래 각도 제한
        pitch = Mathf.Clamp(pitch, -45f, 10f);

        //시네머신의 screen Position처럼 화면을 돌림
        Quaternion cameraRotation = Quaternion.Euler(-pitch, yaw, 0);
        Vector3 basePosition = Player.position + cameraRotation * CameraOffset;



        transform.position = basePosition;

        Vector3 offset = cameraRotation * new Vector3(0.6f, 0f, 0f);
        lookPosition = Player.position + new Vector3(0, CameraOffset.y, 0) + offset;

        transform.LookAt(lookPosition);

    }

}
