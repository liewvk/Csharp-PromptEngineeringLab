# C# Prompt Engineering Lab

A small .NET console lab for experimenting with prompt engineering patterns using Ollama and a local language model.

This project demonstrates how to compare basic vs. improved prompts, explain C# code, summarize business text, and generate structured JSON lessons from a prompt.

## Overview

The application is a menu-driven console program that sends prompts to an Ollama-hosted model and displays the AI responses. It is designed as a learning lab for exploring how prompt structure affects model output.

## Features

- Compare a basic prompt against an improved prompt
- Explain a snippet of C# code
- Summarize business information from free-form text
- Generate a JSON lesson object with title, difficulty, and summary
- Use a local Ollama model instead of a cloud API

## Project structure

- `Program.cs` — interactive console menu and workflow orchestration
- `PromptEngineeringLab.csproj` — .NET project configuration
- `Models/` — data models used for structured JSON responses
- `Prompts/` — prompt-building templates
- `Services/OllamaPromptService.cs` — HTTP client integration with Ollama

## Requirements

- .NET SDK 10.0 (target framework: `net10.0`)
- Ollama installed locally
- Model pulled: `qwen3.5:9b`
- Ollama API available at `http://localhost:11434/`

## Setup

1. Install the .NET 10 SDK.
2. Install Ollama and start the service.
3. Pull the required model:

```bash
ollama pull qwen3.5:9b
```

4. Clone the repository and run the app:

```bash
git clone https://github.com/liewvk/Csharp-PromptEngineeringLab.git
cd Csharp-PromptEngineeringLab
dotnet run
```

## Usage

When the app starts, it presents a menu:

1. Compare Basic and Improved Prompts
2. Explain C# Code
3. Summarize Business Information
4. Generate a JSON Programming Lesson
0. Exit

Each option prompts for input, sends a carefully designed prompt to the model, and prints the result.

## Example prompt use cases

- "Compare the response quality of a generic prompt with a more structured prompt."
- "Explain how a LINQ query works in C#."
- "Summarize this business brief into concise action items."
- "Create a beginner-friendly lesson about async/await in JSON format."

## Notes

This repo is intended as a practical experimentation sandbox for prompt engineering with C#. It focuses on the relationship between prompt wording and response quality while keeping the implementation lightweight and easy to understand.

## Author

Repository: `liewvk/Csharp-PromptEngineeringLab`

The project is a learning-oriented sample associated with the "Csharp AI Agent ME Chapter 5" materials.
