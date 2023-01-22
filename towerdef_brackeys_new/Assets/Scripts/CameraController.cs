using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool DoMovement = true;
    public float PanSpeed = 30f;
    public float PanBoarderThickness = 10f;
    public float ScrollSpeed = 5f;
    public float minY = 10f;
    public float maxY= 90f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DoMovement = !DoMovement;
        }
        
        if (!DoMovement) return;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - PanBoarderThickness)
        {
            transform.Translate(Vector3.forward * PanSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= PanBoarderThickness)
        {
            transform.Translate(Vector3.back * PanSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - PanBoarderThickness)
        {
            transform.Translate(Vector3.right * PanSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= PanBoarderThickness)
        {
            transform.Translate(Vector3.left * PanSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * ScrollSpeed * Time.deltaTime;

        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
}
