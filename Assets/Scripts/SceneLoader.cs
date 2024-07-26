using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public List<string> additiveScenes = new List<string>();
    [SerializeField] GameObject fader;

    // Start is called before the first frame update
    void Start()
    {
        foreach (string str in additiveScenes)
        {
            SceneManager.LoadScene(str, LoadSceneMode.Additive);
        }
    }

    public void LoadScene(string str)
    {
        SceneManager.LoadScene(str);
    }

    public void UnLoadScene(string str)
    {
        SceneManager.UnloadSceneAsync(str);
    }

    public void TransScene(string scene)
    {
        StartCoroutine(transition(scene, 1.0f));
    }

    IEnumerator transition(string scene, float delay)
    {
        Instantiate(fader);
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene);
    }
}
