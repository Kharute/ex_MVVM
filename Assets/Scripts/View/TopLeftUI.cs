using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using ViewModel.Extensions.PT;

/// <summary>
/// View : 보여줄 수 있는 파트를 담당.
///        ViewModel을 가지고 있으며, LogicManager에서 직접적인 정보를 받지 않는다.
///        ViewModel이 갱신될 때, 이벤트로 요청 받아 변경된다.(OnPropertyChanged)
/// </summary>
public class TopLeftUI : MonoBehaviour
{
    [SerializeField] Text Text_Name;
    [SerializeField] Text Text_level;
    [SerializeField] Image Image_Icon;

    // 뷰모델을 들고있게 된다.
    private TempProfileViewModel _vm;

    private void OnEnable()
    {
        if(_vm == null)
        {
            _vm = new TempProfileViewModel();
            _vm.PropertyChanged += OnPropertyChanged;
            _vm.RegisterEventsOnEnable();
            _vm.RefreshViewModel();
        }
    }

    private void OnDisable()
    {
        if(_vm != null)
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
                Text_level.text = $"레벨 : {_vm.Level}";
                break;
        }
    }    
}
