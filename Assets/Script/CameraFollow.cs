using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 0.125f;
    public Vector3 offset;
    [Header("Camera bounds")]
    public Vector3 minCamerabounds;
    public Vector3 maxCamerabounds;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.localPosition + offset;
        var localPosition = transform.localPosition;
        Vector3 smoothPosition = Vector3.Lerp(localPosition, desiredPosition, smoothSpeed);
        localPosition = smoothPosition;

        localPosition = new Vector3(
            Mathf.Clamp(localPosition.x, minCamerabounds.x, maxCamerabounds.x),
            Mathf.Clamp(localPosition.y, minCamerabounds.y, maxCamerabounds.x),
            Mathf.Clamp(localPosition.z, minCamerabounds.z, maxCamerabounds.z)
            );
        transform.localPosition = localPosition;
    }

    public void SetTarget(Transform targetToSet)
    {
        target = targetToSet;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
