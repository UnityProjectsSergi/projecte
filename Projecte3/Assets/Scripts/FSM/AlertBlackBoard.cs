using UnityEngine;
using System.Collections;
namespace FSM
{
    public class AlertBlackBoard : MonoBehaviour
    {

        // Use this for initialization
        public GameObject HideShowGO;
        [HideInInspector]
        public FSM_ShowHideImage FSM_ShowHideImage;
        private void Awake()
        {
            FSM_ShowHideImage = HideShowGO.AddComponent<FSM_ShowHideImage>();
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