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

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player Hp" + hp);
        if (other.gameObject.CompareTag("Mopojonne"))
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

    void youDied()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene("gamescene2");
    }

}


