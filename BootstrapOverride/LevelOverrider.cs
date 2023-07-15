using System;
using BootstrapOverride.Managers;
using MelonLoader;
using Ninject;
using SLZ.Bonelab;
using SLZ.Marrow.Warehouse;
using UnhollowerBaseLib.Attributes;
using UnityEngine;

namespace BootstrapOverride
{
    [RegisterTypeInIl2Cpp]
    public class LevelOverrider : MonoBehaviour
    {
        private SceneBootstrapper_Bonelab _sceneBootstrapper = null!;
        private LevelCrateManager _levelCrateManager = null!;
        
        public LevelOverrider(IntPtr ptr) : base(ptr)
        {
        }

        [Inject]
        [HideFromIl2Cpp]
        public void Initializer(SceneBootstrapper_Bonelab sceneBootstrapper, LevelCrateManager levelCrateManager)
        {
            _sceneBootstrapper = sceneBootstrapper;
            _levelCrateManager = levelCrateManager;
        }

        private void Start()
        {
            AssetWarehouse.OnReady((Action)(() =>
            {
                LevelCrateReference overrideLevel = _levelCrateManager.GetOverrideLevel();
            
                _sceneBootstrapper.MenuHollowCrateRef = overrideLevel;
                _sceneBootstrapper.VoidG114CrateRef = overrideLevel;
            
                Destroy(gameObject); // No longer need this to exist.
            }));
        }
    }
}
