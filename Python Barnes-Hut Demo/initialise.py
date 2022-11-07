
from body import Body
from random import random
from numpy import array


def initialise_bodies(n: int, dimensions:array):
    bodies = array([Body(i, array([random()*dimensions[i] for i in range(3)]), array([random()*dimensions[i]*0.01 for i in range(3)])) for i in range(n)])
    return bodies

