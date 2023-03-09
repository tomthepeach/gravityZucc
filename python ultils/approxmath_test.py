# %%
import random
import math
import matplotlib.pyplot as plt
import numpy as np

def gaussian(mean = 0.0, stdDev = 1.0):
    #Box-Muller transform
    u1 = 1.0 - random.random()  # uniform(0,1] random doubles
    u2 = 1.0 - random.random()
    randStdNormal = math.sin(2.0 * math.pi * u2)* (-2.0 * math.log(u1))**0.5 # random normal(0,1)
    result = mean + stdDev * randStdNormal #random normal(mean,stdDev^2)
    return result

def rayleigh(sigma=0.1):
    return (sigma*(-2*math.log2(random.random()))**0.5)

def bounded_gaussian(mean = 0.0, stdDev = 1.0, lowerBound = -1.0, upperBound = 1.0):
    while True:
        result = gaussian(mean, stdDev)
        if result >= lowerBound and result <= upperBound:
            return result

vals = [bounded_gaussian(0.5, 10, 0.1, 110) for i in range(100)]

plt.hist(vals, bins=100)
print(np.mean(vals))
print(np.sum(vals))

# %%

def beta(a, b):

    alpha = a + b
    beta = 0.0
    u1 = u2 = w = v = 0.0

    if (np.min((a, b)) <= 1.0): 
        beta = np.max(1 / a, 1 / b)
    else: 
        beta = np.sqrt((alpha - 2.0) / (2 * a * b - alpha))

    gamma = a + 1 / beta

    while (True):

        u1 = random.random()
        u2 = random.random()
        v = beta * np.log(u1 / (1 - u1))
        w = a * np.exp(v)

        tmp = np.log(alpha / (b + w))

        if (alpha * tmp + (gamma * v) - 1.3862944 >= np.log(u1 * u1 * u2)): break
    x = w / (b + w)
    return x

vals = [beta(2,478) for i in range(10000)]

plt.hist(vals, bins=100)

print(np.mean(vals)*120)

# %%


BIGG = 6.67408e-11
AU = 149597870700
SOLAR_MASS = 1.989e30
SOLAR_RADIUS = 6.957e8
YEAR_S = 31536000.0
C = 299792458.0

BIGG * YEAR_S**2 * SOLAR_MASS / AU**3

# %%
