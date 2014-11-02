// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;


[System.SerializableAttribute()]
public sealed partial class FPSMainMenuManagerSettings {
    
    public string[] _Scenes;
}

// <summary>
// The responsibility of this class is to manage the scenes Initialization, Loading, Transitioning, and Unloading.
// </summary>
public class FPSMainMenuManagerBase : SceneManager {
    
    public WavesFPSGameManagerSettings _PlayTransition = new WavesFPSGameManagerSettings();
    
    private FPSMenuViewModel _FPSMenu;
    
    private FPSPlayerViewModel _LocalPlayer;
    
    private FPSGameViewModel _FPSGame;
    
    private FPSMenuController _FPSMenuController;
    
    private FPSDamageableController _FPSDamageableController;
    
    private FPSEnemyController _FPSEnemyController;
    
    private FPSGameController _FPSGameController;
    
    private FPSPlayerController _FPSPlayerController;
    
    private FPSWeaponController _FPSWeaponController;
    
    public FPSMainMenuManagerSettings _FPSMainMenuManagerSettings = new FPSMainMenuManagerSettings();
    
    [Inject("FPSMenu")]
    public virtual FPSMenuViewModel FPSMenu {
        get {
            if ((this._FPSMenu == null)) {
                this._FPSMenu = CreateInstanceViewModel<FPSMenuViewModel>(FPSMenuController, "FPSMenu");
            }
            return this._FPSMenu;
        }
        set {
            _FPSMenu = value;
        }
    }
    
    [Inject("LocalPlayer")]
    public virtual FPSPlayerViewModel LocalPlayer {
        get {
            if ((this._LocalPlayer == null)) {
                this._LocalPlayer = CreateInstanceViewModel<FPSPlayerViewModel>(FPSPlayerController, "LocalPlayer");
            }
            return this._LocalPlayer;
        }
        set {
            _LocalPlayer = value;
        }
    }
    
    [Inject("FPSGame")]
    public virtual FPSGameViewModel FPSGame {
        get {
            if ((this._FPSGame == null)) {
                this._FPSGame = CreateInstanceViewModel<FPSGameViewModel>(FPSGameController, "FPSGame");
            }
            return this._FPSGame;
        }
        set {
            _FPSGame = value;
        }
    }
    
    [Inject()]
    public virtual FPSMenuController FPSMenuController {
        get {
            if ((this._FPSMenuController == null)) {
                this._FPSMenuController = new FPSMenuController() { Container = Container };
            }
            return this._FPSMenuController;
        }
        set {
            _FPSMenuController = value;
        }
    }
    
    [Inject()]
    public virtual FPSDamageableController FPSDamageableController {
        get {
            if ((this._FPSDamageableController == null)) {
                this._FPSDamageableController = new FPSDamageableController() { Container = Container };
            }
            return this._FPSDamageableController;
        }
        set {
            _FPSDamageableController = value;
        }
    }
    
    [Inject()]
    public virtual FPSEnemyController FPSEnemyController {
        get {
            if ((this._FPSEnemyController == null)) {
                this._FPSEnemyController = new FPSEnemyController() { Container = Container };
            }
            return this._FPSEnemyController;
        }
        set {
            _FPSEnemyController = value;
        }
    }
    
    [Inject()]
    public virtual FPSGameController FPSGameController {
        get {
            if ((this._FPSGameController == null)) {
                this._FPSGameController = new FPSGameController() { Container = Container };
            }
            return this._FPSGameController;
        }
        set {
            _FPSGameController = value;
        }
    }
    
    [Inject()]
    public virtual FPSPlayerController FPSPlayerController {
        get {
            if ((this._FPSPlayerController == null)) {
                this._FPSPlayerController = new FPSPlayerController() { Container = Container };
            }
            return this._FPSPlayerController;
        }
        set {
            _FPSPlayerController = value;
        }
    }
    
    [Inject()]
    public virtual FPSWeaponController FPSWeaponController {
        get {
            if ((this._FPSWeaponController == null)) {
                this._FPSWeaponController = new FPSWeaponController() { Container = Container };
            }
            return this._FPSWeaponController;
        }
        set {
            _FPSWeaponController = value;
        }
    }
    
