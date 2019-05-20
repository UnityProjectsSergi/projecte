using UnityEngine;
using UnityEditor;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class UtilsLoadSave
{

    /// <summary>
    /// Save To Json File
    /// </summary>
    /// <typeparam name="T">ObjectType</typeparam>
    /// <param name="objectToSave">Data obj to save</param>
    /// <param name="fullPath">Path of file</param>
    /// <param name="delete">if its true the data its deleted if its false de data is added to file</param>
    /// 
    public static void SaveInJson<T>(T objectToSave, string fullPath, bool delete = true) where T : new ()
    {
        // if file exits
      
        if (File.Exists(fullPath))
        {
            // is exists deleted?
            if (delete)
            {
                //delete file and create wen
                File.Delete(fullPath);
                
                File.WriteAllText(fullPath, JsonConvert.SerializeObject(objectToSave));
            }
            // if exist and not delete
            else
            {
                // read the file and apped extra information
                string json = File.ReadAllText(fullPath);
                Append(fullPath, json + JsonConvert.SerializeObject(objectToSave));
            }
        }
        //if not exits wirte
        File.WriteAllText(fullPath, JsonConvert.SerializeObject(objectToSave));
    }

    private static void Append(string path, string contents)
    {
        File.WriteAllText(path, contents);
    }
    /// <summary>
    /// LoadFromJson
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="fullPath"></param>
    /// <returns></returns>
    
    public static T LoadFromJson<T>(string fullPath) where T : new()
    {
        // if exists
        if (File.Exists(fullPath))
        {
           /// read and return T type
            string json = File.ReadAllText(fullPath);
            return JsonConvert.DeserializeObject<T>(json);
        }
        else
        {
            // if not exists file 52
            return new T();
        }
    }
    //private static string AddExtension(SourceTypeSaveLoad type, string fullPath)
    //{
    //    switch (type)
    //    {
    //        case SourceTypeSaveLoad.JSON:
    //            fullPath += ".json";
               
    //            break;
    //        case SourceTypeSaveLoad.XML:

    //            fullPath += ".xml";
    //            break;
    //        case SourceTypeSaveLoad.DAT:
    //            fullPath += ".dat";
    //            break;
    //        default:
    //            break;
    //    }
    //    return fullPath;
    //}
}