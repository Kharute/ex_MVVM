using System;
using System.Collections.Generic;


/// <summary>
/// Model : 데이터를 통괄하여 가지고 있는 곳.
///         ViewModel에서 접근하기 때문에 Callback을 가지고 있으며
///         CallBack은 이벤트형식의 개념,
///         실제로 전달하는 값은 별개로 선언한 메소드에 값을 담아
///         Callback이 받고 전달하는 식으로 구성할 수 있다.
///         해당 구성은 Action이 이벤트 전달방식을 가지고 있으며,
///         다른 값을 호출하고 싶은 경우, 이벤트를 추가하여 구성하도록 만들어 줄 것.
/// </summary>
public class Player
{
    public Player(int userId, string name)
    {
        UserId = userId;
        Name = name;
        Level = 0;
    }

    public int UserId { get; private set; }
    public string Name { get; set; }
    public int Level { get; set; }
}

// ID를 미리 선택하면 RefreshViewModel()에서 변경 가능

public class GameLogicManager
{
    private static GameLogicManager _instance = null;
    private int _curSelectedPlayerId = 0;

    private static Dictionary<int, Player> _playerDic = new Dictionary<int, Player>();
    private Action<int, int> _levelUpCallback;
    private Action<int, string> _nameChangeCallback;

    public static GameLogicManager Inst
    {
        get
        {
            if(_instance == null)
            {
                _instance = new GameLogicManager();
                TempInitPlayerList();
            }
            return _instance;
        }
    }

    public static void TempInitPlayerList()
    {
        _playerDic.Add(1, new Player(1, "죠스바"));
        _playerDic.Add(2, new Player(2, "쌍쌍바"));
        _playerDic.Add(3, new Player(3, "바밤바"));
    }

    public void RegisterLevelUpCallback(Action<int, int> levelupCallback)
    {
        _levelUpCallback += levelupCallback;
    }

    public void UnRegisterLevelUpCallback(Action<int, int> levelupCallback)
    {
        _levelUpCallback -= levelupCallback;
    }

    public void Register_NameChangeCallback(Action<int, string> NameChangeCallback)
    {
        _nameChangeCallback += NameChangeCallback;
    }

    public void UnRegister_NameChangeCallback(Action<int, string> NameChangeCallback)
    {
        _nameChangeCallback -= NameChangeCallback;
    }


    public void RequestLevelUp()
    {
        int reqUserId = _curSelectedPlayerId;

        if (_playerDic.ContainsKey(reqUserId))
        {
            var curPlayer = _playerDic[reqUserId];
            curPlayer.Level++;
            _levelUpCallback.Invoke(reqUserId, curPlayer.Level);
        }
    }
    public void RequestLevelUpDouble()
    {
        int reqUserId = _curSelectedPlayerId;

        if (_playerDic.ContainsKey(reqUserId))
        {
            var curPlayer = _playerDic[reqUserId];
            curPlayer.Level += 2;
            _levelUpCallback.Invoke(reqUserId, curPlayer.Level);
        }
    }

    public void RequestChangeName(string name)
    {
        int reqUserId = _curSelectedPlayerId;

        if (_playerDic.ContainsKey(reqUserId))
        {
            var curPlayer = _playerDic[reqUserId];
            curPlayer.Name = name;
            _nameChangeCallback.Invoke(reqUserId, curPlayer.Name);
        }
    }

    public void RefreshCharacterInfo(int requestId, Action<int, string, int> callback)
    {
        _curSelectedPlayerId = requestId;
        if (_playerDic.ContainsKey(requestId))
        {
            var curPlayer = _playerDic[requestId];
            callback.Invoke(curPlayer.UserId, curPlayer.Name, curPlayer.Level);
        }
    }
}
