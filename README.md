# QuoteOfTheDay
LaunchBox plugin to display a Quote or Bible Verse on application start

To install from repository copy the \QuoteOfTheDay\QuoteOfTheDay\bin\Release folder to your LaunchoBox\Plugins folder and rename it QuoteOfTheDay.

Once installed when you launch LaunchBox or BigBox you will be presented with a quote as soon as the application starts.
The quote will stay on the screen for several seconds before disappearing. Clicking on the quote or hitting a key will 
dismiss it immediatly. Under the LaunchBox Tools you will find a "Quote Of The Day Settings" option. This will allow you
to configure and test several options that are stored in the QuoteOfTheDay.dll.config as detailed below.

There are several options in the QuoteOfTheDay.dll.config that you may want to change...

    QOTD_Type: Specifies where to get the text to display from. Valid values are "Bible Gateway Verse", "Brainy Quote",
	           "Local File", or "Random". Local File is the default value.
    
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
        
	   LocalFileLocation: If type is set to Local File, this is the file that a quote will be pulled randomly
	                      from. By default this is set to LaunchBox\Plugins\QuoteOfTheDay\Quote.xml. This
						  file comes with the Quote Of The Day plugin. If you customize your Quotes.xml file
						  it is recommended that you make a copy of the file and use the copy rather than the
						  original as the original may be overwritten during an update.

   MinimumCharactersPerLine: The minimum number of characters to display on a line. A smaller number
                             will result in larger text. 20 is the default value.
    
   MaxNumberOfLines: The maximum number of lines to fit the quote into. The less lines the smaller the
                     text will be. 4 is the default value.
					 
		  FontStyle: Allows for the selection of Font Style and Font Color, and various effects. 
		             Font Size is determined at run time by the plugin. 'Calibri, 9pt, style=Italic'
					 is the default value.
          FontColor: Color for the text of the quote represented in HTML color codes.
                     White is the default value.
                 
    BackgroundColor: Color for the box behind the quote. Black is the default value.
    
    BackgroundOpacityPercentage: Allows you to specify how translucent/opaque the box behind the quote will be.
                             Opacity Percentage can be between 0 and 100. 60 is the default valule.
                             
    TransparancyAlphaValue: You can make the quote text translucent with this setting.
                            Valid values are 0 to 255. 0 = invisible, 255 = fully opaque.
                            255 is the default value.    

	 AutomaticUpdates: If set to On/True, when LaunchBox/BigBox starts up the plugin will check for updates
	                   to itself and if one is found it will be downloaded and activated on the next startup.
					   No notifications/errors will be shown when this is set to On/True.

   BibleVersion: Integer corresponding to a list of Bible Translations to pull from.

    WindowNames: This is a comma seperated list of LaunchBox windows names to match against.
                 This is used to determine the size and placement of the quote. This should
                 not need to be changed. Empty or inaccurate values in this setting will
                 cause quote box sizes to be based on the entire size of the screen.
                 Valid valules are "LaunchBox Games Database", "LaunchBox Premium", "LaunchBox Big Box"

ToDo:

   * Figure out how to attach it directly to the application window.
   * Fade in/Fade out quotes. This turned out to be very hard.
   * Tweak background colors for text boxes on Settings dialog (sometimes font and background color can be too close in color).
   * Possibly add more quote sources.
   * Provide full list of Bible Versions available. Allow this to be selectable on settings screen.
   * Add optional feeds for BrainyQuotes.
   * Add a screenshot for BigBox.

Changes:
   * Made clicking the quote dismiss it.
   * Made hitting a key dismiss the quote so you can get straight to the game playing!
   * Fixed Test button on Settings dialog.
   * Test button works without having to save settings.
   * Added an update feature
   * Cleaned up Z axis issues so text is always in front of the background.
   * Made settings form automatically resize when font size dialog box changes (due to a font size change).
   * Cleaned up the closing of the quote forms.
   * Added additional help information to the app.config.
   * Added help provider to the settings screen.
   * Promt user when settings have not been saved and they go to close  the settings dialog.
   * Added option for Automatic Update with no prompting.

   
   

