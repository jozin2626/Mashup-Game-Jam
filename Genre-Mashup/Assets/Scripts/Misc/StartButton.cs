using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject oldImage, newImage;

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Main Menu");
    }

    private void OnMouseDown()
    {
        if (gameObject.CompareTag("Button"))
        {
            oldImage.SetActive(false);
            FindObjectOfType<AudioManager>().Stop("Main Menu");
            Invoke("ChangeScene", 2f);
        }
    }

    private void ChangeScene()
    {
        
    }
}
