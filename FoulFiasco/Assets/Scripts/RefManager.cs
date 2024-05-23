using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RefManager : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    GameObject explosionGameObject;

    PlayerInfo playerInfo;


    private void Start()
    {
        playerInfo = FindAnyObjectByType<PlayerInfo>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall" || collision.tag == "Ball")
        {
            transform.position = new Vector3(-8, transform.position.y, transform.position.z);
            explosionGameObject = Instantiate(explosion);
            explosionGameObject.transform.position = collision.transform.position;
            Destroy(collision.gameObject);
            StartCoroutine(DestoryParticle());
        }

        if (collision.tag == "Player")
        {
            SceneManager.LoadScene("Scores");
        }
    }

    IEnumerator DestoryParticle()
    {
        yield return new WaitForSeconds(0.6f);
        Destroy(explosionGameObject);
    }
}
