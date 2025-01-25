using UnityEngine;

public class BubbleSpawnPC : MonoBehaviour
{
    [SerializeField]private GameObject bubble;
    private GameObject tempSpawn;
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray);
        System.Array.Reverse(hits);
        bool canBuild =false;
        foreach(RaycastHit hit in hits)
        {
            if(hit.transform.TryGetComponent<CanBuildOnThis>(out CanBuildOnThis temp))
            {
                Vector3 hitNormal = hit.normal;
                if(tempSpawn == null)
                {
                    tempSpawn = Instantiate(bubble, hit.point, Quaternion.LookRotation(hitNormal));
                }
                else
                {
                    tempSpawn.transform.position = hit.point;
                    tempSpawn.transform.rotation =Quaternion.LookRotation(hitNormal);
                }
                canBuild = true;
                break;
            }
        }
        if(!canBuild)
        {
            if(tempSpawn!=null)Destroy(tempSpawn);
        }

        if(Input.GetMouseButtonDown(0) && tempSpawn!= null)
        {
            tempSpawn.AddComponent(typeof(CanBuildOnThis));
            tempSpawn =null;
        }
    }
}
