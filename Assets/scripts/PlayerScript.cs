using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerScript : MonoBehaviour
{
    public Camera cam;
    
    public Transform tr;
    public Text Score;
    public GameObject PauseMenu;
    public static bool isPaused = true;
    [SerializeField] private int PlayTimeScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tr.position.x >= 0)
        {
            Score.text = cam.transform.position.x.ToString("0");
        }
        else
        {
            Score.text = "0";
        }
    }

    private void OnCollisionEnter(Collision collides)
    {
        if(collides.collider.name == "Ground")
        {
            Debug.Log("GAME OVER");
            Invoke("die", 0.5f);
            return;
        }

        if(collides.collider.tag == "platform")
        {
            FindObjectOfType<Audiomanager>().Play("Bounce");
        }
    }
    public void die()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        PlayTimeScore = int.Parse(Score.text);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }


}
