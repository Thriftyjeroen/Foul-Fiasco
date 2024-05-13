using UnityEngine;

public class RefManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall" || collision.tag == "Ball")
        {

        }
    }
}
