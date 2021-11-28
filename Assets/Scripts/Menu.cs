using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    [SerializeField] GameObject menu;
    [SerializeField] GameObject optionmenu;
    [SerializeField] GameObject quittxt;

    private void Start()
    {
        quittxt.SetActive(false);
        optionmenu.SetActive(false);
    }

    public void startgame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void options(bool val)
    {
        menu.SetActive(!val);
        optionmenu.SetActive(val);
    }

    public void quitconfirm(bool val)
    {
        quittxt.SetActive(val);
        menu.SetActive(!val);
    } 

    public void quit()
    {
        Application.Quit();
    }

}
