using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Extention : ���� Ŭ������ ���ο� �޼��带 �߰��Ͽ� ����� �� �ֵ��� �ϴ� ���
///             this �����ڸ� �� �� �Ķ���Ϳ� �����Ͽ� ���� �޼ҵ� ó�� ��� �����ϴ�.
///             Callback �޼ҵ��� ��ǲ�Ķ���ʹ� ���� �������� �׻� ��ġ�ؾ� �ϸ�
///             Callback�� ���� �� ������ �̷�� �� �� �ִ�.
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
