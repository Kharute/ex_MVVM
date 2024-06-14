using System.ComponentModel;
using UnityEngine;


/// <summary>
/// ViewModel : Model에 직접 접근하고 결과값을 받음.
///             이벤트만 깔아주면 UI가 알아서 들고가기 때문에, 해당 이벤트만 추가적으로 설치해준다.
///             (PropChanged)
/// </summary>

public class TopLeftViewModel : MonoBehaviour
{
    private int _userId;
    private string _name;
    private int _level;
    private string _iconName;

    public int UserId
    {
        get { return _userId; }
        set { _userId = value; }
    }

    public string Name
    {
        get { return _name; }
        set
        {
            // 계속 갱신을 시켜야할 때는 빼주면 된다.
            if (_name == value) return;

            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }
    public int Level
    { 
        get { return _level; }
        set
        {
            if (_level == value) return;

            _level = value;
            OnPropertyChanged(nameof(Level));
        }
    }

    public string IconName
    {
        get { return _iconName; }
        set
        {
            if (_iconName == value) return;

            _iconName = value;
            OnPropertyChanged(nameof(_iconName));
        }
    }

    // 데이터 바인딩 : 알아서 변경해주세요.
    #region PropChanged

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion 
}

