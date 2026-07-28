using UnityEngine;

public class FaceMouse : MonoBehaviour
{
    void Update()
    {
        /*

        // Get the mouse position in world space
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // Get the direction from the object to the mouse
        Vector3 direction = mousePos - transform.position;

        // Calculate angle and rotate
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        */

        // 1. Get the mouse position in world space coordinates
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 2. Force the Z-plane to match the object's Z position to prevent 3D tilting
        mouseWorldPosition.z = transform.position.z;

        // 3. Calculate the direction vector from the object to the mouse
        Vector2 faceDirection = mouseWorldPosition - transform.position;

        // 4. Directly assign the up vector to look along this direction
        transform.up = faceDirection;
    }
}