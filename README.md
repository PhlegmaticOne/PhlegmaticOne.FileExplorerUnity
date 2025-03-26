# File Explorer

<b>File explorer built for Unity projects</b>

### Sample code:

```csharp
public class ExploreFilesBehaviour : MonoBehaviour
{
    [SerializeField] private ExplorerConfigScriptable _configScriptable;

    public void OpenExplorer()
    {
        IExplorer explorer = new Explorer(_configScriptable);
        var showResult = await explorer.Open();
        Debug.Log(showResult.IsShowed);
    }
}
```

### Features:
- Works on Editor, Android, iOS
- Viewing files and directories from root directory
- Navigation between directories
- Supported file actions - delete files; showing file properties; rename files; showing files in OS file system; showing images and text files; listening audio files
- Supported directory actions - delete directories; showing directory properties; rename directories; showing directories in OS file system
- Loading file icons from server by file extension
- Previewing image content instead of file icons
- Searching files in directory
- Selecting files in directory

### Learned code approaches
- MVVM
- Dependency Injection