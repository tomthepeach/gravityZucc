import matplotlib.pyplot as plt
import numpy as np
from matplotlib import animation


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
    ax = fig.add_subplot(projection="3d")

    # Setting the axes properties
    ax.set(xlim3d=(0, 100), xlabel='X')
    ax.set(ylim3d=(0, 100), ylabel='Y')
    ax.set(zlim3d=(0, 100), zlabel='Z')

    print(bodies[-1].pos_data)

    # def update_scatter(i):
    #     ax.clear()
    #     for body in bodies:
    #         ax.scatter(body.pos_data[0][0], body.pos_data[1][0], body.pos_data[2][0], c='r', marker='o')

    # # Creating the Animation object
    # ani = animation.FuncAnimation(fig, update_scatter, frames=1)
    # ani.save('basic_animation.gif', fps=30)
