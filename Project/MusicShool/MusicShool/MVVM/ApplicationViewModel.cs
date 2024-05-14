using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MusicShool.MVVM
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        public ICommand TextBoxAddCommand { get; }
        public ICommand MediaElementAddCommand { get; }
        public ICommand ImageAddCommand { get; }
        public ICommand SaveLessonCommand { get; }

        public ApplicationViewModel()
        {
            TextBoxAddCommand = new RelayCommand(AddElement);
            MediaElementAddCommand = new RelayCommand(AddElement);
            ImageAddCommand = new RelayCommand(AddElement);
            SaveLessonCommand = new RelayCommand(SaveElement);
        }

        private void SaveElement(object parametr)
        {
            foreach (var item in ContentItems)
            {
                var textBox = item as TextBox;
                if (textBox != null)
                {
                    MessageBox.Show(textBox.Text);
                }

                var mediaElement = item as MediaElement;
                if (mediaElement != null)
                {
                    MessageBox.Show(mediaElement.Source.ToString());
                }

                var image = item as Image;
                if (image != null)
                {
                    MessageBox.Show(image.Source.ToString());
                }
            }
        }

        //Хранение UI элементов
        private ObservableCollection<UIElement> _contentItems = new ObservableCollection<UIElement>();
        public ObservableCollection<UIElement> ContentItems
        {
            get => _contentItems;
            set
            {
                _contentItems = value;
                OnPropertyChanged(nameof(ContentItems));
            }
        }

        private TimeSpan _videoDuration;
        public TimeSpan VideoDuration
        {
            get => _videoDuration;
            set
            {
                _videoDuration = value;
                OnPropertyChanged(nameof(VideoDuration));
            }
        }

        private void AddElement(object parameter)
        {
            try
            {
                UIElement newElement = null;

                //Контекстное меню
                ContextMenu menu = new ContextMenu();
                MenuItem DelBlockMenuItem = new MenuItem();
                DelBlockMenuItem.Header = "Удалить блок";
                DelBlockMenuItem.Command = new RelayCommand((ob) => DeleteCurrentBlock(newElement));
                menu.Items.Add(DelBlockMenuItem);

                MenuItem UpBlockMenuItem = new MenuItem();
                UpBlockMenuItem.Header = "Перенести наверх";
                UpBlockMenuItem.Command = new RelayCommand((ob) => UpBlock(newElement));
                menu.Items.Add(UpBlockMenuItem);

                MenuItem DownBlockMenuItem = new MenuItem();
                DownBlockMenuItem.Header = "Перенести Вниз";
                DownBlockMenuItem.Command = new RelayCommand((ob) => DownBlock(newElement));
                menu.Items.Add(DownBlockMenuItem);
                //---

                switch (parameter.ToString())
                {
                    case "textBox":
                        newElement = new TextBox
                        {
                            Text = "Текст",
                            TextAlignment = TextAlignment.Left,
                            TextWrapping = TextWrapping.Wrap,
                            Margin = new Thickness(0, 10, 0, 0),
                            MinWidth = 800,
                            AcceptsReturn = true,
                            AcceptsTab = true,
                            BorderThickness = new Thickness(0),
                            ContextMenu = menu
                        }; break;


                    case "mediaElement":
                        var mediaElement = new MediaElement
                        {
                            Source = new System.Uri(UploadMediaElement()),
                            Width = 200,
                            Margin = new Thickness(0, 10, 0, 0),
                            LoadedBehavior = MediaState.Manual,
                            UnloadedBehavior = MediaState.Manual,
                            ContextMenu = menu,
                            HorizontalAlignment = HorizontalAlignment.Left,
                        };

                        mediaElement.MediaOpened += (sender, e) =>
                        {
                            VideoDuration = mediaElement.NaturalDuration.TimeSpan;
                        };

                        //Управление воспроизведением
                        var playButton = new Button { Content = "Play" };
                        playButton.Template = (ControlTemplate)Application.Current.Resources["StyleBtnDflt"];
                        playButton.Command = new RelayCommand((ob) =>
                        {
                            Play(mediaElement);

                        });

                        var pauseButton = new Button { Content = "Pause" };
                        pauseButton.Template = (ControlTemplate)Application.Current.Resources["StyleBtnDflt"];
                        pauseButton.Command = new RelayCommand((ob) => Pause(mediaElement));

                        var stopButton = new Button { Content = "Stop" };
                        stopButton.Template = (ControlTemplate)Application.Current.Resources["StyleBtnDflt"];
                        stopButton.Command = new RelayCommand((ob) => Stop(mediaElement));

                        double sliderMaxValue = VideoDuration.Seconds;
                        var slider = new Slider { Width = 200, Minimum = 0, Maximum = sliderMaxValue, Value = 0, HorizontalAlignment = HorizontalAlignment.Left };
                        slider.ValueChanged += (sender, e) =>
                        {
                            mediaElement.Position = TimeSpan.FromSeconds(slider.Value);
                        };
                        //---

                        //Что бы красиво
                        StackPanel StackPanelButtonMedia = new StackPanel()
                        {
                            Orientation = Orientation.Horizontal
                        };
                        StackPanelButtonMedia.Children.Add(playButton);
                        StackPanelButtonMedia.Children.Add(pauseButton);
                        StackPanelButtonMedia.Children.Add(stopButton);

                        StackPanel StackPanelElement = new StackPanel();
                        //StackPanelElement.Children.Add(mediaElement);
                        StackPanelElement.Children.Add(StackPanelButtonMedia);
                        StackPanelElement.Children.Add(slider);
                        //---

                        ContentItems.Add(mediaElement);
                        ContentItems.Add(StackPanelElement);
                        return;
                    case "image":


                        BitmapImage myBitmapImage = new BitmapImage();

                        myBitmapImage.BeginInit();
                        myBitmapImage.UriSource = new Uri(UploadMediaElement());

                        myBitmapImage.DecodePixelWidth = 400;
                        myBitmapImage.EndInit();

                        newElement = new System.Windows.Controls.Image()
                        {
                            Source = myBitmapImage,
                            Width = myBitmapImage.DecodePixelWidth,
                            Margin = new Thickness(0, 10, 0, 0),
                            ContextMenu = menu
                        };
                        break;
                }

                ContentItems.Add(newElement);
            }
            catch (System.UriFormatException)
            {
                MessageBox.Show("Элемент не выбран или выбран не подходящий элемент", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DownBlock(UIElement newElement)
        {
            int x = ContentItems.IndexOf(newElement);
            if (x < ContentItems.Count - 1)
                ContentItems.Move(x, x + 1);
        }

        private void UpBlock(UIElement newElement)
        {
            int x = ContentItems.IndexOf(newElement);
            if (x > 0)
                ContentItems.Move(x, x - 1);
        }

        private void DeleteCurrentBlock(UIElement DelElement)
        {
            ContentItems.Remove(DelElement);
        }

        private void Play(MediaElement mediaElement)
        {
            mediaElement.Play();
        }

        private void Pause(MediaElement mediaElement)
        {
            mediaElement.Pause();
        }

        private void Stop(MediaElement mediaElement)
        {
            mediaElement.Stop();
        }

        private string UploadMediaElement()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Видео файлы (*.mpg, *.avi, *.mp4)|*.mpg;*.avi;*.mp4| Все файлы (*.*)|*.*| Изображения (*.BMP;*.JPG;*.GIF,*.JPEG,*.PNG)|*.BMP;*.JPG;*.GIF;*.JPEG;*.PNG";
            dialog.ShowDialog();
            if (dialog.FileName != null)
            {
                return dialog.FileName;
            }
            return null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
