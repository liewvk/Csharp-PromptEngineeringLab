using System.Text.Json;
using PromptEngineeringLab.Models;
using PromptEngineeringLab.Prompts;
using PromptEngineeringLab.Services;

Console.Title = "C# Prompt Engineering Lab";

using var aiService = new OllamaPromptService();

Console.WriteLine("====================================");
Console.WriteLine("       PROMPT ENGINEERING LAB");
Console.WriteLine("       Visual Studio 2026");
Console.WriteLine("       Ollama + Qwen 3.5");
Console.WriteLine("====================================");

while (true)
{
    Console.WriteLine();
    Console.WriteLine("1. Compare Basic and Improved Prompts");
    Console.WriteLine("2. Explain C# Code");
    Console.WriteLine("3. Summarize Business Information");
    Console.WriteLine("4. Generate a JSON Programming Lesson");
    Console.WriteLine("0. Exit");
    Console.WriteLine();

    Console.Write("Select option: ");
    string? choice = Console.ReadLine();

    if (choice == "0")
        break;

    try
    {
        string prompt;

        switch (choice)
        {
            case "1":
                Console.Write("Enter a C# topic: ");
                string topic = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(topic))
                    break;

                Console.WriteLine();
                Console.WriteLine("Basic Prompt Response:");

                prompt = PromptTemplates.BasicPrompt(topic);

                Console.WriteLine(
                    await aiService.GenerateAsync(prompt));

                Console.WriteLine();
                Console.WriteLine("Improved Prompt Response:");

                prompt = PromptTemplates.ImprovedPrompt(topic);

                Console.WriteLine(
                    await aiService.GenerateAsync(prompt));

                break;

            case "2":
                Console.WriteLine("Enter one line of C# code:");
                string code = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(code))
                    break;

                prompt = PromptTemplates.ExplainCode(code);

                Console.WriteLine();
                Console.WriteLine("AI Explanation:");

                Console.WriteLine(
                    await aiService.GenerateAsync(prompt));

                break;

            case "3":
                Console.WriteLine(
                    "Enter business information:");

                string businessText =
                    Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(businessText))
                    break;

                prompt = PromptTemplates
                    .SummarizeBusinessText(businessText);

                Console.WriteLine();
                Console.WriteLine("Business Summary:");

                Console.WriteLine(
                    await aiService.GenerateAsync(prompt));

                break;

            case "4":
                Console.Write("Enter lesson topic: ");
                string lessonTopic =
                    Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(lessonTopic))
                    break;

                prompt = PromptTemplates
                    .CreateLessonPrompt(lessonTopic);

                string jsonResponse =
                    await aiService.GenerateAsync(
                        prompt, jsonMode: true);

                var lesson = JsonSerializer
                    .Deserialize<LessonInfo>(
                        jsonResponse,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });

                if (lesson == null ||
                    string.IsNullOrWhiteSpace(lesson.Title) ||
                    string.IsNullOrWhiteSpace(lesson.Summary) ||
                    lesson.Difficulty is not
                        ("Beginner" or "Intermediate" or "Advanced"))
                {
                    Console.WriteLine(
                        "The lesson response is incomplete " +
                        "or contains an invalid difficulty.");
                    break;
                }

                Console.WriteLine();
                Console.WriteLine($"Title: {lesson.Title}");
                Console.WriteLine(
                    $"Difficulty: {lesson.Difficulty}");
                Console.WriteLine(
                    $"Summary: {lesson.Summary}");

                break;

            default:
                Console.WriteLine("Invalid selection.");
                break;
        }
    }
    catch (HttpRequestException ex)
    {
        Console.WriteLine("Ollama API Error:");
        Console.WriteLine(ex.Message);
    }
    catch (TaskCanceledException)
    {
        Console.WriteLine("The request timed out.");
    }
    catch (JsonException)
    {
        Console.WriteLine(
            "The AI returned an invalid JSON response.");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error: " + ex.Message);
    }
}

Console.WriteLine("Goodbye!");

