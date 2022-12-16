using Gaten.Net.IO;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Gaten.Windows.FileExplorer.Models
{
    public class FileExplorerModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string currentPath;
        public string CurrentPath
        {
            get => currentPath;
            set
            {
                currentPath = value;
                OnPropertyChanged(nameof(CurrentPath));
            }
        }

        public ObservableCollection<FileModel> CurrentPathBlocks => GetCurrentPathBlocks();

        public ObservableCollection<FileModel> Files { get; set; }

        public ObservableCollection<FileModel> SelectedFiles { get; set; }
        public string StatusText => GetStatusText();

        public FileExplorerModel()
        {
            currentPath = GPath.Desktop;
            Files = new ObservableCollection<FileModel>();
            SelectedFiles = new ObservableCollection<FileModel>();
        }

        public string GetStatusText()
        {
            var fileCount = Files.Count;
            var selectedFileCount = SelectedFiles.Count;
            var selectedFileLength = Utils.Util.AbbreviatedFileSize(SelectedFiles.Sum(x => x.Length));

            return $"{fileCount}개 항목  |  {selectedFileCount}개 항목 선택함 {selectedFileLength}  |";
        }

        public ObservableCollection<FileModel> GetCurrentPathBlocks()
        {
            var result = new ObservableCollection<FileModel>();

            var segments = currentPath.Split('\\', System.StringSplitOptions.None);
            result.Add(new FileModel(FileType.Directory, string.Empty, segments[0]));
            for(int i = 0; i < segments.Length - 1; i++)
            {
                var block = new FileModel(FileType.Directory, string.Join('\\', segments[..i]), segments[i + 1]);
                result.Add(block);
            }

            return result;
        }
    }
}
