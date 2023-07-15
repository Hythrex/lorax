using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelPreviewScript : MonoBehaviour
{
    public GameObject top;
    public GameObject bottom;

    public AudioSource aSource;
    public AudioClip bellSound;

    public TMP_Text text1; // the gameobject and this is different
    public TMP_Text text2;

    private int weekLevel;
    

    private void Start()
    {
        weekLevel = PlayerPrefs.GetInt("week");
        top.SetActive(false);
        bottom.SetActive(false);

        this.changetext();

        StartCoroutine(showText());
    }

    private IEnumerator showText()
    {
        Debug.Log("The player is on week " + weekLevel + "!");
        yield return new WaitForSeconds(1.5f);
        top.SetActive(true);
        aSource.PlayOneShot(bellSound, 1);
        yield return new WaitForSeconds(4f);
        bottom.SetActive(true);
        aSource.PlayOneShot(bellSound, 1);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Level1");
    }

    private void changetext()
    {
        text1.text = "Week " + weekLevel;
        if (weekLevel == 2)
        {
            text2.text = "keep chopping down the trees";
        }
        else if (weekLevel  == 3)
        {
            text2.text = "stop chopping down the trees";
        }
        
    }
}
