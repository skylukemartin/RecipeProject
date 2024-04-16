# Required Link to This GitHub Repository:
[GitHub repository link](https://github.com/skylukemartin/RecipeProject)

# How to Compile and Run this Project:
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
        - Double click `RecipeProject.exe` (or just `RecipeProject`) to run the program directly from Windows Explorer.\

# Sample Recipe Output:
Once a recipe has been created, the `Display Recipe` option will display the recipe formatted like so:
```stdout
Recipe Helper - Main Menu
1 - Display Recipe
2 - Scale Recipe
3 - Reset Recipe Scale
4 - Clear Recipe
5 - Quit

Enter number to select menu option
> 1


.. Recipe: Mac n Cheese
|
|.... Ingredients:
|  |.... 4 tablespoons of Butter
|  |.... 4 tablespoons of Flour
|  |.... 3 cups of Cheese
|  |.... 1 liter of Milk
|  |.... 1 liter of Water
|  |.... 1 liter of Macaroni
|
|.... Steps:
   |.... 1. Heat water in a pot for the macaroni
   |.... 2. Once boiling, add macaroni and stir for 11 minutes before straining
   |.... 3. Heat a pot for the sauce
   |.... 4. Add butter to sauce pot, optionally with herbs/spices of your choice
   |.... 5. Wait for butter to melt
   |.... 6. Add flour to sauce pot
   |.... 7. Mix flour thoroughly into butter to avoid lumps
   |.... 8. Slowly pour milk into sauce pot while carefully stirring
   |.... 9. Continuously stir sauce as it heats up
   |.... 10. Once warm enough, add a third of the cheese to the sauce pot
   |.... 11. As soon as the sauce bubbles/boils it's ready, immediately take it off the heat
   |.... 12. Put macaroni back into the now empty pot it was boiled in (without water this time)
   |.... 13. Pour all the sauce into the same pot with the macaroni and mix gently
   |.... 14. Once mixed, pour the saucy macaroni into a baking dish
   |.... 15. Put the rest of the cheese on top
   |.... 16. Bake in oven until cheese is golden brown or melted the way you like it
   |.... 17. Enjoy
```