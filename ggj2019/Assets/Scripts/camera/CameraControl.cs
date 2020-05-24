using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float smoothTime = 0.2f;
    public float m_ScreenEdgeBuffer = 4f;
    public GameObject[] m_Targets;

    //Zooming
    private float zoomMax = 3.5f;
    private float zoomMin = 2f;
    private float relativeZoomDistance = 5f;

    private Camera m_Camera;
    private float m_ZoomSpeed;
    private Vector3 m_MoveVelocity;


    private void Awake()
    {
        m_Camera = GetComponent<Camera>();
        m_Targets = GameObject.FindGameObjectsWithTag("Players");
    }

    private void Update()
    {
        Move();
        Zoom();
    }

    private void Move()
    {
        transform.position = Vector3.SmoothDamp(transform.position, FindAveragePosition(), ref m_MoveVelocity, smoothTime);
    }


    private Vector3 FindAveragePosition()
    {
        Vector3 averagePos = new Vector3();
        int numTargets = 0;

        for (int i = 0; i < m_Targets.Length; i++)
        {
            if (!m_Targets[i].gameObject.activeSelf)
                continue;

            averagePos += m_Targets[i].transform.position;
            numTargets++;
        }

        if (numTargets > 0)
            averagePos /= numTargets;

        averagePos.y = transform.position.y;

        return averagePos;
    }


    private void Zoom()
    {
        m_Camera.orthographicSize = Mathf.SmoothDamp(m_Camera.orthographicSize, FindRequiredSize(), ref m_ZoomSpeed, smoothTime);
    }


    private float FindRequiredSize()
    {
        float size = 0f;

        float VertexX = m_Targets[0].transform.position.x;
        float VertexZ = m_Targets[0].transform.position.z;
        float PolyX = m_Targets[1].transform.position.x;
        float PolyZ = m_Targets[1].transform.position.z;

        float distanceBetweenPlayers = Mathf.Sqrt(Mathf.Pow(VertexX - PolyX, 2) + Mathf.Pow(VertexZ - PolyZ, 2));

        size += distanceBetweenPlayers / relativeZoomDistance;

        size = Mathf.Max(size, zoomMin);

        if (size >= zoomMax)
        {
            return zoomMax;
        }
        else 
        {
            return size;
        }  
    }


    public void SetStartPositionAndSize()
    {
        transform.position = FindAveragePosition();

        m_Camera.orthographicSize = FindRequiredSize();
    }
}