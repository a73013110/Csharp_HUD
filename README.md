## Head-up Display (HUD)
A beautiful GUI and animation to show up notification

## File Structure
This solution contains three projects.
  1. Csharp_HUD: [Main project] implement all HUD features and compile as DLL file.
  2. WPF_HUDTest: [Test project] implement GUI button_click to open the HUD.
  3. CA_HUDTest: [Test project] implement console application to open the HUD.  4. 

## Demo
Below is the HUD demo, the message at the center and there is progress bar arround that.

![Demo](images/demo.gif)

## Usage
  1. Build project **Csharp_HUD** you will get the dll file **Csharp_HUD.dll**.
  2. Open the other project.
  3. Add reference -> Browse the file -> Select **Csharp_HUD.dll**
  4. Use the code down below
```<C#>
hud = new HUD();	// New HUD
hud.SetMsg([Insert the message title], [Insert the message detail]);	// Set the message title and detail.
hud.Show();	// Show HUD window
hud.StartDuration();	// Start progressbar animation
```

## API
There are some API in **HUD.API.cs** in project **Csharp_HUD** you can take a look and re-write it by yourself depend on the requirement.