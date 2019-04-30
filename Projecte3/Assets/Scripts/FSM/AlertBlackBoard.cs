using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace FSM
{
    public class AlertBlackBoard : MonoBehaviour
    {

      
      
        public GameObject HideShowGO;
          
        [HideInInspector]
        public FSM_ShowHideImage FSM_ShowHideImage;
        private void Awake()
        {
            FSM_ShowHideImage = HideShowGO.AddComponent<FSM_ShowHideImage>();
            FSM_ShowHideImage.enabled = false;
        }
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}