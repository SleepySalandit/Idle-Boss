using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Methods : MonoBehaviour
{
    public static List<T> CreateList<T>(int capacity)
    {
        return Enumerable.Repeat(default(T), capacity).ToList();
    }

    public static void UpgradeCheck<T>(List<T> list, int length) where T : new()
    {
        try
        {
            if (list.Count == 0) list = new T[length].ToList();
            while(list.Count < length) list.Add(new T());
        }
        catch
        {
            list = CreateList<T>(length);
        }
    }
}
