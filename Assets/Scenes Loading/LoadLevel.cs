using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

    public void LoadLevelwithIndex(int index) {
        LoadingSceneManager.LoadLevel(index);
    }

}
