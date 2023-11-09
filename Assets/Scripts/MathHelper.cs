using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class MathHelper
{
    public static void VectorDistance(Vector3 a, Vector3 b)
    {
        float distance = (float)Mathf.Sqrt((float)(Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - b.y, 2)));
    }

    public static void DotProduct(Vector3 a, Vector3 b)
    {
        float dotProduct = (a.x * b.x) + (a.y * b.y);
    }

    public static void CrossProduct(Vector3 a, Vector3 b)
    {
        Vector3 crossProduct = new Vector3(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);
    }

    public static void AngleBetween(Vector3 a, Vector3 b)
    {
        float angle = (float)Math.Acos(((a.x * b.x) + (a.y * b.y)) / (a.magnitude * b.magnitude));
    }
}
