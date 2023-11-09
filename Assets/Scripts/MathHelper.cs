using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class MathHelper
{
    public static float VectorDistance(Vector3 a, Vector3 b)
    {
        return (float)Mathf.Sqrt((float)(Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - b.y, 2)));
    }

    public static float DotProduct(Vector3 a, Vector3 b)
    {
        return (float)(a.x * b.x) + (a.y * b.y);
    }

    public static Vector3 CrossProduct(Vector3 a, Vector3 b)
    {
        return new Vector3(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);
    }

    public static float AngleBetween(Vector3 a, Vector3 b)
    {
        return (float)Math.Acos(((a.x * b.x) + (a.y * b.y)) / (a.magnitude * b.magnitude));
    }
}
