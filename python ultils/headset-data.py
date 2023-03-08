# %%

import pandas as pd

df = pd.read_csv(r'C:\Users\tompe\Desktop\Final project code\csv\com.UniversityofBristol.V1-20230306_163601.csv')

df['gpu_utilization_percentage'].plot()
# %%
df['cpu_utilization_percentage'].plot()
# %%