    // <summary>
    // This method is the first method to be invoked when the scene first loads. Anything registered here with 'Container' will effectively 
    // be injected on controllers, and instances defined on a subsystem.And example of this would be Container.RegisterInstance<IDataRepository>(new CodeRepository()). Then any property with 
    // the 'Inject' attribute on any controller or view-model will automatically be set by uFrame. 
    // </summary>
    public override void Setup() {
        base.Setup();
        Container.RegisterViewModel<FPSMenuViewModel>(FPSMenu,"FPSMenu");
        Container.RegisterViewModel<FPSPlayerViewModel>(LocalPlayer,"LocalPlayer");
        Container.RegisterViewModel<FPSGameViewModel>(FPSGame,"FPSGame");
        Container.RegisterController<FPSMenuController>(FPSMenuController);
        Container.RegisterController<FPSDamageableController>(FPSDamageableController);
        Container.RegisterController<FPSEnemyController>(FPSEnemyController);
        Container.RegisterController<FPSGameController>(FPSGameController);
        Container.RegisterController<FPSPlayerController>(FPSPlayerController);
        Container.RegisterController<FPSWeaponController>(FPSWeaponController);
        this.Container.InjectAll();
        FPSMenuController.Initialize(FPSMenu);
        FPSPlayerController.Initialize(LocalPlayer);
        FPSGameController.Initialize(FPSGame);
    }
    
    public virtual void PlayTransitionComplete(WavesFPSGameManager sceneManager) {
    }
    
    public virtual System.Collections.Generic.IEnumerable<string> GetPlayScenes() {
        return this._PlayTransition._Scenes;
    }
    
    public virtual void Play() {
        GameManager.TransitionLevel<WavesFPSGameManager>((container) =>{container._WavesFPSGameManagerSettings = _PlayTransition; PlayTransitionComplete(container); }, this.GetPlayScenes().ToArray());
    }
    
    public override void Initialize() {
        base.Initialize();
        FPSMenu.Play.Subscribe(_=> Play()).DisposeWith(this.gameObject);
    }
}

[System.SerializableAttribute()]
public sealed partial class WavesFPSGameManagerSettings {
    
    public string[] _Scenes;
}

// <summary>
// The responsibility of this class is to manage the scenes Initialization, Loading, Transitioning, and Unloading.
// </summary>
public class WavesFPSGameManagerBase : SceneManager {
    
    public FPSMainMenuManagerSettings _MainMenuTransition = new FPSMainMenuManagerSettings();
    
    public FPSMainMenuManagerSettings _QuitGameTransition = new FPSMainMenuManagerSettings();
    
    private WavesFPSGameViewModel _FPSGame;
    
    private FPSPlayerViewModel _LocalPlayer;
    
    private WavesFPSGameController _WavesFPSGameController;
    
    private FPSDamageableController _FPSDamageableController;
    
    private FPSEnemyController _FPSEnemyController;
    
    private FPSGameController _FPSGameController;
    
    private FPSPlayerController _FPSPlayerController;
    
    private FPSWeaponController _FPSWeaponController;
    
    public WavesFPSGameManagerSettings _WavesFPSGameManagerSettings = new WavesFPSGameManagerSettings();
    
    [Inject("FPSGame")]
    public virtual WavesFPSGameViewModel FPSGame {
        get {
            if ((this._FPSGame == null)) {
                this._FPSGame = CreateInstanceViewModel<WavesFPSGameViewModel>(WavesFPSGameController, "FPSGame");
            }
            return this._FPSGame;
        }
        set {
            _FPSGame = value;
        }
    }
    
    [Inject("LocalPlayer")]
    public virtual FPSPlayerViewModel LocalPlayer {
        get {
            if ((this._LocalPlayer == null)) {
                this._LocalPlayer = CreateInstanceViewModel<FPSPlayerViewModel>(FPSPlayerController, "LocalPlayer");
            }
            return this._LocalPlayer;
        }
        set {
            _LocalPlayer = value;
        }
    }
    
    [Inject()]
    public virtual WavesFPSGameController WavesFPSGameController {
        get {
            if ((this._WavesFPSGameController == null)) {
                this._WavesFPSGameController = new WavesFPSGameController() { Container = Container };
            }
            return this._WavesFPSGameController;
        }
        set {
            _WavesFPSGameController = value;
        }
    }
    
