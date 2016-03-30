using UnityEngine;
using System.Collections;

public class LoadingSceneManager : MonoBehaviour
{
    public UnityEngine.UI.Image loadingBar;
    public UnityEngine.UI.Button button;

    private static int levelIndex = 1;
    public static void LoadLevel(int index)
    {
        levelIndex = index;
        Application.LoadLevel("s Loading");
    }

    void Start() {
        StartCoroutine(LoadLevelWithBar(levelIndex));
    }

    private IEnumerator LoadLevelWithBar(int index)
    {
        AsyncOperation asy = Application.LoadLevelAsync(index);
        asy.allowSceneActivation = false;

        float loaded = 0;
        while (!asy.isDone)
        {
            loaded = asy.progress / 0.9f;
            loadingBar.fillAmount = loaded;

            if(loaded >= 0.98f)
            {
                button.gameObject.SetActive(true);
                button.onClick.AddListener( () => {
                    asy.allowSceneActivation = true;
                } );
            }

            yield return null;
        }

        yield return null;
    }

}
