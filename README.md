# How to Compile and Run this Project
1. **Download and install Microsoft's Visual Studio with ".NET Framework 4.8 development tools" component**: 
    - [**Link to Official Installation Guide**](https://learn.microsoft.com/en-us/visualstudio/install/install-visual-studio?view=vs-2022)
    - Make sure the ".NET Framework **4.8** development tools" component is **selected** in the installer. 
    - Refer to the official installation guide. It has detailed installation instructions and even **pictures**.
2. **Download/clone this git repository to your computer**
    - To download the project as a zip, either [click here](https://github.com/skylukemartin/RecipeProject/archive/refs/heads/master.zip), or navigate to the top of this page and click the green "code" button, then click "Download ZIP". Once the zip file has been downloaded, extract it somewhere on your computer (use [this tutorial link](https://www.youtube.com/watch?v=HLBSS3JjAh0) if you don't know how).
    - Alternatively, simply run the following command in your terminal to clone the repository: `git clone https://github.com/skylukemartin/RecipeProject.git`
3. **Open the project in Visual Studio by double clicking the `RecipeProject.sln` file**
    - Select Visual Studio from the list of programs to open the file with if asked.
    - Note that the file might just be named `RecipeProject` if the show file extensions option is disabled in your Windows Explorer.
4. **Compiling and running the project**
    - Select Debug/Release in the top toolbar to change between build mode to whichever you like, noting that "Release" will build a more optimized executable.
    - Click the green play button in Visual Studio's top toolbar to compile and immediately run the project from within Visual Studio.
    - Refer to Microsoft's official guide if needed: [How to run a program with Visual Studio](https://learn.microsoft.com/en-us/visualstudio/get-started/csharp/run-program?view=vs-2022)
    - If you only wish to build/compile the project: click the build dropdown menu in Visual Studio's top menu bar, then click "Build Solution". This will compile/build the project, but not run it. 
    - If you wish to run the built executable directly from Windows Explorer: 
        - Navigate through the project's files in Windows Explorer to `Project Folder Name --> RecipeProject --> bin`
        - You will find folders named `Debug` and `Release` (or only one of them if you only built with one build mode). 
        - Inside either of these folders, you will find `RecipeProject.exe` (or just `RecipeProject` if show file extensions is disabled) 
        - Double click `RecipeProject.exe` (or just `RecipeProject`) to run the program directly from Windows Explorer.