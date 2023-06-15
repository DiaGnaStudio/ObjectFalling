using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DiaGna.ObjectFalling.UserInterface.Tools;

namespace DiaGna.ObjectFalling
{
    public class SFXPlayer : MonoBehaviour
    {
        public static SFXPlayer Instance { get; private set; }
        
        [SerializeField] private List<SfxList> sfxSetting = new List<SfxList>();
        private bool isCranePlaying;
        
        [Serializable]
        private struct SfxList
        {
            public SfxType sfxType;
            public SFXManager sfxManager;
        }

        private void OnEnable()
        {
            //MoverJoystick.OnDrag += PlayCraveMover;
            MoverJoystick.OnPointerUp += PlayDropCube;
            //MoverJoystick.OnPointerUp += StopCraveMover;
        }
        
        private void Awake()
        {
            if (!Instance)
                Instance = this;
            else
                Destroy(gameObject);
        }

        public void PlaySFX(SfxType sfxType, bool loop = false)
        {
            foreach (var sfx in sfxSetting)
            {
                if (sfx.sfxType == sfxType)
                    sfx.sfxManager.SfxPlay(false, -1, loop);
            }
        }
        public void StopSFX(SfxType sfxType)
        {
            foreach (var sfx in sfxSetting)
            {
                if (sfx.sfxType == sfxType)
                    sfx.sfxManager.SfxPlayDefault();
            }
        }

        public void PlayCraveMover(Vector2 vector)
        {
            if (!isCranePlaying)
            {
                PlaySFX(SfxType.CraneMover, true);
                isCranePlaying = true;
            }
        }  
        
        public void StopCraveMover()
        {
            StopSFX(SfxType.CraneMover);
            isCranePlaying = false;
        } 
        private void PlayDropCube()
        {
            PlaySFX(SfxType.CraneMover);
        } 
        
        private void PlayGroundCollision()
        {
            PlaySFX(SfxType.CraneMover);
        }
    }

    [Serializable]
    public enum SfxType
    {
        CraneMover,
        GroundCollision,
        GroundRotator,
        DropCube,
        SuckingIn,
        Win,
        Lose,
    }
}
