# %%

import pandas as pd

df = pd.read_csv(r'C:\Users\tompe\Desktop\Final project code\csv\com.UniversityofBristol.V1-20230306_163601.csv')

df.columns
# %%
df['display_refresh_rate'].plot()
# %%
