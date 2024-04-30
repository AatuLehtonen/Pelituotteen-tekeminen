using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Janomittari : MonoBehaviour
{
    public StartGame SG;

    public playerHp HP;

    public GameObject janoMittari;
    public Image Jano;

    void Update()
    {

        if (SG.HasGameStarted())
        {
            janoMittari.SetActive(true);

            Jano.fillAmount = Mathf.Lerp(Jano.fillAmount, Jano.fillAmount - (0.016f * 3.8f), Time.deltaTime);
            if (Jano.fillAmount <= 0 && !HP.nodamage)
            {
                Debug.Log("Mittari tyhjä!");
                HP.takeDamage();

                Jano.fillAmount = 1;
            }

        }

    }

    public void Drink()
    {
        Jano.fillAmount = Jano.fillAmount + 0.33f;
    }
}
