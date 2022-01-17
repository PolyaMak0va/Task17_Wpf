using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task17_Wpf
{
    /// <summary>
    /// Логика взаимодействия для ColorChanged.xaml
    /// </summary>
    public partial class ColorChanged : UserControl
    {
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register(
                nameof(Color),
                typeof(Color),
                typeof(ColorChanged),
                new FrameworkPropertyMetadata(
                    Colors.Black,
                    new PropertyChangedCallback(OnColorChanged)));

        public static readonly DependencyProperty RedProperty =
            DependencyProperty.Register(
                nameof(Red),
                typeof(byte),
                typeof(ColorChanged),
                new FrameworkPropertyMetadata(
                    new PropertyChangedCallback(OnColorRGBChanged)));


        public static readonly DependencyProperty GreenProperty =
            DependencyProperty.Register(
                nameof(Green),
                typeof(byte),
                typeof(ColorChanged),
                new FrameworkPropertyMetadata(
                    new PropertyChangedCallback(OnColorRGBChanged)));

        public static readonly DependencyProperty BlueProperty =
            DependencyProperty.Register(
                nameof(Blue),
                typeof(byte),
                typeof(ColorChanged),
                new FrameworkPropertyMetadata(
                    new PropertyChangedCallback(OnColorRGBChanged)));

        public static readonly RoutedEvent ColorChangedEvent =
            EventManager.RegisterRoutedEvent(
                nameof(NewColorChanged),
                RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<Color>),
                typeof(ColorChanged));

        public event RoutedPropertyChangedEventHandler<Color> NewColorChanged
        {
            add => AddHandler(ColorChangedEvent, value);
            remove => RemoveHandler(ColorChangedEvent, value);
        }

        public Color Color
        {
            get => (Color)GetValue(ColorProperty); // это метод возвращает object
            set => SetValue(ColorProperty, value);
        }

        public byte Red
        {
            get => (byte)GetValue(RedProperty);
            set => SetValue(RedProperty, value);
        }

        public byte Green
        {
            get => (byte)GetValue(GreenProperty);
            set => SetValue(GreenProperty, value);
        }

        public byte Blue
        {
            get => (byte)GetValue(BlueProperty);
            set => SetValue(BlueProperty, value);
        }

        private static void OnColorRGBChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            ColorChanged colorChanged = (ColorChanged)sender;
            Color color = colorChanged.Color;
            if (e.Property == RedProperty)
            {
                color.R = (byte)e.NewValue;
            }

            else if (e.Property == GreenProperty)
            {
                color.G = (byte)e.NewValue;
            }

            else if (e.Property == BlueProperty)
            {
                color.B = (byte)e.NewValue;
            }

            colorChanged.Color = color;
        }

        private static void OnColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Color colorNewValue = (Color)e.NewValue;
            ColorChanged colorpicker = (ColorChanged)sender;

            colorpicker.Red = colorNewValue.R;
            colorpicker.Green = colorNewValue.G;
            colorpicker.Blue = colorNewValue.B;
        }
        public ColorChanged()
        {
            InitializeComponent();
        }
    }
}