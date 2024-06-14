using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using ViewModel.Extensions.PT;

public class TempProfileUI : MonoBehaviour
{
    [SerializeField]
    InputField InputField;

    [SerializeField] Text Text_Name;
    [SerializeField] Text Text_Level;

    private TempProfileViewModel _vm;

    private void OnEnable()
    {
        if (_vm == null)
        {
            _vm = new TempProfileViewModel();
            _vm.PropertyChanged += OnPropertyChanged;
            _vm.RegisterEventsOnEnable();
            _vm.RefreshViewModel();
        }
    }

    private void OnDisable()
    {
        if (_vm != null)
        {
            _vm.UnRegisterOnDisable();
            _vm.PropertyChanged -= OnPropertyChanged;
            _vm = null;
        }
    }

    private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case nameof(_vm.Name):
                Text_Name.text = $"이름 : {_vm.Name}";
                break;
            case nameof(_vm.Level):
                Text_Level.text = $"레벨 : {_vm.Level}";
                break;
        }
    }


    public void OnClick_ChangeName()
    {
        GameLogicManager.Inst.RequestChangeName(InputField.text);
    }
}
