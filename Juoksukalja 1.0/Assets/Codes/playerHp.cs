using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHp : MonoBehaviour
{

    [SerializeField]
    DamageFlicker Flicker;

    public int hp = 3;
    public SpriteRenderer[] hearts;

    public Sprite emptyHeart;

    public bool nodamage = false;


    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Player Hp" + hp);
        if (other.gameObject.CompareTag("Mopojonne") && !nodamage)
        {
            // Decrease player hp by 1
            hp--;

            Flicker.Flicker();

            hearts[hp].sprite = emptyHeart;

            nodamage = true;
            Invoke("EnableDamage", 2.0f);

            if (hp <= 0)
            {
                youDied();
            }

        }
    }
    void EnableDamage()
    {
        Debug.Log("damage");
        nodamage = false;
    }

    void youDied()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene("gamescene2");
    }

    public void takeDamage()
    {
        hp--;
        hearts[hp].sprite = emptyHeart;
        nodamage = true;
        Invoke("EnableDamage", 2.0f);
    }

}


