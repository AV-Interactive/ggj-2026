using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CliffPointTag : MonoBehaviour
{
    public static readonly List<CliffPointTag> InGameCliffPoints = new();

    


    private void OnEnable()
    {
        if (!InGameCliffPoints.Contains(this))
            InGameCliffPoints.Add(this);
    }

    private void OnDisable()
    {
        InGameCliffPoints.Remove(this);
    }

    /// <summary>
    /// Finds the closest cliff point on the left side (X axis) of the given transform.
    /// </summary>
    public static void FetchLastCliffPointFromAxisX(
        in Transform pointToCheck,
        out bool found,
        out Transform point)
    {
        float xPlayer = pointToCheck.position.x;

        CliffPointTag closest = InGameCliffPoints
            .Where(p => p.transform.position.x < xPlayer)
            .OrderByDescending(p => p.transform.position.x)
            .FirstOrDefault();

        found = closest != null;
        point = found ? closest.transform : null;
    }
}
