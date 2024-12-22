using Mistral.SDK;
using Mistral.SDK.DTOs;
using Newtonsoft.Json;

namespace IKDTematika.ThemeSelector;

public class AIThemeSelector
{
    private string themes { get; set; }
    private MistralClient client { get; set; }
    private ChatCompletionRequest request { get; set; }

    public AIThemeSelector()
    {
        themes = File.ReadAllText("Data/themes.txt");
        client = new("CDAShJrVIUtmeAgT64gpFnaTzY8eGDaQ");
        request = new ChatCompletionRequest(
            ModelDefinitions.MistralMedium,
            new List<ChatMessage>()
            {
                new ChatMessage(
                    ChatMessage.RoleEnum.System,
                    "Ты эксперт в определении тематики дисциплины. "
                    + "В качестве ответа ты можешь только писать пять дисциплин без нумерации, "
                    + "каждую дисциплину на новой строке, без пояснения своего выбора."),
                new ChatMessage(
                    ChatMessage.RoleEnum.User,
                    ""
                ),
                            },
                safePrompt: false,
                temperature: 0,
                maxTokens: 500,
                topP: 1,
                randomSeed: 32
            );
    }

    public async Task<string[]?> TryGetThemes(string theme)
    {
        var res = new string[5];
        try
        {
            request.Messages[1] = new()
            {
                Role = ChatMessage.RoleEnum.User,
                Content = $"Выбери из этого списка пять тематик, подходящих к дисциплине \"{theme}\".\n" + themes
            };
            var response = await client.Completions.GetCompletionAsync(request);
            res = response.Choices.First().Message.Content.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        }
        catch (System.Exception)
        {
            return null;
        }

        if (res.Length < 5)
        {
            return null;
        }
        if(res.Length > 5)
        {
            return res.Take(5).ToArray();
        }



        return res;
    }

}
