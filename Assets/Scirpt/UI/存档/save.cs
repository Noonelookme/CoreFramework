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
            Debug.Log($"≥…π¶¥Ê»Î {path}");
              #endif
        }
        catch(System.Exception exception)
        {
              #if UNITY_EDITOR
            Debug.LogError($"¥Êµµ ß∞‹ {path}.\n{exception}");
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
            Debug.LogError($"∂¡µµ ß∞‹ {path}.\n{exception}");
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
            Debug.LogError($"…æ≥˝ ß∞‹ {path}.\n{exception}");
            #endif

        }
    }
#endregion

}
