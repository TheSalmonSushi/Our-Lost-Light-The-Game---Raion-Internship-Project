using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflective : MonoBehaviour
{
    // Start is called before the first frame update
    public int reflection;
    public float maxlenght;

    public LineRenderer lineRenderer;
    public Ray ray;
    public RaycastHit hit;
    public Vector3 direction;

    public void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    // Update is called once per frame
    public void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
        float remaininglenght = maxlenght;
        for (int i = 0; i < reflection; i++)
        {
            if (Physics.Raycast(ray.origin, ray.direction, out hit, remaininglenght))
            {
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);
                remaininglenght -= Vector3.Distance(ray.origin, hit.point);
                ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
                if (hit.collider.tag != "Mirror")
                    break;




            }
            else
            {
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, ray.origin + ray.direction * remaininglenght);
            }
        }
    }
}
