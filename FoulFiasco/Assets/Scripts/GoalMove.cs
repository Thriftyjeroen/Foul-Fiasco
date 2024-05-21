using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.U2D;
using UnityEngine;

public class GoalMove : MonoBehaviour
{
    private void Start()
    {
        //position of the goal gets adjusted to a new vector3 which contains a random y coordinate, the x and z coordinate will not get adjusted
        transform.position = new Vector3(transform.position.x, Random.Range(-4, 4), transform.position.z);
    }
}
