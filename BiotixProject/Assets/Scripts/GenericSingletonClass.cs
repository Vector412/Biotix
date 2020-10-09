using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSingletonClass<T> : MonoBehaviour where T : Component
{
    private static T instance;
    public static T Instance => instance;

    public virtual void Awake()
    {
        if (!instance)
        {
            instance = this as T;
        }
        else
        {
            Destroy(this);
        }
    }
}
