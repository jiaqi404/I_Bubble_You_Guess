using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBound : MonoBehaviour
{
    [Tooltip(" the Bound set is in the local space")]
    [SerializeField]private Vector3 adjustedBound;
    private void Start()
    {
        Renderer r = GetComponent<Renderer>();
        Bounds newBound = new Bounds(transform.position , adjustedBound);
        r.bounds= newBound;
    }
    #if UNITY_EDITOR
    public void OnDrawGizmosSelected()
    {
        var r = GetComponent<Renderer>();
        if (r == null)
            return;
        Bounds newBound = new Bounds(transform.position , adjustedBound);
        r.bounds= newBound;
        var bounds = r.bounds;
        Gizmos.matrix = Matrix4x4.identity;
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(bounds.center, bounds.extents * 2);
    }
    # endif 
}
