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
