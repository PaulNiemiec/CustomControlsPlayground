namespace CustomControlsPlayground.Controls.Chart;

public partial class Chart : ContentView
{
    public Chart()
    {
        InitializeComponent();
    }

    #region PropertyChangedMethods

    private static void OnDataSetPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        
    }

    #endregion
}