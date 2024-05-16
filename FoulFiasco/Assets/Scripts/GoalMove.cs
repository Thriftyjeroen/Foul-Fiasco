using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.U2D;
using UnityEngine;

public class GoalMove : MonoBehaviour
{
    private void Start()
    {
        transform.position = new Vector3(transform.position.x, Random.Range(-4, 4), transform.position.z);
    }
}
