using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class save 
{
    #region JSON
    public static void SaveByJson(string saveFileName, object data)
    {
        var json = JsonUtility.ToJson(data);
        var path = Path.Combine(Application.persistentDataPath, saveFileName);

       

        try
        {
            File.WriteAllText(path, json);
              #if UNITY_EDITOR
            Debug.Log($"�ɹ����� {path}");
              #endif
        }
        catch(System.Exception exception)
        {
              #if UNITY_EDITOR
            Debug.LogError($"�浵ʧ�� {path}.\n{exception}");
              #endif
        }
    }
    public static T LoadFromJson<T>(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);
        
        try
        {
            var json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<T>(json);

            return data;
        }
        catch (System.Exception exception)
        {
            #if UNITY_EDITOR
            Debug.LogError($"����ʧ�� {path}.\n{exception}");
            #endif
            return default;
        }
    }
    #endregion
    #region Deleting
    public static void DeleteSaveFile(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);

        try
        {
            File.Delete(path);

        }
        catch (System.Exception exception)
        {
            #if UNITY_EDITOR
            Debug.LogError($"ɾ��ʧ�� {path}.\n{exception}");
            #endif

        }
    }
#endregion

}
