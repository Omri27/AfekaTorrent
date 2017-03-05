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
using Microsoft.Win32;
using System.IO;
using FreeFilesServerConsole.WCFServices;
using FreeFile.DownloadManager.UserServer;
using FreeFile.DownloadManager.FileServer;

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
            FileProviderServerManager.StartFileProviderServer();
            InitializeComponent();
        }
        private void ShareWindow_Load(object sender, RoutedEventArgs e)
        {
            
            fileTransferManager = new FileTransferManager();
            fileTransferManager.FilePartDownloaded += fileTransferManager_FilePartDownloaded;

            FilesServiceClient fsc = new FilesServiceClient();
            List<Entities.File> fileList = new List<Entities.File>();
                foreach (Entities.File file in fsc.GetAllFiles())
                {
                    Entities.File currentFile = new Entities.File();
                    currentFile.FileName = file.FileName;
                    currentFile.FileSize = file.FileSize;
                    currentFile.FileType = file.FileType;
                    currentFile.PeerID = file.PeerID;
                    currentFile.PeerHostName = file.PeerHostName;
                    fileList.Add(currentFile);
                }
                dataGrid.ItemsSource = fileList;
                dataGrid.DataContext = fileList;
        }

        void fileTransferManager_FilePartDownloaded(object sender, DataContainerEventArg<FileTransferManager.FilePartData> e)
        {
            List<Tuple<FreeFile.DownloadManager.FileTransferManager.DownloadParameter, Byte[]>> data = new List<Tuple<FreeFile.DownloadManager.FileTransferManager.DownloadParameter, Byte[]>>();
            data.Add(new Tuple<FreeFile.DownloadManager.FileTransferManager.DownloadParameter, Byte[]>(e.Data.DownloadParameter, e.Data.FileBytes));
            if (e.Data.DownloadParameter.AllPartsCount == e.Data.DownloadParameter.Part)
            {
                saveFile(data);
            }
        }

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

        private void shareBtn_Click(object sender, RoutedEventArgs e)
        {
           
            UserServiceClient service = new UserServiceClient();

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //DialogResult result = openFileDialog1.ShowDialog();
            if (openFileDialog1.ShowDialog() == true)
            {
                //
                // The user selected a folder and pressed the OK button.
                // We print the number of files found.
                //
                List<Entities.File> addedFiles = new List<Entities.File>();
                Entities.Peer peerType = new Entities.Peer();

                Entities.File FileType = new Entities.File();
                FileInfo fInfo = new FileInfo(openFileDialog1.FileName);
                FileType.FileName = openFileDialog1.FileName;
                FileType.FileSize = (int)fInfo.Length;
                FileType.FileType = System.IO.Path.GetExtension(openFileDialog1.FileName);
                FileType.PeerHostName = Config.LocalHostyName;
                peerType.PeerID = FileType.PeerID = Guid.NewGuid();
                addedFiles.Add(FileType);


                peerType.PeerHostName = Config.LocalHostyName;
                fileTransferManager.AddFiles(addedFiles, peerType);
                MessageBox.Show("Files Added!");
            }
        }

        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Entities.File fileSearchResult = dataGrid.SelectedItem as Entities.File;
            this.fileTransferManager.Download(fileSearchResult);
        }


        private void saveFile(List<Tuple<FileTransferManager.DownloadParameter, byte[]>> data)
        {
            //CheckForIllegalCrossThreadCalls = false;

            Dispatcher.Invoke(new Action(() =>
            {
                var lst = data.OrderBy(x => x.Item1.Part).ToList();
                var bytes = new List<byte>();
                for (int i = 0; i < lst.Count; i++)
                {
                    bytes.AddRange(lst[i].Item2);
                }
                var dialog = new SaveFileDialog();
                dialog.FileName = System.IO.Path.GetFileNameWithoutExtension(data[0].Item1.FileSearchResult.FileName);
                dialog.DefaultExt = data[0].Item1.FileSearchResult.FileType;
                dialog.ShowDialog(this);
                if (!string.IsNullOrEmpty(dialog.FileName))
                {
                    System.IO.File.WriteAllBytes(dialog.FileName, bytes.ToArray());
                }
                MessageBox.Show(this, "File saved!");
            }));
           
        }


    }
}
