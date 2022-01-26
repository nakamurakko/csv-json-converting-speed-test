# csv-json-converting-speed-test

CSV から JSON に変換する処理速度を比較するプロジェクト。

* [データの処理であれば、C#のLinq よりも Pythonの方が2倍速くなる](https://qiita.com/yniji/items/6585011633289a257888) のソースを基にしている箇所は、コードの所有権は記事を作成した人にあります。無断で使用は不可です。
* ToJson に記載したコードのほとんどは Discord の議論の中で提示されたコードを使用していますので、私に帰属しません。無断で使用は不可です。

## 確認した環境

* Windows 10 (x64)
* Visual Studio 2022
* Python 3.10.2 (x64)

## 準備

1. Visual Studio 2022 で CsvJsonConvertinSpeedTest.sln の ToJson プロジェクトをビルドする。
1. Python をインストールする。
1. コマンドプロンプトで `pip install pandas` を実行して、 Python で使用するライブラリーをインストールする。

## 確認方法

1. リポジトリー直下の bin ディレクトリーに移動する。
~~1. TestDataOutput.exe を起動する。~~
    ~~1. データ数に任意の数字を入力して、CSV出力ボタンをクリックする。~~
    ~~1.  test.csv ファイルが作成されている事を確認する。~~
1. data.py.bat を実行する。
    1.  test.csv ファイルが作成されている事を確認する。
1. 下記ファイルを実行して、コンソールに出力される処理結果を比較する。
    1. ToJson.exe (C#。出力ファイル名は「result.csharp.json」。)
    1. app.py.bat (Python。出力ファイル名は「result.python.json」。)