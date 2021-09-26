using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HalamanManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayLevelSatu() { SceneManager.LoadScene("LevelSatu"); }
    public void PlayLevelDua() { SceneManager.LoadScene("LevelDua"); }
    public void BacktoMenu() { SceneManager.LoadScene("MainMenu"); }
    public void NextLevel() { SceneManager.LoadScene("Pembaharuan"); }
    public void CaraBermain() { SceneManager.LoadScene("HowtoPlay"); }
    public void ExitGame() { Application.Quit(); }
}