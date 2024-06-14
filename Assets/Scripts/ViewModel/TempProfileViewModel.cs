using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using ViewModel;

public class TempProfileViewModel : ViewModelBase
{
    private int _userId;
    private string _name;
    private int _level;
    private int _hp;

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
            // ��� ������ ���Ѿ��� ���� ���ָ� �ȴ�.
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
            if (_level == value)
                return;

            _level = value;
            OnPropertyChanged(nameof(Level));
        }
    }

    public int HP
    {
        get { return _hp; }
        set
        {
            // ��� ������ ���Ѿ��� ���� ���ָ� �ȴ�.
            if (_hp == value) return;

            _hp = value;
            OnPropertyChanged(nameof(HP));
        }
    }
}
