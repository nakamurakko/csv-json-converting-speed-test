# <https://qiita.com/yniji/items/6585011633289a257888> のソースコードを使用しています。
# 権利は @yniji <https://qiita.com/yniji> さんに帰属します。

import pandas as pd
import numpy as np
import time

def multiply_to_int(x, y):
    return np.where(x > 0, (x * y + 0.0000001).astype(np.int), (x * y - 0.0000001).astype(np.int))

start = time.time()

df = pd.read_csv('test.csv')
# 以下は、MessagePackとpicklの場合
# df = pd.read_msgpack('test.msgpack')
# df = pd.read_pickle('test.pkl')
df['sum'] = multiply_to_int(df['x'].values, df['y'].values)
df_group = df[['a', 'sum']].groupby('a').sum()
df_group['a'] = df_group.index
df_group[['a', 'sum']].to_json('result.python.json', orient='records')

end = time.time()
print(f"所要時間(Python): {end - start}秒")