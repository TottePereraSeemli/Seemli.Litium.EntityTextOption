using Litium.FieldFramework.FieldTypes;
using Litium.Globalization;
using Litium.Media;
using SpotOn.Litium.EntityTextOption.Entity;

namespace SpotOn.Litium.EntityTextOption.Entities.Implementations;

public class FolderEntity : IEntity
{
    private readonly FolderService _folderService;
    private readonly LanguageService _languageService;

    public FolderEntity(FolderService folderService, LanguageService languageService)
    {
        _folderService = folderService;
        _languageService = languageService;
    }

    public Type EntityType => typeof(Folder);

    public List<TextOption.Item> GetEntityItems()
    {
        var allFolders = GetAllFolders();

        return allFolders.Select(folder => new TextOption.Item
        {
            Value = folder.SystemId.ToString(),
            Name = folder.Localizations
        }).ToList();
    }

    private List<FolderModel> GetAllFolders()
    {
        var folders = new List<FolderModel>();
        var root = _folderService.Get(Guid.Empty);
        AppendFolderAndChildFolders(root, folders);
        return folders;
    }

    private void AppendFolderAndChildFolders(Folder folder, List<FolderModel> folderModels)
    {
        var name = GetName(folder);
        folderModels.Add(new FolderModel
        {
            SystemId = folder.SystemId,
            Localizations = _languageService.GetAll().ToDictionary(l => l.CultureInfo.Name, _ => name)
        });

        var childFolders = _folderService.GetChildFolders(folder.SystemId);

        foreach (var childFolder in childFolders)
        {
            AppendFolderAndChildFolders(childFolder, folderModels);
        }
    }

    private string GetName(Folder folder)
    {
        var parentNames = new List<string>();
        var parent = _folderService.Get(folder.ParentFolderSystemId);

        while (parent != null)
        {
            parentNames.Add(parent.Name.First().ToString());
            parent = _folderService.Get(parent.ParentFolderSystemId);
        }

        parentNames.Reverse();
        var name = parentNames.Aggregate((prev, curr) => $"{prev}/{curr}");

        return name + "/" + folder.Name;
    }

    public T? GetEntity<T>(string value)
    {
        return (T) (object) _folderService.Get(new Guid(value));
    }
    
    private class FolderModel
    {
        public Guid SystemId { get; set; }
        public Dictionary<string, string> Localizations { get; set; } = new();
    }
}