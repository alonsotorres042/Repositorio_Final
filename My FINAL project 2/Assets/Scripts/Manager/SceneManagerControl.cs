using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneManagerControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Return()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
    public void Play(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene("Game");
    }
}
