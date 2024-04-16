using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Janomittari : MonoBehaviour
{
    public StartGame SG;

    public GameObject janoMittari;
    public Image Jano;

    void Update()
    {

        if (SG.HasGameStarted())
        {
            janoMittari.SetActive(true);

            Jano.fillAmount = Mathf.Lerp(Jano.fillAmount, Jano.fillAmount - (0.016f * 3.8f), Time.deltaTime);
            //if (Jano.fillAmount <= 0)
            //Debug.Log("Mittari tyhjä!");
        }

    }
}
