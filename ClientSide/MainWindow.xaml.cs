using DownloadManager.UserServer;
using DownloadManager.FileServer;
using System;
using System.Windows;
using System.Windows.Forms;
using Entities;
using System.Xml.Linq;
using System.IO;
using System.Xml;


namespace ClientSide
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // FileProviderServerManager.StartFileProviderServer();
            InitializeComponent();

            XmlReader reader = XmlReader.Create(Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName, "MyConfig.xml"));

            reader.ReadToFollowing("User");
            
            if(reader.ReadToDescendant("UserName"))
            {
                UserName_textBox.Text = reader.ReadElementContentAsString();
                if(reader.ReadToFollowing("Password"))
                    passwordBox.Password = reader.ReadElementContentAsString();
                if (reader.ReadToFollowing("SharedFolder"))               
                    SharedFolder_textBox.Text = reader.ReadElementContentAsString();               
                if (reader.ReadToFollowing("DownloadFolder"))
                    DownloadFolder_textBox.Text = reader.ReadElementContentAsString();
            }





            reader.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string path = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName, "MyConfig.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode root = doc.DocumentElement;


            UserServiceClient usc = new UserServiceClient();

            var user = usc.Login(UserName_textBox.Text, passwordBox.Password);
            if (user!=null)
            {
                if(DownloadFolder_textBox.Text.Equals("") || SharedFolder_textBox.Text.Equals(""))
                {
                    System.Windows.MessageBox.Show("Please provide download folder / shared folder");

                }
                else if(!DownloadFolder_textBox.Text.Equals("") && !SharedFolder_textBox.Text.Equals(""))
                {
                    XmlNode userNameNode = root.SelectSingleNode("UserName");
                    if (userNameNode == null)
                    {
                        XmlElement userName = doc.CreateElement("UserName");
                        userName.InnerText = UserName_textBox.Text;

                        XmlElement password = doc.CreateElement("Password");
                        password.InnerText = passwordBox.Password;

                        XmlElement sharedFolder = doc.CreateElement("SharedFolder");
                        sharedFolder.InnerText = SharedFolder_textBox.Text;

                        XmlElement downloadFolder = doc.CreateElement("DownloadFolder");
                        downloadFolder.InnerText = DownloadFolder_textBox.Text;

                        root.AppendChild(userName);
                        root.AppendChild(password);
                        root.AppendChild(sharedFolder);
                        root.AppendChild(downloadFolder);
                    }
                    XmlNode SharedFolderNode = root.SelectSingleNode("SharedFolder");
                    XmlNode downloadFolderNode = root.SelectSingleNode("DownloadFolder");

                    SharedFolderNode.InnerText = SharedFolder_textBox.Text;
                    downloadFolderNode.InnerText = DownloadFolder_textBox.Text;

                    doc.Save(path);
                    usc.UpdateFolders(downloadFolderNode.InnerText, SharedFolderNode.InnerText, user.UserID);
                    ShareWindow shareWindow = new ShareWindow(user.UserID);
                    shareWindow.Show();
                    this.Close();

                }
               
            }
            else
            {
                System.Windows.MessageBox.Show("Either user does not exists or the username/password are wrong!");
                UserName_textBox.Clear();
                passwordBox.Clear();
            }

            //log in if ok
           
        }
        private void Shared_Folder_Click(object sender, RoutedEventArgs e)
        {

            FolderBrowserDialog f = new FolderBrowserDialog();
            DialogResult result = f.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                this.SharedFolder_textBox.Text = f.SelectedPath;
            }



        }
        private void Download_Folder_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            DialogResult result = f.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                this.DownloadFolder_textBox.Text = f.SelectedPath;
            }
        }
    }
}
