
using UnityEngine;
using DG.Tweening;

public class BubbleSpawnPC : MonoBehaviour
{
    [SerializeField]private Material BubbleMaterial;
    [SerializeField]private Material BubbleDestroyMaterial;
    [SerializeField]private GameObject bubble;
    [SerializeField]private float minSize;
    [SerializeField]private float maxSize;
    [SerializeField]private float sizeSpeed;
    private GameObject tempSpawn;
    private Vector3 initSize = Vector3.one;
    private bool buildMode =true;
    private void Update()
    {
        if(buildMode)BuildModeUpdate();
        else DestroyModeUpdate();
    }
    private void BuildModeUpdate()
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
                    tempSpawn.transform.localScale =initSize;
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
            initSize = tempSpawn.transform.localScale;

            GameObject newBubble = Instantiate(tempSpawn , tempSpawn.transform.position ,tempSpawn.transform.rotation);
            Vector3 targetScale = newBubble.transform.localScale;
            newBubble.transform.localScale= Vector3.zero;
            newBubble.transform.DOScale(targetScale , 1f).SetEase(Ease.OutBounce);

            newBubble.AddComponent(typeof(CanBuildOnThis));
        }

        if(tempSpawn!=null)
        {
            tempSpawn.transform.localScale+=Vector3.one *Input.mouseScrollDelta.y*sizeSpeed;
            if(tempSpawn.transform.localScale.x>maxSize)tempSpawn.transform.localScale = new Vector3(maxSize,maxSize,maxSize);
            if(tempSpawn.transform.localScale.x<minSize)tempSpawn.transform.localScale = new Vector3(minSize,minSize,minSize);
        }

        if(Input.GetMouseButtonDown(1))
        {
            if(tempSpawn!=null)Destroy(tempSpawn);
            buildMode=false;
        }
    }
    private void DestroyModeUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray);
        System.Array.Reverse(hits);

        foreach(RaycastHit hit in hits)
        {
            if(hit.transform.tag=="Bubble")
            {   
                if(tempSpawn!=hit.transform.gameObject)
                {
                    if(tempSpawn!=null)tempSpawn.transform.GetComponent<MeshRenderer>().material =BubbleMaterial;
                    tempSpawn =hit.transform.gameObject;
                    hit.transform.GetComponent<MeshRenderer>().material =BubbleDestroyMaterial;
                }
                break;
            }
        }
        if(Input.GetMouseButtonDown(0) && tempSpawn!= null)
        {

            tempSpawn.transform.DOScale(Vector3.zero , .5f).SetEase(Ease.OutSine)
            .OnComplete(()=>Destroy(tempSpawn));
            tempSpawn =null;
        }

        if(Input.GetMouseButtonDown(1))
        {
            if(tempSpawn!=null)tempSpawn.transform.GetComponent<MeshRenderer>().material =BubbleMaterial;

            tempSpawn=null;
            buildMode=true;
        }
    }
}
