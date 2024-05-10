using DependencyPropertyGenerator;

namespace App;

[DependencyProperty<ImageSource>("IconImageSource")]
[DependencyProperty<string>("Text")]
[DependencyProperty<bool>("IsExtended")]
public partial class FloatingActionButton
{
	const int IconSize = 24;

	const int DefaultFabSize = 56;

	const int DefaultIconMargin = 16;
	const int ExtendedIconMargin = 12;

	double _labelWidth;
	//double _currentWidth;

	public FloatingActionButton()
	{
		InitializeComponent();
		SizeChanged += FloatingActionButton_SizeChanged;
	}

	partial void OnIconImageSourceChanged(ImageSource? newValue)
	{
		Icon.Source = newValue;
		Icon.IsVisible = newValue is not null;
	}

	partial void OnTextChanged(string? newValue)
	{
		Label.Text = newValue ?? string.Empty;
		Label.IsVisible = !string.IsNullOrEmpty(newValue);
		_labelWidth = Label.Width;
		UpdateView();
	}

	partial void OnIsExtendedChanged()
	{
		UpdateView();
	}
	
	void FloatingActionButton_SizeChanged(object? sender, EventArgs e)
	{
		if (_labelWidth == 0)
		{
			// set initial fab's size and save label width on first render
			_labelWidth = Label.Width;
			UpdateView();
		}
	}

	void UpdateView()
	{
		_ = IsExtended && !string.IsNullOrEmpty(Text) ? Expand() : Collapse();
	}

	public async Task Expand()
	{
		MinimumWidthRequest = 80;
		
		Label.IsVisible = true;
		Container.Padding = new Thickness(12, 16, 20, 16);
		Container.Spacing = 12;

		await Task.CompletedTask;

		// LayoutTo not working https://github.com/dotnet/maui/issues/15439
		//_currentWidth = GetMaxWidth();
		/*await Task.WhenAll(new Task[]
		{
			this.LayoutTo(new Rect(new Point(Bounds.Right - _currentWidth, Bounds.Bottom - DefaultFabSize), new Size(_currentWidth, DefaultFabSize)), 200, Easing.CubicOut),
			Icon.LayoutTo(new Rect(new Point(ExtendedIconMargin, DefaultIconMargin), new Size(IconSize, IconSize)), 200, Easing.CubicOut),
			Label.FadeTo(1, 300, Easing.CubicOut),
		});*/
	}

	public async Task Collapse()
	{
		MinimumWidthRequest = -1;

		Label.IsVisible = false;
		Container.Padding = new Thickness(16);
		Container.Spacing = 16;

		await Task.CompletedTask;

		// LayoutTo not working https://github.com/dotnet/maui/issues/15439
		//_currentWidth = 56;
		/*await Task.WhenAll(new Task[]
		{
			this.LayoutTo(new Rect(new Point(Bounds.Right - _currentWidth, Bounds.Bottom - DefaultFabSize), new Size(_currentWidth, DefaultFabSize)), 200, Easing.CubicOut),
			Icon.LayoutTo(new Rect(new Point(DefaultIconMargin, DefaultIconMargin), new Size(IconSize, IconSize)), 200, Easing.CubicOut),
			Label.FadeTo(0, 300, Easing.CubicOut),
		});*/
	}

	double GetMaxWidth()
	{
		if (_labelWidth > 0)
		{
			return ExtendedIconMargin * 2 + IconSize + _labelWidth + 20;
		}
		else
		{
			return DefaultIconMargin * 2 + IconSize;
		}
	}
}