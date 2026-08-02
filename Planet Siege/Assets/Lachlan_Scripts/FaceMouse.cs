using UnityEngine;

public class FaceMouse : MonoBehaviour
{
    private Vector3 mouseWorldPosition;
    private Vector2 faceDirection;

    void Update()
    {
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = transform.position.z;

        faceDirection = mouseWorldPosition - transform.position;
        transform.up = faceDirection;
    }
}