using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonModifiesPlayerData : MonoBehaviour {

    public void IncreaseAttack()
    {
        gameController.control.AddAttack();
    }

    public void IncreaseGunAttack()
    {
        gameController.control.AddAttackGuns();
    }

    public void IncreaseDefense()
    {
        gameController.control.AddDefense();
    }

    public void Inscreasehealth()
    {
        gameController.control.Addhealth();
    }

    public void AddGuns()
    {
        gameController.control.AddWeapon();
    }

    public void IncreaseIndex()
    {
        gameController.control.AddCurrentIndex();
    }

    public void DecreaseIndex()
    {
        gameController.control.LessCurrentIndex();
    }



}
