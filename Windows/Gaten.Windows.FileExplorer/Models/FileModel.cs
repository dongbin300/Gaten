using Gaten.Net.IO;
using Gaten.Net.Wpf.Extensions;

using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Gaten.Windows.FileExplorer.Models
{
    public enum FileType
    {
        File,
        Directory
    }

    public class FileModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private FileType type;
        public FileType Type
        {
            get => type;
            set
            {
                type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        private ImageSource? icon;
        public ImageSource? Icon
        {
            get => icon;
            set
            {
                icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string path;
        public string Path
        {
            get => path;
            set
            {
                path = value;
                OnPropertyChanged(nameof(Path));
            }
        }

        private DateTime modDate;
        public DateTime ModDate
        {
            get => modDate;
            set
            {
                modDate = value;
                OnPropertyChanged(nameof(ModDate));
            }
        }

        public string ModDateString => ModDate.ToString("yyyy-MM-dd tt hh:mm");

        private long length;
        public long Length
        {
            get => length;
            set
            {
                length = value;
                OnPropertyChanged(nameof(Length));
            }
        }

        public string Size => Utils.Util.AbbreviatedFileSize(length);

        public string FullName => Path.Down(Name);

        public FileModel(FileType type, string path, string name)
        {
            this.type = type;
            this.path = path;
            this.name = name;

            var info = new FileInfo(FullName);

            try
            {
                icon = System.Drawing.Icon.ExtractAssociatedIcon(FullName)?.ToImageSource();
            }
            catch
            {
                icon = System.Drawing.Image.FromFile("Resources/folder.ico").ToImageSource();
            }

            modDate = info.LastWriteTime;

            if(type == FileType.File)
            {
                length = info.Length;
            }
            else
            {
                length = 0;
            }
        }
    }
}
