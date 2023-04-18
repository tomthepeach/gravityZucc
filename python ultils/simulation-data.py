# %%
import pandas as pd
import seaborn as sns
import matplotlib.pyplot as plt 


sns.set_theme(context="paper", style="whitegrid")

smass = 1.989e30
au = 1.496e11
year_S = 3.154e7

energy_factor = smass*au*au/(year_S*year_S)

df =  pd.read_csv(r"C:\Users\tom\Desktop\gravityZucc\C# Version\V1\standard.csv")
df
# %%
t_ener = df.groupby("time")[["ke","pe"]].sum()*energy_factor
t_ener["te"] = t_ener["ke"] + t_ener["pe"]


fig1, ax1 = plt.subplots(figsize=(5.78851,4))

ax1.plot(t_ener.index, t_ener["ke"], label="Kinetic Energy")
ax1.plot(t_ener.index, t_ener["pe"], label="Gravitational Potential Energy")
ax1.plot(t_ener.index, t_ener["te"], label="Simulation Net Energy")
ax1.set_xlim(0, t_ener.index.max())
plt.setp(ax1.spines.values(), linewidth=1.5, color="grey")
ax1.axhline(0, linewidth=1.5, c="grey")
ax1.set_xlabel("Time (Years)")
ax1.set_ylabel("Energy (Joules)")
ax1.legend()

fig1.savefig("Energy plot for 1x",dpi=600,bbox_inches = 'tight')

# %%
df2 =pd.read_csv(r"C:\Users\tom\Desktop\gravityZucc\C# Version\V1\timewarpedx20.csv")

t_ener2 = df2.groupby("time")[["ke","pe"]].sum() * energy_factor
t_ener2["te"] = t_ener2["ke"] + t_ener2["pe"]

fig2, ax2 = plt.subplots(figsize=(7,5))

ax2.plot(t_ener["te"], label="Timewarp = 1")
ax2.plot(t_ener2["te"], label="Timewarp=20")

# total energy is approximately constant and negatvive, this is good as it means 
# the system is gravatationally bound as expected.

# However there is some energy leaking into the system, and there are multiple pheneomena at play here, due to the approximatations made in order to simulate the system
# The first is the slow increasing drift upwards in energy, which is more pronounced for the larger timestep, this is due to the numerical integration require from going from a 
# force to a velcoity, this simulation uses the euler method, which has accumaulaes errors which are proportional to the size of the timestep, this explains the slow drift between collisions 
# Th second is due to collisons, this can be seen in the sharp jumps and spikes
# %%


<<<<<<< HEAD
=======
df3 = pd.read_csv(r"C:\Users\tom\Desktop\gravityZucc\C# Version\V1\twobody.csv")

t_ener3 = df3.groupby("time")[["ke","pe"]].sum()
t_ener3["te"] = t_ener3["ke"] + t_ener3["pe"]

fig3, ax3 = plt.subplots()

ax3.plot(t_ener3["ke"][150:], label="Kinetic Energy", ls="--")
ax3.plot(t_ener3["pe"][150:], label="Gravitational Potential Energy", ls="--")
ax3.plot(t_ener3["te"][150:], label="Total Energy")
ax3.set_xlabel("Time (Years)")
ax3.set_ylabel("Energy (Joules)")


ax3.legend()

# %%

# Astornomical values are very large, for example 1 solar mass is 1.989e30 kg. the
#  maximum value of a 32 bit float is 3.402823e38 this may cause issues with floating point accuaracy and overflows.
# in order to b=comabt this we need the system to be scaled down to manageble utints, ideal ones that stay as close to 0.0 as possible
# As such we chose the foollowing units: Distance in AU, Mass in Solar Masses, Time in years, and Velocity in AU/Year
# Converting the gravaitional constant to these units gives us ~40.0 instead of the real value of 6.674e-11 great!
# to keep the varibales of the simulations within reasonable bounds

# %%
df4 = pd.read_csv(r"C:\Users\tom\Desktop\gravityZucc\C# Version\V1\lesscollisions.csv")


t_ener4 = df4.groupby("time")[["ke","pe"]].sum()
t_ener4["te"] = t_ener4["ke"] + t_ener4["pe"]
fig4, ax4 = plt.subplots()

ax4.plot(t_ener4["te"], label="Total Energy")







>>>>>>> d0bef356366fba4496452690f8d677f5467e7064

# %%
