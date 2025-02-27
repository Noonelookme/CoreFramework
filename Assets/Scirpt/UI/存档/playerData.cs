using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
public class playerData : MonoBehaviour

{
    public GameObject UI;
   
    
   [System.Serializable] class SaveData
    { 
       
        public Vector3 playerPosition;
        public float HP;
             
    }
   
    const string PLAYER_DATA_FILE_NAME = "PlayerData.sav";

   

    public void Save()
    {
        SaveByJson();
    }
    public void Load()
    {
        LoadFromJson();
    }

    void LoadFromJson()
    {
       var saveData = save.LoadFromJson<SaveData>(PLAYER_DATA_FILE_NAME);
        LoadData(saveData);
    }
    SaveData SavingData()
    {
        var saveData = new SaveData
        {
            playerPosition = transform.position
        };
        DamagebleCharacter damageble = GetComponent<DamagebleCharacter>();
        saveData.HP = damageble.health;
        Debug.Log($"´æµµ³É¹¦ {saveData.HP}");
        return saveData;
    }
    void LoadData(SaveData saveData)
    {
        transform.position = saveData.playerPosition;
        DamagebleCharacter damageble = GetComponent<DamagebleCharacter>();
        damageble.health = saveData.HP;
        Hp(damageble.health);
    }
    void SaveByJson()
    {
        save.SaveByJson(PLAYER_DATA_FILE_NAME, SavingData());
    }
    public void Hp(float health)
    {
        DamagebleCharacter damageble = GetComponent<DamagebleCharacter>();
        damageble.hpEffectImg.fillAmount = health / damageble.maxHP;
        damageble.hpImg.fillAmount = health / damageble.maxHP;
    }

}

