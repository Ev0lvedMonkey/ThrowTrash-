using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ShotTrajectory : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private BallGrounded _ballGrounded;
    [SerializeField, Range(9, 15)] private float _maxDistance;

    private const int pointsCount = 12;
    private const float groundLevel = -5f;

    private void OnValidate()
    {
        if (_lineRenderer == null)
            _lineRenderer = GetComponent<LineRenderer>();
        if (_ballGrounded == null)
            _ballGrounded = GetComponent<BallGrounded>();
    }

    public void TrajectoryEnable()
    {
        _lineRenderer.enabled = true;
    }

    private void Update()
    {
        //Debug.Log($"{_lineRenderer.enabled}");
    }

    public void TrajectoryDisable()
    {
        _lineRenderer.enabled = false;
    }

    public void Draw(Vector2 origin, Vector2 speed)
    {

        Vector3[] points = new Vector3[pointsCount];
        _lineRenderer.positionCount = points.Length;
        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.1f;

            points[i] = origin + speed * time + Physics2D.gravity * Mathf.Pow(time, 2) / 2f;

            if (points[i].y < groundLevel || Vector2.Distance(transform.position, points[i]) > _maxDistance)
            {
                _lineRenderer.positionCount = i + 1;
                break;
            }
        }
        _lineRenderer.SetPositions(points);
    }

    private void SetNewColor(Color newColor)
    {
        _lineRenderer.startColor = newColor;
        _lineRenderer.endColor = newColor;
    }
}
