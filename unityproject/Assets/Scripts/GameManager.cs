using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { Running, Paused, GameOver };

public class GameManager : MonoBehaviour {

    GameState _state;
    public GameState state {
        get { return _state; }
        set {
            if (value == _state)
                Debug.LogError("Tried to re-enter same gamestate " + value);
            else if (value == GameState.Paused)
                Debug.LogError("Pause not implemented yet");
            else if (value == GameState.GameOver)
                GameOver();       
        }
    }

    void GameOver() {

    }
}
