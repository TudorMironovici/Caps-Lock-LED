# What I Learned
- How to work with the Windows Forms Application project template.
- How to work with the telemetry systems in Windows (the IsKeyLocked method in particular).
- How to make context menus for notification tray icons.
- How to work with threads and manage its cycle time to avoid taxing the system's hardware more than necessary. <br />





# Caps Lock LED
Some newer laptops don't have an LED on their keyboard's caps lock. Since this is a minor inconvenience, it doesn't necessarily merrit modifying the keyboard itself to add that little notifying toggle LED. So the next best thing would be having an icon in your notification tray that updates to show you when your caps lock is either toggled on or off. <br />
Most modern notification tray icons are monochrome, with transparent backgrounds. The icons in this program follow that trend, being just:  <br />
a white hollow circle for the "off" state  <br />
![Image of "off" state](https://i.imgur.com/7H14bQ6.png)  <br />
and the same circle, but filled in, for the "on" position. <br />
![Image of "on" state](https://i.imgur.com/wCzvLRM.png)  <br />
These .ico files are stored in __...\Caps Lock LED\bin\Debug__ and can be changed to your preferance. Just make sure to keep the same file names, or else the program won't find your new .ico files.  <br />
This program checks the status of your caps lock key every 100 milliseconds (10 times a second) - a nice balance between having the icon be accurate and the program not taxing your system too much. If you wish to change that timing, go into __HiddenForm.cs__ and change the value inside line 93's .Sleep() method to whatever suits your needs.  <br />
If you wish to have this program run on startup, create a shortcut of __Caps Lock LED.exe__ from the __...\Caps Lock LED\bin\Debug__ folder, and move that shortcut to __C:\ProgramData\Microsoft\Windows\Start Menu\Programs\StartUp__. <br />
If you wish to quit the program, simply right click on the icon, and hit quit.
