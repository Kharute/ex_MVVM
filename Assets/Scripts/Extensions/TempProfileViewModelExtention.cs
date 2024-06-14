using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ViewModel.Extensions.PT
{
    public static class TempProfileViewModelExtention
    {
        public static void RefreshViewModel(this TempProfileViewModel vm)
        {
            int tempId = 2;
            GameLogicManager.Inst.RefreshCharacterInfo(tempId, vm.OnRefreshViewModel);
        }

        public static void OnRefreshViewModel(this TempProfileViewModel vm, int userId, string name, int level, int hp)
        {
            vm.UserId = userId;
            vm.Name = name;
            vm.Level = level;
            vm.HP = hp;
        }

        public static void RegisterEventsOnEnable(this TempProfileViewModel vm)
        {
            GameLogicManager.Inst.RegisterLevelUpCallback(vm.OnResponseLevelUp);
            GameLogicManager.Inst.Register_NameChangeCallback(vm.OnResponseNameChange);
            GameLogicManager.Inst.Register_HPChangeCallback(vm.OnResponseHPChange);
        }
        public static void UnRegisterOnDisable(this TempProfileViewModel vm)
        {
            GameLogicManager.Inst.UnRegisterLevelUpCallback(vm.OnResponseLevelUp);
            GameLogicManager.Inst.UnRegister_NameChangeCallback(vm.OnResponseNameChange);
        }
        public static void OnResponseLevelUp(this TempProfileViewModel vm, int userId, int level)
        {
            if (vm.UserId != userId)
                return;

            vm.Level = level;
        }

        public static void OnResponseNameChange(this TempProfileViewModel vm, int userId, string name)
        {
            if (vm.UserId != userId)
                return;

            vm.Name = name;
        }

        public static void OnResponseHPChange(this TempProfileViewModel vm, int userId, int hp)
        {
            if (vm.UserId != userId)
                return;

            vm.HP = hp;
        }
    }

}
