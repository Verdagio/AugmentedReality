# Augmented Reality (ARena)

### Daniel Verdejo
3rd Year Under grad project using Unity 3d Engine, and C# to build a markerless augmented reality application

## Project summary

In this project I have built a markerless augmented reality application that uses the devices camera, gyroscope, speaker, & local storage. 
To build this application I used the Unity 3d Engine 5.5, & Visual Studio 2015. 
In preparation for this project I had researched multiple API's related to Augmented Reality such as Vuforia, but in the end decided to build the application without using these. 
The idea of the application is simple enough, the user must survive for as long as possible in their "space ship" destroying asteriods & UFOS that are trying to destroy the player. 

###### Supported Platforms

1. Android (6.0 Marshmallow or greater)[Play Store](https://play.google.com/store/apps/details?id=com.DanielVerdejo.ArTest)
2. Windows 10 mobile devices. 
3. The application will need minor additions, & adjustments in order to run on iOS devices.

### Hardware Requirements

In order to get the best experience from this application the device best suited to play on is a smartphone. 
The device must have the following:
1. A Camera
2. A Gyroscope
3. An audio output device ( speaker / headphones )
4. 135MB Storage

### How to play

Upon launch the application on a device such as a smartphone, the user will be presented a menu which will give the option to Play or Quit.

![Menu](http://imgur.com/XQntvJi.png)

Once the user choses play they are then presented with the main scene. From here the user will be able to play the game. 
The objective of the game is to survive for as long as possible, building up a highscore until their health has depleted. 
The user must manage their ammo as the reload will take 3 seconds leaving the user vunerable to damage. 
In this scene there are multiple UI components overlayed over information taken in from the camera.
The UI consists of:

1. The ship
2. Fire Button
2. Informational (eg. ammo, health, etc.)
4. Pause button

![Main1](http://imgur.com/pgnoyVb.png)

Fire Button activated

![Main2](http://imgur.com/lQMnviN.png)

If the player needs to take a short break they can pause the game. 
From the pause screen the user is able to mute the music or sound effects if they do not wish to hear audio. 
They are also able to return to the main menu or resume game play.

![Paused](http://imgur.com/gP3lF05.png)

Upon death the player will be presented with the Game over screen

![GameOver](http://imgur.com/advh2Z7.png)

## Conclusion

Over all the development of this application went smooth. 
There is a lot of helpful documentation on the Unity 3d which I researched before, & during development. 
I really enjoyed building this application and plan to build a similar larger application which will expand upon the idea that I started here.

### Reference

[Unity Documentation](https://docs.unity3d.com/ScriptReference/)
