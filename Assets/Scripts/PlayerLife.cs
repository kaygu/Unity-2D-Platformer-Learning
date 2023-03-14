using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private TMP_Text life;

    [SerializeField] private float delayAfterDeath = 2f;
    [SerializeField] private int lives = 3;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        // life = GetComponent<Text>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            Die();
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        --lives;
        life.text = "Lives: " + lives.ToString();
        // reset player to spawn zone
        // spawn animation
        // set rb to Dynamic
        StartCoroutine("RestartLevelCo"); // This would not work with multiple lives since it restarts the whole scene & resets the lives

    }

    private IEnumerator RestartLevelCo()
    {
        yield return new WaitForSeconds(delayAfterDeath);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
