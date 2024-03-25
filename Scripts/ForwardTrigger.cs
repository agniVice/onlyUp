using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardTrigger : MonoBehaviour
{
    private Vector3 point;
    public Vector3 point2;

    public Vector3 LastPoint { get; private set; }

    public bool LineCast(Vector3 startPoint, Vector3 endPoint, LayerMask layerMask, float lenght, Vector3 forward)
    {
        RaycastHit hit;
        Physics.Raycast(startPoint, forward, out hit, 1f, layerMask);

        if (hit.collider != null)
        {
            point = hit.point;

            RaycastHit hit2;
            Physics.Raycast(new Vector3(hit.point.x + forward.x * 0.02f, hit.point.y + 2f, hit.point.z + forward.z * 0.05f), -Vector3.up, out hit2, 3f, layerMask);
            if (hit2.collider != null)
            {
                point2 = hit2.point;
                LastPoint = point2;
                return true;
            }
            else
            {
                point2 = Vector3.zero;
                return false;
            }
        }
        else
        {
            point = Vector3.zero;
            point2 = Vector3.zero;
            return false;
        }

    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(point, 0.2f);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(point2, 0.2f);
    }
}
