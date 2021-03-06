using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(LineRenderer))]

public class LaserRay : MonoBehaviour
{
    public int iLevelToLoad;
    public string sLevelToLoad;
    public bool useIntegerToLoadLevel = false;


    public int reflections;
    public float maxLength;

    private LineRenderer lineRenderer;
    private Ray ray;
    private RaycastHit hit;
    private Vector2 direction;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        ray = new Ray(transform.position, transform.right);
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
        float remainingLength = maxLength;

        for (int i = 0; i < reflections; i++)
        {
            if (Physics.Raycast(ray.origin, ray.direction, out hit, remainingLength))
            {
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);
                remainingLength -= Vector2.Distance(ray.origin, hit.point);
                ray = new Ray(hit.point, Vector2.Reflect(ray.direction, hit.normal));
                if (hit.collider.tag != "Mirror" && hit.collider.tag != "Sphere")
                {
                    break;
                }
                if (hit.collider.tag == "Sphere")
                {
                    LoadScene();
                }


            }
            else
            {
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, ray.origin + ray.direction * remainingLength);
            }

        }

        void LoadScene()
        {
            if (useIntegerToLoadLevel)
            {
                SceneManager.LoadScene(iLevelToLoad);
            }

            else
            {
                SceneManager.LoadScene(sLevelToLoad);
            }
        }
    }
}