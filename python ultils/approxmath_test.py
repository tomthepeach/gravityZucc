# %%
import random
import math
import matplotlib.pyplot as plt

def gaussian(mean = 0.0, stdDev = 1.0):
    #Box-Muller transform
    u1 = 1.0 - random.random()  # uniform(0,1] random doubles
    u2 = 1.0 - random.random()
    randStdNormal = math.sin(2.0 * math.pi * u2)* (-2.0 * math.log(u1))**0.5 # random normal(0,1)
    result = mean + stdDev * randStdNormal #random normal(mean,stdDev^2)
    return result

def rayleigh(sigma=1.0):
    return sigma*(-2*math.log2(random.random()))**0.5

vals = [rayleigh(0.5) for i in range(10000)]

plt.hist(vals, bins=100)


# %%
