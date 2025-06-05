# DuckAuto

Personal demo project for automated meeting notes generation using ONNX
models and a simple RAG workflow. This repository contains minimal
C# code snippets and sample data to help you get started.

## Repository Layout

```
src/
  DuckAuto.Common/   Core classes (EmbeddingClient, MeetingKb, ...)
Samples/
  meeting_summaries.csv  Example summaries in English
  sample_draft.txt       Placeholder draft text
```

The real implementation should integrate your internal LLM API or
local ONNX models as described in the design document.
