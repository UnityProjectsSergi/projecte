using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace FSM
{
    public class CookingBlackbloard : MonoBehaviour
    {
      
        [HideInInspector]
        public FSM_ProgressBar progressBar;
        public GameObject ProgBarGO;
        public GameObject HideShowGO;
        [HideInInspector]
        public FSM_ShowHideImage FSM_ShowHideImage;
       public PotBlackboard potBlackboard;
        public float duration;
        public ItemPotFSM itemPotFSM;
        // Use this for initialization
        void Awake()
        {
            progressBar = ProgBarGO.AddComponent<FSM_ProgressBar>();
            FSM_ShowHideImage = HideShowGO.AddComponent<FSM_ShowHideImage>();
            potBlackboard = GetComponent<PotBlackboard>();
            itemPotFSM = GetComponent<ItemPotFSM>();
            progressBar.enabled = false;
            FSM_ShowHideImage.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}