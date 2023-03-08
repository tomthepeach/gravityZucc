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

vals = [bounded_gaussian(0.5, 40, 0, 150) for i in range(10000)]

plt.hist(vals, bins=100)
print(np.mean(vals))

# %%
