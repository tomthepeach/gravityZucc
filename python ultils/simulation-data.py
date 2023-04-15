# %%
import pandas as pd


df =  pd.read_csv("sim_data_2023-04-13_11-36-28.csv")
df
# %%
t_ener = df.groupby("time")[["ke","pe"]].sum()
t_ener["te"] = t_ener["ke"]*2 + t_ener["pe"]

t_ener.plot()
# %%
