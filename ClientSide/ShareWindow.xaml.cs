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
using System.Windows.Shapes;
using FreeFile.DownloadManager;
using FreeFiles.TransferEngine.WCFPNRP;

namespace ClientSide
{
    /// <summary>
    /// Interaction logic for ShareWindow.xaml
    /// </summary>
    public partial class ShareWindow : Window
    {
        FileTransferManager fileTransferManager;

        public ShareWindow()
        {
            InitializeComponent();
        }
        private void ShareWindow_Load(object sender, RoutedEventArgs e)
        {

            fileTransferManager = new FileTransferManager();
            //fileTransferManager.FilePartDownloaded += fileTransferManager_FilePartDownloaded;
        }

        //void fileTransferManager_FilePartDownloaded(object sender, DataContainerEventArg<FileTransferManager.FilePartData> e)
        //{
        //    List<Tuple<FreeFile.DownloadManager.FileTransferManager.DownloadParameter, Byte[]>> data = new List<Tuple<FreeFile.DownloadManager.FileTransferManager.DownloadParameter, Byte[]>>();
        //    data.Add(new Tuple<FreeFile.DownloadManager.FileTransferManager.DownloadParameter, Byte[]>(e.Data.DownloadParameter, e.Data.FileBytes));
        //    if (e.Data.DownloadParameter.AllPartsCount == e.Data.DownloadParameter.Part)
        //    {
        //        //saveFile(data);
        //    }
        //}

        private void search_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void search_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(search_TextBox.Text))
            {
                List<Entities.File> foundFileInfoList = fileTransferManager.SearchFileByName(search_TextBox.Text);
                dataGrid.ItemsSource = foundFileInfoList;
                dataGrid.DataContext = foundFileInfoList;
                //this.dataGrid.DataContext = foundFileInfoList;
            }
        }

        //private void saveFile(List<Tuple<FileTransferManager.DownloadParameter, byte[]>> data)
        //{
        //    CheckForIllegalCrossThreadCalls = false;
        //    var lst = data.OrderBy(x => x.Item1.Part).ToList();
        //    var bytes = new List<byte>();
        //    for (int i = 0; i < lst.Count; i++)
        //    {
        //        bytes.AddRange(lst[i].Item2);
        //    }
        //    var dialog = new SaveFileDialog();
        //    dialog.FileName = Path.GetFileNameWithoutExtension(data[0].Item1.FileSearchResult.FileName);
        //    dialog.DefaultExt = data[0].Item1.FileSearchResult.FileType;
        //    dialog.ShowDialog(this);
        //    if (!string.IsNullOrEmpty(dialog.FileName))
        //    {
        //        File.WriteAllBytes(dialog.FileName, bytes.ToArray());
        //    }
        //    MessageBox.Show(this, "File saved!");
        //}


    }
}
