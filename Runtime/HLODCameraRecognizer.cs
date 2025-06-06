using System;
using UnityEngine;

namespace Unity.HLODSystem
{
    public class HLODCameraRecognizer : MonoBehaviour
    {
        private static HLODCameraRecognizer s_instance;
        private static Camera s_recognizedCamera;
        private static Transform s_recognizedCameraTrans;
        public static HLODCameraRecognizer Instance => s_instance;
        public static Camera RecognizedCamera => s_recognizedCamera;
        public static Transform RecognizedCameraTrans => s_recognizedCameraTrans;

        [SerializeField]
        private int m_id;
        [SerializeField]
        private int m_priority;


        public int ID
        {
            get
            {
                return m_id;
            }
        }

        public int Priority
        {
            get
            {
                return m_priority;
            }
        }
        
        

        private void Awake()
        {
            s_instance = this;
            s_recognizedCamera = GetComponent<Camera>();
            s_recognizedCameraTrans = GetComponent<Transform>();
        }
        private void OnEnable()
        {
            HLODCameraRecognizerManager.Instance.RegisterRecognizer(this);
        }

        private void OnDisable()
        {
            HLODCameraRecognizerManager.Instance.UnregisterRecognizer(this);            
        }


#if UNITY_EDITOR
        public bool moveWithEditorCam;
        private void Update()
        {
            if (moveWithEditorCam && UnityEditor.SceneView.lastActiveSceneView != null)
            {
                var trans = UnityEditor.SceneView.lastActiveSceneView.camera.transform;
                s_recognizedCameraTrans.SetPositionAndRotation(trans.position, trans.rotation);
            }
        }
#endif

        public void Active()
        {
            if (enabled == false)
            {
                s_instance = null;
                s_recognizedCamera = null;
                s_recognizedCameraTrans = null;
            }

            HLODCameraRecognizerManager.Instance.Active(this);
        }
    }
}