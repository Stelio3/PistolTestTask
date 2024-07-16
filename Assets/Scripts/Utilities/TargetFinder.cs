using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class TargetFinder
{
    public static Vector2 FindNearestTarget(Vector2 position)
    {
        var targets = GameObject.FindGameObjectsWithTag("Target")
                                .Where(t => !t.GetComponent<ITarget>().Ignore && Vector3.Distance(position, t.transform.position) < 8)
                                .ToArray();
        if (targets.Length == 0) return Vector2.zero;

        GameObject nearestTarget = targets.OrderBy(t => (t.transform.position - (Vector3)position).sqrMagnitude).FirstOrDefault();
        return (nearestTarget.transform.position - (Vector3)position).normalized;
    }
}