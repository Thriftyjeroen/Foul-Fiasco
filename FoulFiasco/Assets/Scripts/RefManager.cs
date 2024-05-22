using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RefManager : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    GameObject explosionGameObject;

    PlayerInfo playerInfo;

    private void Start()
    {
        //playerinfo gets assigned to the playerinfo object
        playerInfo = FindAnyObjectByType<PlayerInfo>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the collission tag is wall or ball
        if (collision.tag == "Wall" || collision.tag == "Ball")
        {
            
            transform.position = new Vector3(-8, transform.position.y, transform.position.z);
            //an explosion effect gets intantiated
            explosionGameObject = Instantiate(explosion);
            //explosion position gets set to the collission position
            explosionGameObject.transform.position = collision.transform.position;
            //collission object gets destroyed
            Destroy(collision.gameObject);
            //particles gets emitted from the explosion
            StartCoroutine(DestoryParticle());
        }

        //if the collision tag is player
        if (collision.tag == "Player")
        {
            //score gets set to 0
            playerInfo.score = 0;
            //main menu gets loaded
            SceneManager.LoadScene("MainMenu");
        }
    }

    IEnumerator DestoryParticle()
    {
        //sets a delay before removing the particles
        yield return new WaitForSeconds(0.6f);
        //the gameobject with the explosion gets destroyed
        Destroy(explosionGameObject);
    }
}
