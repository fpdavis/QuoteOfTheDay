# QuoteOfTheDay
LaunchBox plugin to display a Quote or Bible Verse on application start

This plugin is still in development and still has some quirks to work out as noted below.

To install from repository copy the \QuoteOfTheDay\QuoteOfTheDay\bin\Release folder to your LaunchoBox\Plugins folder and rename it QuoteOfTheDay.

Once installed when you launch LaunchBox or BigBox you will be presented with a quote as soon as the application starts.
The quote will stay on the screen for several seconds before disappearing. Clicking on the quote will dismiss it immediatly.

There are several options in the QuoteOfTheDay.dll.config that you may want to change...

    QOTD_Type: Valid values are "Bible Gateway Verse", "Brainy Quote", "Local File", or "Random". Local File is the default value.
    
      Bible Gateway Verse: Loads https://www.biblegateway.com/usage/votd/rss/votd.rdf from Bible Gateway and
              displays the Bible Verse of the Day. This was the original inspiration for the plugin
              and was inspired by Dubbloseven from a Live Developer Session who sugested we add a
              "Bible Wheel" to LaunchBox (Let's Build Some Plugins! - 2017-05-08 - 
              LaunchBox Development Live Streams @ 11:30).
      Brainy Quote: Loads https://feeds.feedburner.com/brainyquote/QUOTEBR from BrainyQuote.com and
              displays the Quote of the Day
      Local File: Loads a local file named Quotes.xml and randomly displays a quote from this file.
              This file contains many Video Game related quotes. This is a standard XML file and
              you can add your own quotes and remove quotes from this file as desired. 
      Random: Randomly displays one of the types listed above (Verse, Quote, or Local).
    
        
   SecondsToDisplayQuote: How long to leave the quote on the screen. Too long and you will be waiting,
                          too short and you won't be able to read the quote. This value is specified
                          in seconds. 8.5 is the default value.
                           
    QuoteWidthPercentage: Allows you to specify how wide the quote window will be specified in a percentage
                          in relation to the parent window (LaunchBox or BigBox). 80 is the default value.
                          Good values should fall between 50 and 100.
   QuoteHeightPercentage: Allows you to specify how tall the quote window will be specified in a percentage
                          in relation to the parent window (LaunchBox or BigBox). 80 is the default value.
                          Good values should fall between 50 and 100.
        
   MinimumCharactersPerLine: The minimum number of characters to display on a line. A smaller number
                             will result in larger text. 20 is the default value.
    
   MaxNumberOfLines: The maximum number of lines to fit the quote into. The less lines the smaller the
                     text will be. 4 is the default value.

   FontHexColor: Color for the text of the quote represented in HTML color codes.
                 White, "#ffffff", is the default value.
                 
    BackgroundColor: Color for the box behind the quote. Gray, "#333333" is the default value.
    
    BackgroundOpacityPercentage: Allows you to specify how translucent/opaque the box behind the quote will be.
                             Opacity Percentage can be between 0 and 100. 60 is the default valule.
                             
    TransparancyAlphaValue: You can make the quote text translucent with this setting.
                            Valid values are 0 to 255. 0 = invisible, 255 = fully opaque.
                            255 is the default value.    

   BibleVersion: Integer corresponding to a list of Bible Translations to pull from.

    WindowNames: This is a comma seperated list of LaunchBox windows names to match against.
                 This is used to determine the size and placement of the quote. This should
                 not need to be changed. Empty or inaccurate values in this setting will
                 cause quote box sizes to be based on the entire size of the screen.
                 Valid valules are "LaunchBox Games Database", "LaunchBox Premium", "LaunchBox Big Box"

ToDo:

   * Replace winforms implimentation with XAML display and figure out how to attach it directly to the application window.
   * Provide full list of Bible Versions available.
   * Fade in/Fade out quotes. This turned out to be very hard using the current method, hopefully much easier with XAML.
   * Make hitting a key dismiss the quote so you can get straight to the game playing!
   * Fix Test button on Settings dialog.
   * Make Test button work without having to save settings.
   * Tweak background colors for text boxes on Settings dialog (sometimes font and background color can be too close in color).
   * Possibly add more quote sources.
   
   

