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
using Invert.StateMachine;


public class FPSShooterGamePlayBase : Invert.StateMachine.StateMachine {
    
    private StateMachineTrigger _WaveComplete;
    
    private StateMachineTrigger _PlayerDied;
    
    private StateMachineTrigger _OnRetry;
    
    private StateMachineTrigger _NextWaveReady;
    
    private Wave _Wave;
    
    private GameOver _GameOver;
    
    private WaitForNextWave _WaitForNextWave;
    
    public FPSShooterGamePlayBase(ViewModel vm, string propertyName) : 
            base(vm, propertyName) {
    }
    
    public virtual StateMachineTrigger WaveComplete {
        get {
            if ((this._WaveComplete == null)) {
                this._WaveComplete = new StateMachineTrigger(this, "WaveComplete");
            }
            return this._WaveComplete;
        }
    }
    
    public virtual StateMachineTrigger PlayerDied {
        get {
            if ((this._PlayerDied == null)) {
                this._PlayerDied = new StateMachineTrigger(this, "PlayerDied");
            }
            return this._PlayerDied;
        }
    }
    
    public virtual StateMachineTrigger OnRetry {
        get {
            if ((this._OnRetry == null)) {
                this._OnRetry = new StateMachineTrigger(this, "OnRetry");
            }
            return this._OnRetry;
        }
    }
    
    public virtual StateMachineTrigger NextWaveReady {
        get {
            if ((this._NextWaveReady == null)) {
                this._NextWaveReady = new StateMachineTrigger(this, "NextWaveReady");
            }
            return this._NextWaveReady;
        }
    }
    
    public override Invert.StateMachine.State StartState {
        get {
            return this.WaitForNextWave;
        }
    }
    
    public virtual Wave Wave {
        get {
            if ((this._Wave == null)) {
                this._Wave = new Wave();
            }
            return this._Wave;
        }
    }
    
    public virtual GameOver GameOver {
        get {
            if ((this._GameOver == null)) {
                this._GameOver = new GameOver();
            }
            return this._GameOver;
        }
    }
    
    public virtual WaitForNextWave WaitForNextWave {
        get {
            if ((this._WaitForNextWave == null)) {
                this._WaitForNextWave = new WaitForNextWave();
            }
            return this._WaitForNextWave;
        }
    }
    
    public override void Compose(List<State> states) {
        base.Compose(states);
        this.Wave.StateMachine = this;
        Wave.WaveComplete = new StateTransition("WaveComplete", Wave,WaitForNextWave);
        Wave.PlayerDied = new StateTransition("PlayerDied", Wave,GameOver);
        Wave.AddTrigger(WaveComplete, Wave.WaveComplete);
        Wave.AddTrigger(PlayerDied, Wave.PlayerDied);
        states.Add(Wave);
        this.GameOver.StateMachine = this;
        GameOver.OnRetry = new StateTransition("OnRetry", GameOver,WaitForNextWave);
        GameOver.AddTrigger(OnRetry, GameOver.OnRetry);
        states.Add(GameOver);
        this.WaitForNextWave.StateMachine = this;
        WaitForNextWave.NextWaveReady = new StateTransition("NextWaveReady", WaitForNextWave,Wave);
        WaitForNextWave.AddTrigger(NextWaveReady, WaitForNextWave.NextWaveReady);
        states.Add(WaitForNextWave);
    }
}

public class Wave : Invert.StateMachine.State {
    
    private StateTransition _WaveComplete;
    
    private StateTransition _PlayerDied;
    
    public virtual StateTransition WaveComplete {
        get {
            return this._WaveComplete;
        }
        set {
            _WaveComplete = value;
        }
    }
    
    public virtual StateTransition PlayerDied {
        get {
            return this._PlayerDied;
        }
        set {
            _PlayerDied = value;
        }
    }
    
    public override string Name {
        get {
            return "Wave";
        }
    }
    
    private void WaveCompleteTransition() {
        this.Transition(this.WaveComplete);
    }
    
    private void PlayerDiedTransition() {
        this.Transition(this.PlayerDied);
    }
}

public class GameOver : Invert.StateMachine.State {
    
    private StateTransition _OnRetry;
    
    public virtual StateTransition OnRetry {
        get {
            return this._OnRetry;
        }
        set {
            _OnRetry = value;
        }
    }
    
    public override string Name {
        get {
            return "GameOver";
        }
    }
    
    private void OnRetryTransition() {
        this.Transition(this.OnRetry);
    }
}

public class WaitForNextWave : Invert.StateMachine.State {
    
    private StateTransition _NextWaveReady;
    
    public virtual StateTransition NextWaveReady {
        get {
            return this._NextWaveReady;
        }
        set {
            _NextWaveReady = value;
        }
    }
    
    public override string Name {
        get {
            return "WaitForNextWave";
        }
    }
    
    private void NextWaveReadyTransition() {
        this.Transition(this.NextWaveReady);
    }
}
