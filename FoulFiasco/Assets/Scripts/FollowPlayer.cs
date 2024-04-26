using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    public float delay = 0.8f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public IEnumerator JumpMovement()
    {
        yield return new WaitForSeconds(delay);
        rb.AddForce(Vector2.up * 12, ForceMode2D.Impulse);
    }

    public IEnumerator SlideMovementDown()
    {
        yield return new WaitForSeconds(delay);
        transform.localScale = new Vector3(1, 0.5f, 1);
    }

    public IEnumerator SlideMovementUp()
    {
        yield return new WaitForSeconds(delay);
        transform.localScale = new Vector3(1, 1, 1);
    }
}