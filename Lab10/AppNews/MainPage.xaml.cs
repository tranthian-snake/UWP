using AppNews.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AppNews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Music> Musics;
        private List<String> Suggestions;
        private List<MenuMusic> MenuMusics;
        public MainPage()
        {
            this.InitializeComponent();
            Musics = new ObservableCollection<Music>();
            MusicManager.GetAllMusics(Musics);

            MenuMusics = new List<MenuMusic>();
            MenuMusics.Add(new MenuMusic { IconFile = "Assets/Icons/hoa.png", Category = MusicCategory.NhacHoa });
            MenuMusics.Add(new MenuMusic { IconFile = "Assets/Icons/nhat.png", Category = MusicCategory.NhacNhat });
            MenuMusics.Add(new MenuMusic { IconFile = "Assets/Icons/vn.png", Category = MusicCategory.VietNam });
            MenuMusics.Add(new MenuMusic { IconFile = "Assets/Icons/usuk.png", Category = MusicCategory.US_UK });

            BackButton.Visibility = Visibility.Collapsed;
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void MusicGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var music = (Music)e.ClickedItem;
            MyMediaElement.Source = new Uri(this.BaseUri, music.AudioFile);
        }

        private void MenuMusicsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuMusic = (MenuMusic)e.ClickedItem;

            CategoryTextBlock.Text = menuMusic.Category.ToString();
            MusicManager.GetMusicsByCategory(Musics, menuMusic.Category);
            BackButton.Visibility = Visibility.Visible;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            goBack();
        }

        private async void MusicGridView_Drop(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                var musics = await e.DataView.GetStorageItemsAsync();

                if (musics.Any())
                {
                    var storageFile = musics[0] as StorageFile;
                    var contentType = storageFile.ContentType;

                    StorageFolder folder = ApplicationData.Current.LocalFolder;

                    if (contentType == "audio/mp3" || contentType == "audio/mpeg")
                    {
                        StorageFile newFile = await storageFile.CopyAsync(folder, storageFile.Name, NameCollisionOption.GenerateUniqueName);
                        MyMediaElement.SetSource(await storageFile.OpenAsync(FileAccessMode.Read), contentType);
                        MyMediaElement.Play();
                    }
                }
            }

        }

        private void MusicGridView_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Copy;

            e.DragUIOverride.Caption = "drop to create a custom sound and title";
            e.DragUIOverride.IsCaptionVisible = true;
            e.DragUIOverride.IsContentVisible = true;
            e.DragUIOverride.IsGlyphVisible = true;

        }

        private void SearchAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(sender.Text)) goBack();
            MusicManager.GetAllMusics(Musics);
            Suggestions = Musics.Where(p => p.Name.StartsWith(sender.Text)).Select(p => p.Name).ToList();
            SearchAutoSuggestBox.ItemsSource = Suggestions;
        }

        private void SearchAutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs e)
        {
            MusicManager.GetMusicsByName(Musics, sender.Text);
            CategoryTextBlock.Text = sender.Text;
            MenuMusicsListView.SelectedItem = null;
            BackButton.Visibility = Visibility.Visible;
        }

        private void goBack()
        {
            MusicManager.GetAllMusics(Musics);
            CategoryTextBlock.Text = "All Musics";
            MenuMusicsListView.SelectedItem = null;
            BackButton.Visibility = Visibility.Collapsed;
        }
    }
}
