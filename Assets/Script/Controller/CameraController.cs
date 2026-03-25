using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 lookPosition; // 보는 위치

    private float pitch = 0f;                                       //위아래 회전
    private float yaw = 0f;                                         //좌우 회전
    private float defaultFov = 40f;                                 //기본 시야각
    private float zoomFov = 20f;                                    //줌 시야각
    public float zoomSpeed = 5.0f;                                  //확대축소가 되는 속도
    public float mouseSensitivity = 60.0f;                          //감도



   
    void Update()
    {
        
    }

    
    private void LateUpdate()
    {
        
    }

}
