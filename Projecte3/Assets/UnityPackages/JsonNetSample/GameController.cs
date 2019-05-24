
using System.Collections;
using System.IO;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float health;
    /// <summary>
    /// Path of the file to save data
    /// </summary>
    public static string datapath = string.Empty;

    /// <summary>
    /// Says if The game was loaded or not loaded
    /// </summary>
    public static bool hasLoadedGameData = false;
    /// <summary>
    /// Current GameSlot Loaded in Game
    /// </summary>
 //    public GameSlot currentSlot = null;

    /// <summary>
    /// Says if file Esxists
    /// </summary>
    public bool fileExists;

    public GameObject _prefab;
    /// <summary>
    /// Instance Private 
    /// </summary>
    private static GameController _instance = null;
    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private bool IsSlotInCurrentSlot;
    /// <summary>
    /// Current Slot Resume loaded
    /// </summary>
   
  //  public  InfoSlotResume currentSlotResume=null;
    /// <summary>
    /// Instace public
    /// </summary>
    public static GameController Instance
    {
        get { return _instance; }
    }

    

    /// <summary>
    /// Create GameObject in scene
    /// </summary>
    /// <param name="prefab">Prefab </param>
    /// <param name="position">Position of gameobject</param>
    /// <param name="rotation">Rotatio of gameobject</param>
    /// <returns></returns>
    //public static ObjToSave CreateGameObject(GameObject prefab, Vector3 position, Quaternion rotation)
    //{

    //    GameObject go = Instantiate(prefab, position, rotation);
    //    ObjToSave obj = go.GetComponent<ObjToSave>();
    //    if (obj == null)
    //        go.AddComponent<ObjToSave>();
    //    return obj;
    //}

    /// <summary>
    /// Create Game Object that has been saven on file
    /// </summary>
    /// <param name="data">Object Data from file</param>
    /// <param name="position">Position from file</param>
    /// <param name="rotation">Rrotation from file</param>
    /// <returns></returns>
    //public static ObjToSave CreateObjSaved(GameObjectActorData data)
    //{
    //    Debug.Log(data.__prefabPath+" "+ Resources.Load<GameObject>(data.__prefabPath));
    //    ObjToSave obj = CreateGameObject(Resources.Load<GameObject>(data.__prefabPath), data.position, data.rotationQuaterion);

    //    obj.gameObjSave.data = data;
    //    return obj;
    //}

    public static T GetOrAddComponent<T>(GameObject obj) where T : Component
    {
        if (obj.GetComponent<T>())
            return obj.GetComponent<T>();
        else
            return obj.AddComponent<T>() as T;
    }

    /// <summary>
    /// Load Function Loads data
    /// </summary>
    public static void Load()
    {
        if (!hasLoadedGameData)
        {
            hasLoadedGameData = true;
            SaveData.Load(datapath);
        }
    }

    /// <summary>
    /// Save Funton calls SaveData.save
    /// </summary>
    public static void Save()
    {
       // SaveData.objcts.Slots.Clear();
        SaveData.SaveToFile<GameDataSaveContainer>(datapath, SaveData.objcts, true);
    }
    //public static void SaveSlotObj()
    //{
    //    SaveData.SaveSlot<GameSlot>(GameController.Instance.currentSlotResume.FileSlot, GameController.Instance.currentSlot, true);
    //}
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            //currentSlot = null;
            //currentSlotResume = null;
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
            datapath = System.IO.Path.Combine(Application.persistentDataPath, "data2.json");
            fileExists = File.Exists(datapath);
           
            Load();
            
        }
    }

   
    private void Start()
    {
        //currentSlotResume = null;
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("SAVE");
            Save();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
         //   SaveSlotObj(); 
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Load");
            Load();
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            //SaveData.LoadGameSlotData();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Create");
           // CreateGameObject(_prefab, new Vector3(2, 5, 0), Quaternion.identity);
        }
    }
    //public void TakeScreenShot()
    //{
       
    //        ScreenCapture.CaptureScreenshot(Application.persistentDataPath + "/" + GameController.Instance.currentSlotResume.FolderOfSlot + "/ScreenShot.png");
    //        GameController.Instance.currentSlotResume.ScreenShot = Application.persistentDataPath
    //            + "/" + GameController.Instance.currentSlotResume.FolderOfSlot + "/ScreenShot.png";
    //        GameController.Save();
      
    //}
    //private void OnApplicationQuit()
    //{
    //    currentSlotResume = null;
    //}
}