    [Inject()]
    public virtual FPSDamageableController FPSDamageableController {
        get {
            if ((this._FPSDamageableController == null)) {
                this._FPSDamageableController = new FPSDamageableController() { Container = Container };
            }
            return this._FPSDamageableController;
        }
        set {
            _FPSDamageableController = value;
        }
    }
    
    [Inject()]
    public virtual FPSEnemyController FPSEnemyController {
        get {
            if ((this._FPSEnemyController == null)) {
                this._FPSEnemyController = new FPSEnemyController() { Container = Container };
            }
            return this._FPSEnemyController;
        }
        set {
            _FPSEnemyController = value;
        }
    }
    
    [Inject()]
    public virtual FPSGameController FPSGameController {
        get {
            if ((this._FPSGameController == null)) {
                this._FPSGameController = new FPSGameController() { Container = Container };
            }
            return this._FPSGameController;
        }
        set {
            _FPSGameController = value;
        }
    }
    
    [Inject()]
    public virtual FPSPlayerController FPSPlayerController {
        get {
            if ((this._FPSPlayerController == null)) {
                this._FPSPlayerController = new FPSPlayerController() { Container = Container };
            }
            return this._FPSPlayerController;
        }
        set {
            _FPSPlayerController = value;
        }
    }
    
    [Inject()]
    public virtual FPSWeaponController FPSWeaponController {
        get {
            if ((this._FPSWeaponController == null)) {
                this._FPSWeaponController = new FPSWeaponController() { Container = Container };
            }
            return this._FPSWeaponController;
        }
        set {
            _FPSWeaponController = value;
        }
    }
    
    // <summary>
    // This method is the first method to be invoked when the scene first loads. Anything registered here with 'Container' will effectively 
    // be injected on controllers, and instances defined on a subsystem.And example of this would be Container.RegisterInstance<IDataRepository>(new CodeRepository()). Then any property with 
    // the 'Inject' attribute on any controller or view-model will automatically be set by uFrame. 
    // </summary>
    public override void Setup() {
        base.Setup();
        Container.RegisterViewModel<WavesFPSGameViewModel>(FPSGame,"FPSGame");
        Container.RegisterViewModel<FPSGameViewModel>(FPSGame,"FPSGame");
        Container.RegisterViewModel<FPSPlayerViewModel>(LocalPlayer,"LocalPlayer");
        Container.RegisterController<WavesFPSGameController>(WavesFPSGameController);
        Container.RegisterController<FPSDamageableController>(FPSDamageableController);
        Container.RegisterController<FPSEnemyController>(FPSEnemyController);
        Container.RegisterController<FPSGameController>(FPSGameController);
        Container.RegisterController<FPSPlayerController>(FPSPlayerController);
        Container.RegisterController<FPSWeaponController>(FPSWeaponController);
        this.Container.InjectAll();
        WavesFPSGameController.Initialize(FPSGame);
        FPSPlayerController.Initialize(LocalPlayer);
    }
    
    public virtual void MainMenuTransitionComplete(FPSMainMenuManager sceneManager) {
    }
    
    public virtual System.Collections.Generic.IEnumerable<string> GetMainMenuScenes() {
        return this._MainMenuTransition._Scenes;
    }
    
    public virtual void MainMenu() {
        GameManager.TransitionLevel<FPSMainMenuManager>((container) =>{container._FPSMainMenuManagerSettings = _MainMenuTransition; MainMenuTransitionComplete(container); }, this.GetMainMenuScenes().ToArray());
    }
    
    public virtual void QuitGameTransitionComplete(FPSMainMenuManager sceneManager) {
    }
    
    public virtual System.Collections.Generic.IEnumerable<string> GetQuitGameScenes() {
        return this._QuitGameTransition._Scenes;
    }
    
    public virtual void QuitGame() {
        GameManager.TransitionLevel<FPSMainMenuManager>((container) =>{container._FPSMainMenuManagerSettings = _QuitGameTransition; QuitGameTransitionComplete(container); }, this.GetQuitGameScenes().ToArray());
    }
    
    public override void Initialize() {
        base.Initialize();
        FPSGame.MainMenu.Subscribe(_=> MainMenu()).DisposeWith(this.gameObject);
        FPSGame.QuitGame.Subscribe(_=> QuitGame()).DisposeWith(this.gameObject);
    }
}
