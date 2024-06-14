using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Extention : 기존 클래스에 새로운 메서드를 추가하여 사용할 수 있도록 하는 기능
///             this 한정자를 맨 앞 파라미터에 선언하여 정적 메소드 처럼 사용 가능하다.
///             Callback 메소드의 인풋파라미터는 수와 변수명이 항상 일치해야 하며
///             Callback을 통한 값 전달을 이루게 할 수 있다.
/// </summary>

public static class TopLeftModelExtention
{
    public static void RefreshViewModel(this TopLeftViewModel vm)
    {
        int tempId = 2;
        //GameLogicManager.Inst.RefreshCharacterInfo(tempId, vm.OnRefreshViewModel);
    }

    public static void OnRefreshViewModel(this TopLeftViewModel vm, int userId, string name, int level)
    {
        vm.UserId = userId;
        vm.Name = name;
        vm.Level = level;
    }

    public static void RegisterEventsOnEnable(this TopLeftViewModel vm)
    {
        GameLogicManager.Inst.RegisterLevelUpCallback(vm.OnResponseLevelUp);
        GameLogicManager.Inst.Register_NameChangeCallback(vm.OnResponseNameChange);
    }
    public static void UnRegisterOnDisable(this TopLeftViewModel vm)
    {
        GameLogicManager.Inst.UnRegisterLevelUpCallback(vm.OnResponseLevelUp);
        GameLogicManager.Inst.UnRegister_NameChangeCallback(vm.OnResponseNameChange);
    }

    public static void OnResponseLevelUp(this TopLeftViewModel vm, int userId, int level)
    {
        if (vm.UserId != userId)
            return;

        vm.Level = level;
    }

    public static void OnResponseNameChange(this TopLeftViewModel vm, int userId, string name)
    {
        if (vm.UserId != userId)
            return;

        vm.Name = name;
    }
}
