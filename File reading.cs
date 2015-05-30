// =============================== 
// My own method to read and write
// file on Windows Phone 8.1 OS
// ===============================

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace GUI
{
    class FileManager
    {
        private StorageFile file;
        public FileManager()
        {
            Init();
        }

        private async void Init()
        {
            await OpenFile();
        }       
    
        public async Task OpenFile()
        {
            if (!ApplicationData.Current.LocalSettings.Values.ContainsKey("loaded"))
            {
                ApplicationData.Current.LocalSettings.Values["loaded"] = true;
                await ApplicationData.Current.LocalFolder.CreateFileAsync("testo.txt", CreationCollisionOption.ReplaceExisting);
            }
            file = await ApplicationData.Current.LocalFolder.GetFileAsync("testo.txt");
        }

        public async Task<string> ReadFromFile()
        {
            var text = await FileIO.ReadTextAsync(file);
            return text;
        }

        public async Task WriteOnFile(string text)
        {
            await FileIO.WriteTextAsync(file, text);
        }
    }


    //Chiamate da interfaccia
    private async void WriteButton_Click(object sender, RoutedEventArgs e)
    {
        await fileManager.WriteOnFile(WriteBox.Text);
    }

    private async void ReadButton_Click(object sender, RoutedEventArgs e)
    {
        string text = await fileManager.ReadFromFile();
        ReadBox.Text = text;
    }
}
