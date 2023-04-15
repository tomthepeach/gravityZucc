# %%
import pandas as pd


df =  pd.read_csv(r"C:\Users\tompe\Desktop\Final project code\C# Version\V1\sim_data_2023-04-14_23-45-14.csv")
df
# %%
t_ener = df.groupby("time")[["ke","pe"]].sum()
t_ener["te"] = t_ener["ke"] + t_ener["pe"]

t_ener.plot()


# %%
df2 =pd.read_csv(r"C:\Users\tompe\Desktop\Final project code\C# Version\V1\sim_data_2023-04-15_16-35-46.csv")

t_ener2 = df2.groupby("time")[["ke","pe"]].sum()
t_ener2["te"] = t_ener2["ke"] + t_ener2["pe"]

t_ener2.plot()
# %%
