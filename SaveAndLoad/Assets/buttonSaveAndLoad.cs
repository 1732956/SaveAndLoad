using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonSaveAndLoad : MonoBehaviour {

    public void Save()
    {
        gameController.control.Save();
    }

    public void Load()
    {
        gameController.control.Load();
    }
}
