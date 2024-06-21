 # Sequit
## A lightweight visualiser for agent traces

[![License](https://img.shields.io/github/license/quasylab/Sequit)](/LICENSE)
[![GitHub contributors](https://img.shields.io/github/contributors/quasylab/Sequit)](https://github.com/quasylab/Sequit/graphs/contributors)
[![GitHub forks](https://img.shields.io/github/forks/quasylab/Sequit?style=social)](https://github.com/quasylab/Sequit/fork)
[![Made with Unity](https://img.shields.io/badge/Made%20with-Unity-57b9d3?style=flat&logo=unity)](https://unity3d.com)
[![Unity 2022.3.14f1](https://img.shields.io/badge/Unity-2022.3.14f1-57b9d3?style=flat&logo=unity)](https://docs.unity3d.com/Manual/index.html)


<hr/>

# Introduction

***Sequit*** is a lightweight and ready-to-use player developed in Unity that can be easily operated by everyone to represent agent traces. 

The tool has been conceived to be used in pair with [Sibilla](https://github.com/quasylab/sibilla), a Java framework designed to support analysis of Collective Adaptive Systems, but can also be used as a standalone solution.

In fact, the traces can be formatted using a `csv` file type and easily uploaded to the platform.

# Features

Currently, ***Sequit*** support the following features:

- **Switching  Cameras**: The tool includes an *eagle-eye camera* and a *rotatory camera*. The first on is set above the plane, while the other one is set around a focal point.
- **Simulation Control**: The tool allows the user to stop/resume the visualisation. Moreover it is possible to speed up/slow down the replay.
- **Generating Agents**: The tool permits to load agents traces in order to generate them. These can be generated in a 2D or 3D environment.

# How to Use

The standalone build versions are available at the following [LINK](http://quasylab.unicam.it/sibilla/sequit/).

After unzipping the chosen folder, it is necessary to execute the right file to open the tool:

- **macOS**: Click on the icon with the *QuaSyLab* logo.
- **Windows**: Click on the file `Sequit.exe`.
- **Linux**: In a terminal, navigate into the distribution folder and type `./Sequit_DistLinux.x86_64`.

After opening the tool, the steps to work with ***Sequit*** are the same for every version.

1. Press the `Start` button
2. Click on the icon with the person to start adding agents
3. Complete the form that has popped up
   1. Choose between a 2D or 3D environment
   2. Select the folder path from your computer where the traces are saved
   3. Choose the prefab plane
   4. Press `Generate Agents`
5. Use the `WASD`/`Arrow Keys` to navigate
6. Use the `Mouse Wheel` or the Camera buttons (+ and -) to get closer or move away
7. Use the central Camera button to change camera type.
8. Use the `Spacebar` or the Play button to stop/resume the visualisation

If you need help with the available shortcut commands, press `H`.

# Citing Sequit
If you want to cite Sequit in your paper, you can use the following .bibtex:
```
@inproceedings{Sequit2024,
  author       = {Nicola Del Giudice and
                  Federico Maria Cruciani and
                  Michele Loreti},
  editor       = {Ilaria Castellani and
                  Francesco Tiezzi},
  title        = {Visualisation of Collective Systems with Sequit and Sibilla},
  booktitle    = {Coordination Models and Languages - 26th {IFIP} {WG} 6.1 International
                  Conference, {COORDINATION} 2024, Held as Part of the 19th International
                  Federated Conference on Distributed Computing Techniques, DisCoTec
                  2024, Groningen, The Netherlands, June 17-21, 2024, Proceedings},
  series       = {Lecture Notes in Computer Science},
  volume       = {14676},
  pages        = {277--294},
  publisher    = {Springer},
  year         = {2024},
  doi          = {10.1007/978-3-031-62697-5\_15}
}
```
