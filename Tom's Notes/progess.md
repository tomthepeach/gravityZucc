### Setting up development environment

To get the Quest 2 set up for development with unreal engine I need several things:

- Unreal engine
- Android studio/sdks
- Occulus PC app

I use a linux desktop, which has the hardware needed to run unreal engine.
Unfortunately by the grace of Zucc, the occulus PC app is only distrubuted for mac and windows :)

After many hours of trying to get things to work/hacky attempts to find a workaround I have given into Bill Gates and partioned a hard drive to dual boot Windows so I can start making progress. 

Successfull dual booted windows 10

### Setting up dev environment on windows

I have installed the following:

- Unreal engine
- Android studio
- Occulus PC app
- Java SDK
- Android SDK
- Sidequest
- Meta Quest Development Hub

After several hours of tinkering and troubleshooting, I have managed to package the deafult vr demo in unreal engine and upload it to the Quest headset!

This tutorial helped a lot:

https://www.youtube.com/watch?v=TXQhGjVZJ-8

A descosion has benn made to switch to unity due to better documentation and more appropriate tooling for non-AAA development.
Unfortunately we will now have to learn unity/C#

I have found some post processing effects I'm interested in applying to our project if there is time to add to the visual appeal:
https://github.com/GarrettGunnell/Post-Processing


Decided to spawn a galaxy as the base of the simulation, idea is to use a greayscale image of a galaxy to represent a proabablitity density, then write a function that converts this image to an array and randomly spawns stars in the simulation space according to this probability density.

Currently creating a skybox for the project using deep field images from the hubbles space telescope for realism, have cut out a cube map from the raw images and will see if it needs editing to remove seams once I've loaded in as a skybox


