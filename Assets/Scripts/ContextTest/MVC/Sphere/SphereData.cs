﻿using UnityEngine;


[CreateAssetMenu(fileName = "NewModel", menuName = "CreateModel/Sphere", order = 0)]
public sealed class SphereData : ScriptableObject
{
    #region Fields

    public SphereStruct SphereStruct;

    #endregion


    #region Metods

    public void Move(Transform transform, GameObject target, float speed)
    {
        transform.position = Vector3.MoveTowards
            (transform.position,
            target.transform.position,
            speed);
    }

    public void ChangeBox(SphereCollider SphereCollider, float SphereRadius)
    {
        SphereCollider.radius = SphereRadius;
    }

    #endregion
}
