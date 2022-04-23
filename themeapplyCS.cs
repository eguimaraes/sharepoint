// Get the SPColor file. Replace with the path to your SPColor file.
//https://docs.microsoft.com/pt-br/sharepoint/dev/general-development/how-to-deploy-a-custom-theme-in-sharepoint
SPFile colorPaletteFile = Web.GetFile("path to .spcolor file");
if (null == colorPaletteFile || !colorPaletteFile.Exists)
{
    // TODO: handle the error.
    return;
}

// Get the SPFont file. Replace with the path to your SPFont file.
SPFile fontSchemeFile = Web.GetFile("path to .spfont file");
if (null == fontSchemeFile || !fontSchemeFile.Exists)
{
    // TODO: handle the error.
    return;
}

// Open an SPTheme with the two files. Replace NewTheme with the name for your theme.
// Note: If you have a background image, you can specify the following:
// SPTheme.Open("NewTheme", colorPaletteFile, fontSchemeFile, backgroundURI)
SPTheme theme = SPTheme.Open("NewTheme", colorPaletteFile, fontSchemeFile);


// Now apply your theme to the site.
// The themed CSS output files are stored in the Themed folder of the Theme Gallery of the root web
// of the site collection. To specify that the files should be stored in the _themes folder within the root
// web, pass false to the ApplyTo method.
theme.ApplyTo(Web, true);
