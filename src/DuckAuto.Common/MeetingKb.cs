using System.Collections.Generic;
using System.Linq;

namespace DuckAuto.Common;

public static class MeetingKb {
    private static readonly List<(string Type, float[] Embedding, string Text)> _items = [];

    public static void Add(string type, float[] emb, string text) {
        _items.Add((type, emb, text));
    }

    public static List<string> GetTop(string type, float[] queryEmb, int topN) {
        return _items
            .Where(i => i.Type == type)
            .Select(i => new { i.Text, Score = Cosine(queryEmb, i.Embedding) })
            .OrderByDescending(x => x.Score)
            .Take(topN)
            .Select(x => x.Text)
            .ToList();
    }

    private static float Cosine(float[] a, float[] b) {
        double dot = 0, magA = 0, magB = 0;
        for (int i = 0; i < a.Length && i < b.Length; i++) {
            dot += a[i] * b[i];
            magA += a[i] * a[i];
            magB += b[i] * b[i];
        }
        return (float)(dot / (System.Math.Sqrt(magA) * System.Math.Sqrt(magB) + 1e-8));
    }
}
