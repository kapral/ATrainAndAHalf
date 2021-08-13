using System.Collections.Generic;
using System.Linq;
using GameLogic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private static readonly IList<RoutePoint> _path = new List<RoutePoint> { new RoutePoint { X = -7, Y = 3 }, new RoutePoint { X = 8, Y = 0 } };
    private int _currentPointIndex;

    public static void AddPoint(Vector3 point)
    {
        Debug.Log($"Adding point {point.x} {point.y}");
        _path.Add(new RoutePoint { X = point.x, Y = point.y });
    }

    // Start is called before the first frame update
    public void Start()
    {
        var startPoint = _path.FirstOrDefault();

        if (startPoint == null)
            return;

        transform.position = new Vector3(startPoint.X, startPoint.Y, transform.position.z);

        _currentPointIndex++;

        RotateTowardsNextPoint();
    }

    // Update is called once per frame
    public void Update()
    {
        if (_path.Count < 2)
            return;

        var nextPoint = GetNextPoint();

        if (nextPoint != transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPoint, 0.01f);
            return;
        }

        _currentPointIndex++;

        RotateTowardsNextPoint();
    }

    private void RotateTowardsNextPoint()
    {
        var nextPoint = GetNextPoint();
        transform.rotation = GetRotationTowards(nextPoint);
    }

    private Vector3 GetNextPoint()
    {
        var nextPoint = _path.ElementAtOrDefault(_currentPointIndex);

        if (nextPoint == null)
            _currentPointIndex = 0;

        nextPoint = _path.ElementAt(_currentPointIndex);

        return new Vector3(nextPoint.X, nextPoint.Y, transform.position.z);
    }

    private Quaternion GetRotationTowards(Vector3 target) {
        var diff  = target - transform.position;
        var angle = Mathf.Atan2 (diff.y, diff.x) * Mathf.Rad2Deg;

        return Quaternion.AngleAxis (angle, Vector3.forward);
    }
}
