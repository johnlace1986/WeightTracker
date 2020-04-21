using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WeightTracker.Wpf.Presentation.UserControls
{
    /// <summary>
    /// Interaction logic for DatedItemGroupView.xaml
    /// </summary>
    public partial class DatedItemGroupView : UserControl
    {
        #region Dependency Properties

        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof(string), typeof(DatedItemGroupView));

        public static readonly DependencyProperty IsExpandedProperty = DependencyProperty.Register("IsExpanded", typeof(bool), typeof(DatedItemGroupView), new PropertyMetadata(true));

        public new static readonly DependencyProperty ContentProperty = DependencyProperty.Register("Content", typeof(object), typeof(DatedItemGroupView));

        public static readonly DependencyProperty HeaderLabelStyleProperty = DependencyProperty.Register("HeaderLabelStyle", typeof(Style), typeof(DatedItemGroupView), new PropertyMetadata(Application.Current.FindResource("labelStyle")));

        public static readonly DependencyProperty ExpandImageSourceProperty = DependencyProperty.Register("ExpandImageSource", typeof(BitmapImage), typeof(DatedItemGroupView));

        public static readonly DependencyProperty CollapseImageSourceProperty = DependencyProperty.Register("CollapseImageSource", typeof(BitmapImage), typeof(DatedItemGroupView));

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the header of the view
        /// </summary>
        public string Header
        {
            get => (string)GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        /// <summary>
        /// Gets or sets a value determining whether or not the view is expanded
        /// </summary>
        public bool IsExpanded
        {
            get => (bool)GetValue(IsExpandedProperty);
            set => SetValue(IsExpandedProperty, value);
        }

        /// <summary>
        /// Gets or sets the contents of the view
        /// </summary>
        public new object Content
        {
            get => GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }

        /// <summary>
        /// Gets or sets the style of the header label
        /// </summary>
        public Style HeaderLabelStyle
        {
            get => GetValue(HeaderLabelStyleProperty) as Style;
            set => SetValue(HeaderLabelStyleProperty, value);
        }

        /// <summary>
        /// Gets or sets the image to use when the view is collapsed
        /// </summary>
        public BitmapImage ExpandImageSource
        {
            get => GetValue(ExpandImageSourceProperty) as BitmapImage;
            set => SetValue(ExpandImageSourceProperty, value);
        }

        /// <summary>
        /// Gets or sets the image to use when the view is expanded
        /// </summary>
        public BitmapImage CollapseImageSource
        {
            get => GetValue(CollapseImageSourceProperty) as BitmapImage;
            set => SetValue(CollapseImageSourceProperty, value);
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the DatedItemGroupView class
        /// </summary>
        public DatedItemGroupView()
        {
            InitializeComponent();
        }

        #endregion
    }
}
