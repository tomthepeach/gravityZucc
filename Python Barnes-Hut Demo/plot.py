import matplotlib.pyplot as plt
import numpy as np
from matplotlib import animation
import pandas as pd


def plot_bodies(bodies : list):
    fig = plt.figure()
    ax = fig.add_subplot(111, projection='3d')
    for body in bodies:
        ax.scatter(body.pos[0], body.pos[1], body.pos[2], c='r', marker='o')
    plt.show()

# convert this code to work with 3d axes and to take the array of bodies
def animate_bodies(bodies):

    # Attaching 3D axis to the figure
    fig = plt.figure()
    ax = fig.add_subplot(111, projection="3d")
    title = ax.set_title('3D Test')

    # Setting the axes properties
    ax.set(xlim3d=(0, 100), xlabel='X')
    ax.set(ylim3d=(0, 100), ylabel='Y')
    ax.set(zlim3d=(0, 100), zlabel='Z')


    graph = ax.scatter([], [], [], c='r', marker='o')
    def update_graph(num):refusing to merge unrelated histories
    ani = animation.FuncAnimation(fig, update_graph, frames = len(bodies[0].pos_data[0]), interval=40, blit=False)

    ani.save('test.gif', writer='imagemagick', fps=5)