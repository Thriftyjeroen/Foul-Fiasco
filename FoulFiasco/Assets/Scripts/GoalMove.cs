using UnityEngine;

public class GoalMove : MonoBehaviour
{
    private void Start()
    {
        transform.position = new Vector3(transform.position.x, Random.Range(-4, 4), transform.position.z);
    }
}
