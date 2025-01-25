using UnityEngine;

public class CameraPCController : MonoBehaviour
{
    [SerializeField]private Vector2 rotationSpeed;
    private CameraMovement cameraMovement;
    private void Awake()
    {
        cameraMovement = GetComponent<CameraMovement>();
    }
    private void Update()
    {
        if(Input.GetKey("a"))
        {
            cameraMovement.horizonalAngle+=Time.deltaTime*rotationSpeed.x;
        }
        if(Input.GetKey("d"))
        {
            cameraMovement.horizonalAngle-=Time.deltaTime*rotationSpeed.x;
        }

        if(Input.GetKey("s"))
        {
            cameraMovement.verticalAngle-=Time.deltaTime*rotationSpeed.x;
            if(cameraMovement.verticalAngle<10)cameraMovement.verticalAngle =10;
        }
        if(Input.GetKey("w"))
        {
            cameraMovement.verticalAngle+=Time.deltaTime*rotationSpeed.x;
            if(cameraMovement.verticalAngle>45)cameraMovement.verticalAngle =45;
        }
        cameraMovement.UpdateRotation();
    }
}
