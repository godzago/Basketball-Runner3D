using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] [Range(3, 30)]
    public int _lineSegmentCount = 20;

    private List<Vector3> _LinePoints = new List<Vector3>();

    #region Singleton

    public static DrawManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public void UpdateTrajectory(Vector3 forceVector, Rigidbody rigidbody, Vector3 startingPoint)
    {
        Vector3 velocity = (forceVector / rigidbody.mass) * Time.fixedDeltaTime;

        float FlighDuration = (2 * velocity.y) / Physics.gravity.y;

        float stepTime = FlighDuration / _lineSegmentCount;

        _LinePoints.Clear();

        for (int i = 0; i < _lineSegmentCount; i++)
        {
            float stepTimePassed = stepTime * i;

            Vector3 MovmentVector = new Vector3(
                velocity.x * stepTimePassed,
                velocity.y * stepTimePassed - 0.5f * Physics.gravity.y * stepTimePassed * stepTimePassed,
                velocity.z * stepTimePassed
                );

            RaycastHit hit;
            if (Physics.Raycast(startingPoint, -MovmentVector, out hit, MovmentVector.magnitude))
            {
                break;
            }

            _LinePoints.Add(-MovmentVector + startingPoint);
        }

        _lineRenderer.positionCount = _LinePoints.Count;
        _lineRenderer.SetPositions(_LinePoints.ToArray());
    }
    public void HideLine()
    {
        _lineRenderer.positionCount = 0;
    }
}
