
using UnityEngine;

public class CameraPCController : MonoBehaviour
{
    [SerializeField]private Vector2 rotationSpeed;
    [SerializeField]private float drag;
    private CameraMovement cameraMovement;
    private Vector2 speed;
    private void Awake()
    {
        cameraMovement = GetComponent<CameraMovement>();
    }
    private void Update()
    {
        cameraMovement.horizonalAngle+=speed.x*Time.deltaTime;
        cameraMovement.verticalAngle+=speed.y*Time.deltaTime;
        if(cameraMovement.verticalAngle<-10)cameraMovement.verticalAngle =-10;
        if(cameraMovement.verticalAngle>45)cameraMovement.verticalAngle =45;

        speed = Vector2.Lerp(speed,Vector2.zero , drag*Time.deltaTime);

        if(Input.GetKey("a"))
        {
            speed.x+=Time.deltaTime*rotationSpeed.x;
        }
        if(Input.GetKey("d"))
        {
            speed.x-=Time.deltaTime*rotationSpeed.x;
        }

        if(Input.GetKey("s"))
        {
            speed.y-=Time.deltaTime*rotationSpeed.y;
        }
        if(Input.GetKey("w"))
        {
            speed.y+=Time.deltaTime*rotationSpeed.y;
        }

        cameraMovement.UpdateRotation();
    }
}
