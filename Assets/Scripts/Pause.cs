using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _button;

    public void pause()
    {
        Time.timeScale = 0;
        _button.SetActive(false);
        _menu.SetActive(true);
    }

    public void returnGame()
    {
        Time.timeScale = 1;
        _button.SetActive(true);
        _menu.SetActive(false);
    }

    public void salir()
    {
        SceneManager.LoadScene("Menu");
    }
}
