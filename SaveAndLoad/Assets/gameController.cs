using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class gameController : MonoBehaviour {
    public static gameController control;

    public List<GunData> gunDatas;

    public int gunIndex;
    public int attackGun;
    public int attack;
    public int defense;
    public int health;
    public int currentweaponindex;
    // Use this for initialization
    void Start() {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
            setDefaulValue();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void setDefaulValue()
    {
        attack = 1;
        defense = 1;
        health = 1;
        gunDatas = new List<GunData>();
        gunIndex = 0;
    }

    public void AddWeapon()
    {
        GunData Weapon = new GunData();
        Weapon.attackGun = 1;
        gunDatas.Add(Weapon);
        
    }


    public void AddAttack()
    {
        attack++;
    }

    public void AddAttackGuns()
    {
        gunDatas[currentweaponindex].attackGun++;
    }

    public void LessCurrentIndex()
    {
        if (currentweaponindex != 0)
        {
            currentweaponindex--;
        }
        else
        {
            if (gunDatas.Count!=0)
            {
                currentweaponindex = gunDatas.Count-1 ;
            }
            else
            {
                currentweaponindex = 0;
            }
        }
    }

    public void AddCurrentIndex()
    {
        if (gunDatas.Count-1 > currentweaponindex)
        {
            currentweaponindex++;
        }
        else
        {
            currentweaponindex = 0;
        }
       
    }

    public void AddDefense()
    {
        defense++;
    }

    public void Addhealth()
    {
        health++;
    }

    public void Load()
    {
        BinaryFormatter bf = new BinaryFormatter();
        if (!File.Exists(Application.persistentDataPath + "gameInfo.dat"))
        {
            throw new Exception("Game file doesnt exist");
        }
        FileStream file = File.Open(Application.persistentDataPath + "gameInfo.dat", FileMode.Open);
        PlayerData playerDataToLoad = (PlayerData)bf.Deserialize(file);
        file.Close();
        attack = playerDataToLoad.attack;
        defense = playerDataToLoad.defense;
        health = playerDataToLoad.health;
        gunDatas = playerDataToLoad.listWeapon;
        currentweaponindex = playerDataToLoad.gunIndex;
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "gameInfo.dat",FileMode.Create);
        PlayerData playerDataToSave = new PlayerData();
        playerDataToSave.attack = attack;
        playerDataToSave.defense = defense;
        playerDataToSave.health = health;
        playerDataToSave.listWeapon = gunDatas;
        playerDataToSave.gunIndex = currentweaponindex;
        bf.Serialize(file, playerDataToSave);
        file.Close();
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 32;
        GUI.Label(new Rect(10, 60, 180, 80), "Attack: " + attack, style);
        GUI.Label(new Rect(10, 110, 180, 80), "Defense: " + defense, style);
        GUI.Label(new Rect(10, 160, 180, 80), "health: " + health, style);
        if (gunDatas.Count>0)
        {
            GUI.Label(new Rect(10, 210, 180, 80), "Fusil: " + currentweaponindex, style);
            GUI.Label(new Rect(10, 260, 180, 80), "Fusilattack: " + gunDatas[currentweaponindex].attackGun, style);
        }
    }


}
[Serializable]
class PlayerData
{
    public int attack;
    public int defense;
    public int health;
    public int gunIndex;
    public List<GunData> listWeapon;
}

[Serializable]
public class GunData
{
    public int attackGun;
}
