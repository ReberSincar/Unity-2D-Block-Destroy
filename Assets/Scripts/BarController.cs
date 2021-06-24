using UnityEngine;

public class BarController : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed;
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z;
        var newPos = new Vector3(mousePosition.x, gameObject.transform.position.y, mousePosition.z);
        newPos.x = Mathf.Clamp(newPos.x, -9.5f, 9.5f);
        transform.position = Vector3.MoveTowards(transform.position, newPos, moveSpeed * Time.deltaTime);
    }
}
