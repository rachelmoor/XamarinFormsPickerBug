using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

using Xamarin.Forms;

namespace TestPickerBug.ViewModels
{

  public class AboutViewModel : BaseViewModel
  {
    public PickerData ColorsObject { get; set; }

    public PickerData AlphaBetObject { get; set; }

    public PickerViewModel TestViewModel { get; set;}

    public ObservableCollection<string> ListOfDataItems { get; set; }
      = new ObservableCollection<string> {"alphabet", "colors"};

    private string selectedDataItem = "colors";

    public string SelectedDataItem
    {
      get => selectedDataItem;
      set
      {
        selectedDataItem = value;
        if (value == null || TestViewModel == null)
          return;

        TestViewModel.DataItem = selectedDataItem.Equals("alphabet") ? AlphaBetObject : ColorsObject;
      }
    }

    public AboutViewModel()
    {
      Title = "About";

      ColorsObject = new PickerData
      {
        PickerListData = new List<string> { "red", "orange", "yellow" },
      SelectedItem = "red",
      };

      AlphaBetObject = new PickerData
      {
        PickerListData = new List<string> { "a", "b", "c" },
      SelectedItem = "b",
      };

      TestViewModel = new PickerViewModel
      {
        DataItem = ColorsObject,
      };
    }
  }

  public class PickerData : BindableObject
  {
    private List<string> pickerListData;

    public List<string> PickerListData
    {
      get => pickerListData;
      set
      {
        this.pickerListData = value;
        this.OnPropertyChanged();
      }
    }

    private string selectedItem;

    public string SelectedItem
    {
      get => selectedItem;
      set
      {
        this.selectedItem = value;
        this.OnPropertyChanged();
      }
    }
  }

  public class PickerViewModel : BindableObject
  {

    private PickerData dataItem;

    public PickerData DataItem
    {
      get => dataItem;
      set
      {
        dataItem = value;

        if (dataItem != null)
        {
          DisplayStrings = dataItem.PickerListData;
          SelectedItem = dataItem.SelectedItem;
        }
        this.OnPropertyChanged();
      }
    }

    private List<string> displayStrings;

    public List<string> DisplayStrings
    {
      get => displayStrings;
      set
      {
        displayStrings = value;
        this.OnPropertyChanged();
      }
    }

    private string selectedItem;

    public string SelectedItem
    {
      get => selectedItem;
      set
      {
        selectedItem = value;
        this.OnPropertyChanged();
      }
    }
  }
}