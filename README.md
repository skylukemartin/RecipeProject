# Required Link to This GitHub Repository:
[GitHub repository link](https://github.com/skylukemartin/RecipeProject)

**Getting Started**
---------------
### How to Compile and Run this Project:
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

**Usage Guide**
===============

**Main Menu**
-------------

The main menu is the entry point of the app. When first started, you will only have two options:

* **1. Create Recipe**: Create a new recipe by following the prompts.
* **2. Quit**: Exit the app.

Select option #1 by entering 1 followed by the enter key on your keyboard to create a recipe.
Once you have created a recipe, the main menu will show and let you select the following options:

* **1. Create Recipe**: Create a new recipe by following the prompts.
* **2. List All Recipes**: Display a list of all created recipes.
* **3. Display Recipe**: Display a specific recipe.
* **4. Select Recipe**: Select a recipe to perform actions on it.
* **5. Quit**: Exit the app.

​**Creating a Recipe**
-------------------

To create a recipe, select option 1 from the main menu. You will be prompted to:

* Enter a name for the recipe.
* Add ingredients one by one, specifying the name, unit of measurement, quantity, and food group for each.
* Add steps to the recipe, specifying the instructions for each step.

​**Listing Recipes**
-----------------

To list all created recipes, select option 2 from the main menu. This will display a list of all recipes.

​**Displaying a Recipe**
---------------------

To display a specific recipe, select option 3 from the main menu and then select the recipe from the list.

​**Selecting a Recipe**
---------------------

To select a recipe to perform actions on it, select option 4 from the main menu and then select the recipe from the list. This will take you to the Recipe Menu.

​**Recipe Menu**
-------------

The Recipe Menu allows you to perform actions on a selected recipe. You can:

* **1. Display Recipe**: Display the recipe details.
* **2. Scale Recipe**: Scale the recipe up or down by a specified factor.
* **3. Reset Recipe Scale**: Reset the recipe scale to its original value.
* **4. Remove Recipe**: Delete the recipe.
* **5. Back**: Return to the Main Menu.

​**Scaling a Recipe**
------------------

To scale a recipe, select option 2 from the Recipe Menu. You can choose from the following scaling factors:

* **1. Half (0.5)**
* **2. Double (2)**
* **3. Triple (3)**
* **4. Custom**: Enter a custom scaling factor.

**Troubleshooting**
---------------

If you encounter any issues or invalid inputs, the app will prompt you to try again.

**Exiting the App**
---------------------

To exit the app, select option 5 from the Main Menu.

**App Usage Examples**
---------------------

### Creating A Recipe

```cli
Recipe Helper - Main Menu
1 - Create Recipe
2 - Quit

Enter number to select menu option
> 1


What would you like to name the recipe?
> Healthy Vegetable Stir Fry


What is ingredient #1's name?
> Broccoli

1 - Milliliter
2 - Teaspoon
3 - Tablespoon
4 - Cup
5 - Liter

Select unit of measurement:
> 4


How many cup(s) of Broccoli is needed?
> 2


How many calories are in that much Broccoli?
> 62

1 - Starchy foods
2 - Vegetables and fruits
3 - Dry beans, peas, lentils and soya
4 - Chicken, fish, meat and eggs
5 - Milk and dairy products
6 - Fats and oil
7 - Water

Select food group:
> 2


Would you like to add another ingredient? (Y/N)
> y


What is ingredient #2's name?
> Carrots

1 - Milliliter
2 - Teaspoon
3 - Tablespoon
4 - Cup
5 - Liter

Select unit of measurement:
> 4


How many cup(s) of Carrots is needed?
> Cups??

Invalid input. Please enter a whole number.

How many cup(s) of Carrots is needed?
> whole number

Invalid input. Please enter a whole number.

How many cup(s) of Carrots is needed?
> 1


How many calories are in that much Carrots?
> around 52 calories I reckon

Invalid input. Please enter a whole number.

How many calories are in that much Carrots?
> 45

1 - Starchy foods
2 - Vegetables and fruits
3 - Dry beans, peas, lentils and soya
4 - Chicken, fish, meat and eggs
5 - Milk and dairy products
6 - Fats and oil
7 - Water

Select food group:
> 2


Would you like to add another ingredient? (Y/N)
> y


What is ingredient #3's name?
> Onion

1 - Milliliter
2 - Teaspoon
3 - Tablespoon
4 - Cup
5 - Liter

Select unit of measurement:
> 4


How many cup(s) of Onion is needed?
> 1


How many calories are in that much Onion?
> 46

1 - Starchy foods
2 - Vegetables and fruits
3 - Dry beans, peas, lentils and soya
4 - Chicken, fish, meat and eggs
5 - Milk and dairy products
6 - Fats and oil
7 - Water

Select food group:
> 2


Would you like to add another ingredient? (Y/N)
> n


What is step #1
> Heat oil in a wok or large skillet over medium-high heat.


Would you like to add another step? (Y/N)
> y


What is step #2
> Add onions and cook until they begin to soften, about 2-3 minutes.


Would you like to add another step? (Y/N)
> y


What is step #3
> Add broccoli, carrots, and any other desired vegetables. Cook until the vegetables are tender-crisp, about 4-5 minutes.


Would you like to add another step? (Y/N)
> n


Press enter when ready to continue
> [enter-key]
```

### Listing Recipes

```cli
Recipe Helper - Main Menu
1 - Create Recipe
2 - List All Recipes
3 - Display Recipe
4 - Select Recipe
5 - Quit

Enter number to select menu option
> list

Invalid input. Please enter a whole number.

Enter number to select menu option
> 2

~~~~~~~~~All Recipes~~~~~~~~~
\  Healthy Vegetable Stir Fry

Press enter when ready to continue
> [enter-key]
```

### Displaying A Recipe

```cli
Recipe Helper - Main Menu
1 - Create Recipe
2 - List All Recipes
3 - Display Recipe
4 - Select Recipe
5 - Quit

Enter number to select menu option
> 3

Recipe Helper - Select Recipe Menu
1 - Healthy Vegetable Stir Fry

Enter number to select recipe.
> 1


.. Recipe: Healthy Vegetable Stir Fry
|
|.... Total Calories: 153
|.... Ingredients:
|  |.... 2 cups of Broccoli
|  |.... 1 cup of Carrots
|  |.... 1 cup of Onion
|
|.... Steps:
   |.... 1. Heat oil in a wok or large skillet over medium-high heat.
   |.... 2. Add onions and cook until they begin to soften, about 2-3 minutes.
   |.... 3. Add broccoli, carrots, and any other desired vegetables. Cook until the vegetables are tender-crisp, about 4-5 minutes.



Press enter when ready to continue
> [enter-key]
```

### Selecting A Recipe

```cli
Recipe Helper - Main Menu
1 - Create Recipe
2 - List All Recipes
3 - Display Recipe
4 - Select Recipe
5 - Quit

Enter number to select menu option
> 4

Recipe Helper - Select Recipe Menu
1 - Healthy Vegetable Stir Fry

Enter number to select recipe.
> 1
```

### Scaling A Recipe

```cli
Recipe Helper - Recipe Menu
1 - Display Recipe
2 - Scale Recipe
3 - Reset Recipe Scale
4 - Remove Recipe
5 - Back

Enter number to select action for the $Healthy Vegetable Stir Fry recipe.
> 2

1 - Half (0.5)
2 - Double (2)
3 - Triple (3)
4 - Custom

Enter number to select scaling factor option
> 1

The recipe has been scaled by 0.50

Press enter when ready to continue
> 
```

### Quitting 

```cli
Recipe Helper - Recipe Menu
1 - Display Recipe
2 - Scale Recipe
3 - Reset Recipe Scale
4 - Remove Recipe
5 - Back

Enter number to select action for the $Healthy Vegetable Stir Fry recipe.
> 5


Press enter when ready to continue
> [enter-key]

Recipe Helper - Main Menu
1 - Create Recipe
2 - List All Recipes
3 - Display Recipe
4 - Select Recipe
5 - Quit

Enter number to select menu option
> 5
```

#### Brief description of what I changed based on lecturer's feedback

I have added app usage instructions and examples, so now it is more than just the compilation/running instructions.
I have added input validation to ensure entering negative values for quantities is no longer permitted.
