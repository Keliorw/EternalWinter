using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    [Header("Загружаемая сцена")]
    public int sceneID;
    [Header("Остальные объекты")]
    public Image loadingImg;

    void Start(){
        StartCoroutine(AsyncLoad());
    }

    IEnumerator AsyncLoad(){
        AsyncOperation operation  = SceneManager.LoadSceneAsync(this.sceneID);
        while(!operation.isDone){
            float progress = operation.progress / 0.9f;
            loadingImg.fillAmount = progress;
            yield return null;
        }
        SceneManager.UnloadSceneAsync(this.sceneID);
    }
}
