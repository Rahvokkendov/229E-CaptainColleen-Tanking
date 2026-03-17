using UnityEngine;
using UnityEngine.InputSystem;
public class CameraFollower : MonoBehaviour
{
    public Transform playerTank;
    public float smoothSpeed = 0.25f;
    public float mouseInfluence = 0.2f;
    public Vector3 offset;

    private Plane groundPlane;

    private void Start()
    {
        groundPlane = new Plane(Vector3.up, playerTank.position);
    }


    private void LateUpdate()
    {
        groundPlane.SetNormalAndPosition(Vector3.up, playerTank.position);

        Vector3 targetPos = playerTank.position;

        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (groundPlane.Raycast(ray, out float distance))
        {
            Vector3 mousePoint = ray.GetPoint(distance);
            targetPos = Vector3.Lerp(playerTank.position, mousePoint, mouseInfluence);
        }

        targetPos += offset;

        transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed * Time.time);

    }

}
