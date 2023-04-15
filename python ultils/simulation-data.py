# %%
import pandas as pd


df =  pd.read_csv(r"C:\Users\tompe\Desktop\Final project code\C# Version\V1\sim_data_2023-04-14_23-45-14.csv")
df
# %%
t_ener = df.groupby("time")[["ke","pe"]].sum()
t_ener["te"] = t_ener["ke"] + t_ener["pe"]


# %%
df2 =pd.read_csv(r"C:\Users\tompe\Desktop\Final project code\C# Version\V1\sim_data_2023-04-15_16-35-46.csv")

t_ener2 = df2.groupby("time")[["ke","pe"]].sum()
t_ener2["te"] = t_ener2["ke"] + t_ener2["pe"]


import matplotlib.pyplot as plt 

fig, ax = plt.subplots()

ax.plot(t_ener["te"], label="Timewarp = 1")
ax.plot(t_ener2["te"], label="Timewarp=20")

# total energy is approximately constant and negatvive, this is good as it means 
# the system is gravatationally bound as expected.

# However there is some energy leaking into the system, and there are multiple pheneomena at play here, due to the approximatations made in order to simulate the system
# The first is the slow increasing drift upwards in energy, which is more pronounced for the larger timestep, this is due to the numerical integration require from going from a 
# force to a velcoity, this simulation uses the euler method, which has accumaulaes errors which are proportional to the size of the timestep, this explains the slow drift between collisions 
# Th second is due to collisons, this can be seen in the sharp jumps and spikes
# %%
