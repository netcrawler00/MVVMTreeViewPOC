namespace TreeViewPOC.Gui
{
  internal class ConstellationTreeViewModel : ObservableObject
  {
    private bool _isSelected;

    public ConstellationTreeViewModel()
    {
    }

    public object Constellation { get; internal set; }

    public string FontWeight { get; } = "Bold";

    public bool IsSelected
    {
      get
      {
        return _isSelected;
      }
      set
      {
        if(_isSelected != value)
        {
          _isSelected = value;
          NotifyPropertyChanged();
        }
      }

    }
  }
}