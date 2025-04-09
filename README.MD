# A small tool to create folders or text files in Total Commander  

Total Commander has a built-in folder creation function (default: **F7**) and several plugins to extend its functionality.  

## Features  

1. Replaces the **F7** function, invoking this tool to create either a folder or a file.  
2. **Folder creation**:  
   - If the input has no extension (e.g., `subfolder`), pressing **Enter** creates a folder.  
3. **File creation**:  
   - If the input includes an extension (e.g., `.txt`, `.ini`, `.md`), pressing **Enter** creates a file.  
4. **Toggle action (Shift+Enter)**:  
   - Switches behavior—e.g., create a file named `subfolder` or a folder named `name.txt`.  
5. **Two Toggleable options**:  
   - **Write clipboard content (F1)**: Pastes clipboard text into the new file (ignored for folders).  
   - **Open after creation (F2)**: Opens the created file with the default Windows program, or folder in totalcmd.
6. **Two Manual buttons**:  
   - **Folder (Enter)**: Forces folder creation, regardless of input.  
   - **File (Shift+Enter)**: Forces file creation, regardless of input.  
7. **Configuration file (`NewFile.ini`)**:  
   - Automatically generated when pressing **F1/F2** to save preferences.  
   - This part uses [ini-parser](https://github.com/rickyah/ini-parser) (credits included).  
8. **Reverse "open after" behavior (Ctrl+Enter)**:  
   - If "open after" is enabled, skips opening; if disabled, opens the file/folder. Useful when you don't want to change the `Open after creation (F2)` option.
9. **Custom file extensions (`txtformat`)**:  
   - Default: Text files (e.g., `.txt`, `.md`, `.ini`).  
   - Add extensions manually in the INI file (e.g., `.mp4`, though not meaningful), separated by commas.  
10. **Total Commander path**:  
    - Must specify `totalcmd.exe` or `totalcmd64.exe` path in the INI file.  

## Example INI File  

```ini
[Configuration]
autowriteclipboard = True
autoopenaftercreated = True
totalcmd = C:\Path\To\TOTALCMD64.EXE
txtformat = .txt,.md,.ini,.py,.xml,.cs
```

## How to use this?

1. Download the `NewFile.exe`, put it under `%COMMANDER_PATH%\Plugins\addons\newfile\*`. 
2. Create a command in `usercmd.ini` like:

```
[em_F7]
button=
cmd=%COMMANDER_PATH%\plugins\addons\newfile\NewFile.exe
param=%P
```
3. Configure the totalcmd shortkey `F7` to `em_F7`.

