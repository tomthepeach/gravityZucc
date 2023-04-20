# %%
import pandas as pd
import seaborn as sns
import matplotlib.pyplot as plt 


sns.set_theme(context="paper", style="whitegrid")

smass = 1.989e30
au = 1.496e11
year_S = 3.154e7

energy_factor = smass*au*au/(year_S*year_S)

df =  pd.read_csv(r"C:\Users\tompe\Desktop\Final project code\C# Version\V1\random1x.csv")
df
# %%
t_ener = df.groupby("time")[["ke","pe"]].sum()*energy_factor
t_ener["te"] = t_ener["ke"] + t_ener["pe"]


fig1, ax1 = plt.subplots(figsize=(5.78851,4))

ax1.plot(t_ener.index, t_ener["ke"], label="Kinetic Energy")
ax1.plot(t_ener.index, t_ener["pe"], label="Gravitational Potential Energy")
ax1.plot(t_ener.index, t_ener["te"], label="Simulation Net Energy")
# ax1.set_xlim(0, t_ener.index.max())
plt.setp(ax1.spines.values(), linewidth=1.5, color="grey")
ax1.axhline(0, linewidth=1.5, c="grey")
ax1.set_xlabel("Time (Years)")
ax1.set_ylabel("Energy (Joules)")
ax1.legend()

fig1.savefig("Energy plot for 1x",dpi=600,bbox_inches = 'tight')

fig1_2, ax1_2 = plt.subplots(figsize=(5.78851,4))

ax1_2.plot(t_ener.index, t_ener["te"], label="Total Energy")
# ax1_2.set_xlim(0, t_ener.index.max())
plt.setp(ax1_2.spines.values(), linewidth=1.5, color="grey")
# ax1_2.axhline(0, linewidth=1.5, c="grey")
ax1_2.set_xlabel("Time (Years)")
ax1_2.set_ylabel("Energy (Joules)")
ax1_2.legend()

fig1_2.savefig("total Energy plot for 1x",dpi=600,bbox_inches = 'tight')

# %%

import numpy as np
df2 = pd.read_csv(r"C:\Users\tompe\Desktop\Final project code\C# Version\V1\randlowcol1x.csv")
df3 =pd.read_csv(r"C:\Users\tompe\Desktop\Final project code\C# Version\V1\randlowcol20x.csv")

t_ener2 = df2.groupby("time")[["ke","pe"]].sum() * energy_factor
t_ener2["te"] = t_ener2["ke"] + t_ener2["pe"]

t_ener3 = df3.groupby("time")[["ke","pe"]].sum() * energy_factor
t_ener3["te"] = t_ener3["ke"] + t_ener3["pe"]

fig2, ax2 = plt.subplots(figsize=(5.78851,4))


# Fit linear regression via least squares with numpy.polyfit
# It returns an slope (b) and intercept (a)
# deg=1 means linear fit (i.e. polynomial of degree 1)


y1 = t_ener2["te"][:30]
y2 = t_ener3["te"][:30]
x = t_ener2.index[:30]



b, a = np.polyfit(x, y1, deg=1)
b2, a2 = np.polyfit(x, y2, deg=1)

# Create sequence of 100 numbers from 0 to 100 
xseq = np.linspace(0, 30, num=100)


equation1 = f"Etot = {a:.2e} + {b:.2e} * t"
equation2 = f"Etot = {a2:.2e} + {b2:.2e} * t"
# Plot regression line
ax2.plot(xseq, a + b * xseq, lw=1, label = equation1);
ax2.plot(xseq, a2 + b2 * xseq, lw=1, label = equation2);


ax2.scatter(y=y1, x=x, label="Timewarp = 1")
ax2.scatter(y=y2, x=x, label="Timewarp=20")
plt.setp(ax2.spines.values(), linewidth=1.5, color="grey")
# ax1_2.axhline(0, linewidth=1.5, c="grey")
ax2.set_xlabel("Time (Years)")
ax2.set_ylabel("Energy (Joules)")

ax2.legend()

fig2.savefig("Total engergy leakge comparison",dpi=600,bbox_inches = 'tight')
# %%


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








# %%
