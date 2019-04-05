// GENERATED AUTOMATICALLY FROM 'Assets/InputSystemNew/MasterInputs.inputactions'

using System;
using UnityEngine;
using UnityEngine.Experimental.Input;


[Serializable]
public class MasterInputs : InputActionAssetReference
{
    public MasterInputs()
    {
    }
    public MasterInputs(InputActionAsset asset)
        : base(asset)
    {
    }
    private bool m_Initialized;
    private void Initialize()
    {
        // GamePlay
        m_GamePlay = asset.GetActionMap("GamePlay");
        m_GamePlay_Movement = m_GamePlay.GetAction("Movement");
        m_Initialized = true;
    }
    private void Uninitialize()
    {
        m_GamePlay = null;
        m_GamePlay_Movement = null;
        m_Initialized = false;
    }
    public void SetAsset(InputActionAsset newAsset)
    {
        if (newAsset == asset) return;
        if (m_Initialized) Uninitialize();
        asset = newAsset;
    }
    public override void MakePrivateCopyOfActions()
    {
        SetAsset(ScriptableObject.Instantiate(asset));
    }
    // GamePlay
    private InputActionMap m_GamePlay;
    private InputAction m_GamePlay_Movement;
    public struct GamePlayActions
    {
        private MasterInputs m_Wrapper;
        public GamePlayActions(MasterInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement { get { return m_Wrapper.m_GamePlay_Movement; } }
        public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
    }
    public GamePlayActions @GamePlay
    {
        get
        {
            if (!m_Initialized) Initialize();
            return new GamePlayActions(this);
        }
    }
    private int m_PS4SchemeIndex = -1;
    public InputControlScheme PS4Scheme
    {
        get

        {
            if (m_PS4SchemeIndex == -1) m_PS4SchemeIndex = asset.GetControlSchemeIndex("PS4");
            return asset.controlSchemes[m_PS4SchemeIndex];
        }
    }
    private int m_keyboardSchemeIndex = -1;
    public InputControlScheme keyboardScheme
    {
        get

        {
            if (m_keyboardSchemeIndex == -1) m_keyboardSchemeIndex = asset.GetControlSchemeIndex("keyboard");
            return asset.controlSchemes[m_keyboardSchemeIndex];
        }
    }
}
