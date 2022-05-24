using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FAllTomatch2 : MonoBehaviour
{
    public string Player;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Player)
        {
            SingleToon.getInstance().curmoney.spend(1000);
            SingleToon.getInstance().curscore.raise(-100);
            SceneManager.LoadScene("FallToMetchLevel2");

        }
    }
}
