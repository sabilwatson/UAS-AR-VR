using UnityEngine;

public class CameraFrustumCulling : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Plane[] frustumPlanes = GeometryUtility.CalculateFrustumPlanes(mainCamera);

        // Iterate through your objects that you want to check for culling
        GameObject[] objectsToCull = GameObject.FindGameObjectsWithTag("Cullable");

        foreach (GameObject obj in objectsToCull)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                // Check if the object is outside the camera's frustum
                if (!GeometryUtility.TestPlanesAABB(frustumPlanes, renderer.bounds))
                {
                    // If outside the frustum, disable rendering
                    renderer.enabled = false;
                }
                else
                {
                    // If inside the frustum, enable rendering
                    renderer.enabled = true;
                }
            }
        }
    }
}
