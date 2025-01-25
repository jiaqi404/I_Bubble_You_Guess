using Unity.Cinemachine;
using UnityEngine;
using UnityEditor;

public class CameraMovement : MonoBehaviour
{
    [Header("get the component")]
    [SerializeField]private CinemachineOrbitalFollow cinemachineOrbitalFollow;
    [Header("testing component")]
    [Range(0,360)]
    public float horizonalAngle;
    [Range(10,45)]
    public float verticalAngle;
    public void UpdateRotation()
    {
        cinemachineOrbitalFollow.HorizontalAxis.Value = horizonalAngle;
        cinemachineOrbitalFollow.VerticalAxis.Value = verticalAngle;
    }
}

# if UNITY_EDITOR
[CustomEditor(typeof(CameraMovement))]
public class CameraMovementEditor: Editor
{
    CameraMovement cameraMovement ;
    private void OnEnable()
    {
        cameraMovement = (CameraMovement)target;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        cameraMovement.UpdateRotation();
    }
}
#endif