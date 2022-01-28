// <https://discord.com/channels/768447528705589278/772092678179520513/935119742249869402> のソースコードを使用しています。
// 権利は かずき(Kazuki Ota) <https://twitter.com/okazuki> さんに帰属します。

using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

var stopwatch = new Stopwatch();
stopwatch.Start();

var lines = File.ReadAllLines("test.csv");
var result = lines
    .Skip(1)
    .AsParallel()
    .Select(x => x.Split(','))
    .GroupBy(x => x[0])
    .Select(g => new ResultData(g.Key, g.Sum(x => MultiplyToInt(double.Parse(x[2]), double.Parse(x[3])))));

using (FileStream file = File.OpenWrite("result.csharp.json"))
{
    JsonSerializer.Serialize(file, result, SourceGenerationContext.Default.IEnumerableResultData);
}

var ts = stopwatch.Elapsed;
Console.WriteLine($"所要時間(C#): {ts.TotalSeconds}秒");

Console.WriteLine("どれかキーを押してください。");
Console.ReadKey();

int MultiplyToInt(double x, double y)
{
    if (x > 0)
        return (int)(x * y + 0.0000001);
    return (int)(x * y - 0.0000001);
}

[JsonSerializable(typeof(IEnumerable<ResultData>))]
internal partial class SourceGenerationContext : JsonSerializerContext { }

record struct ResultData(string a, int sum);
