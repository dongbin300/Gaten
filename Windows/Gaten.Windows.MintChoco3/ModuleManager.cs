using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace Gaten.Windows.MintChoco3
{
    public class ModuleManager
    {
        //public static List<IModule> Modules { get; set; }
        //public static List<IModule> InstalledModules => Modules.Where(m => m.IsInstalled).ToList();
        //public static List<IModule> NotInstalledModules => Modules.Where(m => !m.IsInstalled).ToList();
        //public static List<IModule> EnabledModules => Modules.Where(m => m.IsEnabled).ToList();
        //public static List<IModule> DevelopModules => Modules.Where(m => m._ModuleType == IModule.ModuleType.Develop).ToList();
        //public static List<IModule> FileManageModules => Modules.Where(m => m._ModuleType == IModule.ModuleType.FileManage).ToList();
        //public static List<IModule> GameManageModules => Modules.Where(m => m._ModuleType == IModule.ModuleType.GameManage).ToList();
        //public static List<IModule> MusicModules => Modules.Where(m => m._ModuleType == IModule.ModuleType.Music).ToList();
        //public static List<IModule> UtilityModules => Modules.Where(m => m._ModuleType == IModule.ModuleType.Utility).ToList();
        //public static List<IModule> TestModules => Modules.Where(m => m._ModuleType == IModule.ModuleType.Test).ToList();


        //public static void Init()
        //{
        //    InitModules();
        //    //CheckModuleStatus();
        //}

        //public static void InitModules()
        //{
        //    Modules = new List<IModule>();

        //    IEnumerable<Type> moduleTypes = from t in Assembly.GetExecutingAssembly().GetTypes()
        //            where t.IsClass && t.Namespace == "MintChocoLibrary.Modules"
        //            select t;

        //    moduleTypes.ToList().ForEach(t => Modules.Add((IModule)Activator.CreateInstance(t)));
        //}

        //public static void CheckModuleStatus()
        //{
        //    if (!Directory.Exists(PathCollection.MintChocoMainPath))
        //    {
        //        Directory.CreateDirectory(PathCollection.MintChocoMainPath);
        //    }

        //    foreach(IModule module in Modules)
        //    {
        //        if (!Directory.Exists(module.Path))
        //        {
        //            Directory.CreateDirectory(module.Path);

        //            using (var client = new WebClient())
        //            {
        //                client.DownloadFile("https://treeton.xyz/mc/test.txt", Path.Combine(module.Path, "test.txt"));
        //            }
        //        }
        //    }

        //    //foreach (IModule module in Modules)
        //    //{
        //    //    if (Directory.Exists(module.Path))
        //    //    {
        //    //        FileInfo[] files = new DirectoryInfo(module.Path).GetFiles("*.dll");
        //    //        if (files.Length > 0)
        //    //        {
        //    //            module.IsInstalled = true;
        //    //        }
        //    //    }
        //    //}
        //}

        //public static bool IsExistModule(string keyword)
        //{
        //    return Modules.Exists(m => m.Keyword.Equals(keyword.ToUpper()));
        //}

        //public static IModule GetModule(string keyword)
        //{
        //    return Modules.Find(m => m.Keyword.Equals(keyword.ToUpper()));
        //}

        //public static bool IsInstalledModule(string keyword)
        //{
        //    var module = GetModule(keyword);

        //    if (module == null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return module.IsInstalled;
        //    }
        //}

        //public static bool IsEnabledModule(string keyword)
        //{
        //    var module = GetModule(keyword);

        //    if (module == null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return module.IsEnabled;
        //    }
        //}

        //public static string GetModuleFilePath(string path)
        //{
        //    int index = path.IndexOf('/');
        //    string moduleKeyword = path.Substring(0, index);
        //    string filePath = path.Substring(index + 1);

        //    return GetModule(moduleKeyword).GetFilePath(filePath);
        //}

        //public static string ReadModuleFile(string path)
        //{
        //    string filePath = GetModuleFilePath(path);

        //    try
        //    {
        //        return File.ReadAllText(filePath);
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        //public static string[] ReadModuleFileToArray(string path)
        //{
        //    return ReadModuleFile(path).Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
        //}

        //public static Dictionary<string, string> ReadModuleFileToDictionary(string path)
        //{
        //    Dictionary<string, string> result = new Dictionary<string, string>();

        //    var items = ReadModuleFileToArray(path);

        //    foreach (var item in items)
        //    {
        //        int separatorIndex = item.IndexOf(':');
        //        var key = item.Substring(0, separatorIndex);
        //        var value = item.Substring(separatorIndex + 1);

        //        result.Add(key, value);
        //    }

        //    return result;
        //}

        //public static void WriteModuleFile(string path, string contents)
        //{
        //    string filePath = GetModuleFilePath(path);

        //    try
        //    {
        //        File.WriteAllText(filePath, contents, Encoding.UTF8);
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        //public static void WriteModuleFileByArray(string path, List<string> contents)
        //{
        //    StringBuilder builder = new StringBuilder();

        //    foreach(var content in contents)
        //    {
        //        builder.AppendLine(content);
        //    }

        //    WriteModuleFile(path, builder.ToString());
        //}

        //public static void WriteModuleFileByDictionary(string path, Dictionary<string, string> contents)
        //{
        //    StringBuilder builder = new StringBuilder();

        //    foreach(var content in contents)
        //    {
        //        builder.AppendLine(content.Key + ":" + content.Value);
        //    }

        //    WriteModuleFile(path, builder.ToString());
        //}

        //public static void AppendModuleFile(string path, string contents)
        //{
        //    string filePath = GetModuleFilePath(path);

        //    try
        //    {
        //        File.AppendAllText(filePath, contents, Encoding.UTF8);
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        //public static void AppendModuleFileByArray(string path, List<string> contents)
        //{
        //    StringBuilder builder = new StringBuilder();

        //    foreach (var content in contents)
        //    {
        //        builder.AppendLine(content);
        //    }

        //    AppendModuleFile(path, builder.ToString());
        //}

        //public static void AppendModuleFileByDictionary(string path, Dictionary<string, string> contents)
        //{
        //    StringBuilder builder = new StringBuilder();

        //    foreach (var content in contents)
        //    {
        //        builder.AppendLine(content.Key + ":" + content.Value);
        //    }

        //    AppendModuleFile(path, builder.ToString());
        //}
    }
}
