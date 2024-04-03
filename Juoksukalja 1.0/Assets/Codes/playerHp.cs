using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHp : MonoBehaviour
{

    [SerializeField]

    int hp = 3;

    private void OnCollisionEnter2D(Collision2D hazards)
    {
        // Decrease player hp by 1
        hp--;
        //Debug.Log("Player Hp" + hp);

        if (hp == 0)
        {
            youDied();
        }
    }

    void youDied()
    {
        //Debug.Log("Game Over");
        //SceneManager.LoadScene("");
    }
}

