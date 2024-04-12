using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHp : MonoBehaviour
{

    [SerializeField]

    int hp = 3;
    public SpriteRenderer[] hearts;

    public Sprite emptyHeart;

    bool nodamage = false;


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player Hp" + hp);
        if (other.gameObject.CompareTag("Mopojonne") && !nodamage)
        {
            // Decrease player hp by 1
            hp--;

            hearts[hp].sprite = emptyHeart;


            if (hp <= 0)
            {
                youDied();
            }

        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Mopojonne"))
        {
            nodamage = true;
            Invoke("EnableDamage", 3.0f);
        }
    }
    void EnableDamage()
    {
        nodamage = false;
    }

    void youDied()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene("gamescene2");
    }

}


