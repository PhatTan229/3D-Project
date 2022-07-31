using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum SceneTheme
{
    Village,
    Town,
    Forest,
    City,
    Kingdom
}

[System.Serializable]
public class SceneData
{
    public SceneTheme theme;
    public Sprite background;
}

public class LoadingScreen : MonoBehaviour
{
    public static LoadingScreen Instance;
    public float fakeLoadingDuration;
    public Sprite[] themeSprites;
    //public SceneData[] scenes;
    public Image background;
    public Slider progressBar;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        gameObject.SetActive(false);
    }
    public void LoadScene(SceneTheme theme)
    {
        background.sprite = themeSprites[(int)theme];
        gameObject.SetActive(true);
        StartCoroutine(AsyncLoading(theme));
    }
    private IEnumerator AsyncLoading(SceneTheme theme)
    {
        //Time.timeScale = 0;
        AsyncOperation task = SceneManager.LoadSceneAsync(theme.ToString());
        float startTime = Time.time;
        float fakeProgress = 0;
        while (!task.isDone || fakeProgress < 1)
        {
            float normalizedTime = (Time.time - startTime) / fakeLoadingDuration;
            fakeProgress = Mathf.Min(task.progress, normalizedTime);
            progressBar.value = fakeProgress;
            yield return null;
        }
        gameObject.SetActive(false);
        //Time.timeScale = 1;
    }
}
