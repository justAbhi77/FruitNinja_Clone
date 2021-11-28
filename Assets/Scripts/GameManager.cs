using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] Camera mainCam;

    [SerializeField] List<GameObject> items;
    
    [SerializeField] GameObject gameoverobj;

    [SerializeField] GameObject Trail;

    [SerializeField] float spawnrate = 1f;

    [SerializeField] bool isgameover;

    [SerializeField] InputActionReference click,getPos;

    Coroutine cor;

    void Start()
    {
        click.action.started += starttouch;
        click.action.canceled += endtouch;

        gameoverobj.SetActive(false);
        StartCoroutine(Spawn());
    }

    public void gameOver()
    {
        isgameover = true;
        gameoverobj.SetActive(true);
    }

    void starttouch(InputAction.CallbackContext ctx)
    {
        if (isgameover) return;

        Vector2 pos = getPos.action.ReadValue<Vector2>();
        pos=mainCam.ScreenToWorldPoint(pos);

        Trail.transform.position = pos;
        Trail.SetActive(true);

        cor = StartCoroutine(trail());
    }

    IEnumerator trail()
    {
        while (!isgameover)
        {
            Vector2 pos = getPos.action.ReadValue<Vector2>();
            pos = mainCam.ScreenToWorldPoint(pos);
            Trail.transform.position = pos;

            yield return null;
        }
    }

    void endtouch(InputAction.CallbackContext ctx)
    {
        if (isgameover) return;
         
        Trail.SetActive(false);

        StopCoroutine(cor);
    }

    IEnumerator Spawn()
    {
        while (!isgameover)
        {
            yield return new WaitForSeconds(spawnrate);
            int index = Random.Range(0, items.Count);
            Instantiate(items[index]);
        }
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void Quittomain()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex-1);
    }

}
