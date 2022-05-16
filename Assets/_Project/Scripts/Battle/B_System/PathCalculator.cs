using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PathCalculator : MonoBehaviour
{
    Queue<CubeCoordinate> testPath = new Queue<CubeCoordinate>();
    [SerializeField] Grid ground;

    void Awake() {
        GetPath(GetStart(), GetEnd());
    }

    public Queue<Vector3> GetPath(CubeCoordinate userLocation, CubeCoordinate endTarget) {
        var path = new Queue<Vector3>();

        CubeCoordinate end = endTarget - userLocation;
        foreach (var point in PointsOnLine(end))
            path.Enqueue(point);

        return path;
    }

    CubeCoordinate GetStart() {
        return CubeCoordinate.zero;
    }

    CubeCoordinate GetEnd() {
        var pathEnd = CubeCoordinate.left + CubeCoordinate.left + CubeCoordinate.upLeft + CubeCoordinate.left;
        return pathEnd;
    }

    List<Vector3> PointsOnLine(CubeCoordinate end) {
        var pointsOnLine = new List<Vector3>();

        for (int i = 0; i < end.Steps() + 1; i++) {
            var point = Vector3.zero + (OneLength(end) * i);
            pointsOnLine.Add(point);
        }

        return pointsOnLine;
    }

    Vector3 OneLength(CubeCoordinate end) {
        var endV3 = GetWorld(end);
        var steps = end.Steps();

        if (steps == 0) return Vector3.zero;
        else return Vector3.Lerp(Vector3.zero, endV3, 1 / steps);
    }

    Vector3 GetWorld(CubeCoordinate cube) {
        return ground.CellToWorld(cube.ToGrid());
    }
}