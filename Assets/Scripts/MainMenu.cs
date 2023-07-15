using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    // excuse my terrible code
    public GameObject selectHolder1;
    public GameObject selectHolder2;
    public GameObject label;

    public GameObject anim1;
    public GameObject anim2;

    public TMP_Text label_text;

    private void Start()
    {
        selectHolder1.SetActive(false);
        selectHolder2.SetActive(false);
        label.SetActive(false);

        StartCoroutine(Anims());
    }

    private void Update()
    {
        // this is just temporary
        // im gonna comment this soon
        if (Input.GetKeyDown(KeyCode.Return))
        {
            PlayerPrefs.SetInt("week", 3);
            PlayerPrefs.Save();
            Debug.Log("hi");
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            PlayerPrefs.SetInt("week", 1);
            PlayerPrefs.Save();
            Debug.Log("bru");
        }
    }

    private IEnumerator Anims()
    {
        /* i need a more effecient way to do this 
        should probably make it an animation and make it play forever */
        anim1.SetActive(true);

        yield return new WaitForSeconds(2f);

        anim2.SetActive(true);
        anim1.SetActive(false);
        yield return new WaitForSeconds(0.05f);

        anim2.SetActive(false);
        anim1.SetActive(true);
        yield return new WaitForSeconds(0.05f);

        anim2.SetActive(true);
        anim1.SetActive(false);
        yield return new WaitForSeconds(0.01f);

        anim2.SetActive(false);
        anim1.SetActive(true);
        yield return new WaitForSeconds(0.1f);

        anim2.SetActive(true);
        anim1.SetActive(false);
        yield return new WaitForSeconds(0.05f);

        anim2.SetActive(false);
        anim1.SetActive(true);

        StartCoroutine(Anims()); /* basically loop it forever */
    }

    public void continueButton()
    {
        SceneManager.LoadScene("Loadthing");
    }

    public void startNew()
    {
        PlayerPrefs.SetInt("week", 1); // this is necessary
        PlayerPrefs.Save();
        SceneManager.LoadScene("Loadthing");
    }

    public void showMouseSelect1()
    {
        selectHolder1.SetActive(true);
    }

    public void removeMouseSelect1()
    {
        selectHolder1.SetActive(false);
    }

    public void showMouseSelect2()
    {
        selectHolder2.SetActive(true);
        label.SetActive(true);
        label_text.text = "Week " + PlayerPrefs.GetInt("week");
    }

    public void removeMouseSelect2()
    {
        selectHolder2.SetActive(false);
        label.SetActive(false);
    }

}
