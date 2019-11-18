using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonSceneController : MonoBehaviour {

    public void NextScene()
    {
        SceneController.sceneControl.NextScene();
    }

    public void PreviousScene()
    {
        SceneController.sceneControl.PreviousScene();
    }
}
